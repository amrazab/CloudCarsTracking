using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CloudTracking.Messages;
using CloudTracking.Storage.Models;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;

namespace CloudTracking.Storage
{
    public class AzureTableStorage : IStorage
    {
        CloudStorageAccount storageAccount;

        CloudTableClient tableClient;
        CloudTable tableStatus;
        CloudTable tableEventSourcing;
        IMapper mapper;

        public AzureTableStorage(string connectionString)
        {
            storageAccount = CloudStorageAccount.Parse(connectionString);
            
            tableClient = storageAccount.CreateCloudTableClient();
            tableStatus = tableClient.GetTableReference("TrackingStatus");
            tableEventSourcing = tableClient.GetTableReference("TrackEventSourcing");
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
             mapper = mappingConfig.CreateMapper();

        }
        public async Task<List<PingMessage>> GetStatusAsync(int? status,string customerId)
        {
            List<string> filters = new List<string>();
            if (status != null) 
            filters.Add(TableQuery.GenerateFilterConditionForInt("", QueryComparisons.Equal, status.Value));
            if(!string.IsNullOrEmpty(customerId))
                filters.Add(TableQuery.GenerateFilterConditionForInt("", QueryComparisons.Equal, status.Value));
            
            TableQuery<PingMessageEntity> query = new TableQuery<PingMessageEntity>();
            if(filters.Count>0)
            {
                query = query.Where( string.Join (" and " ,filters.ToArray()) );
               
            }
            var result = await tableStatus.ExecuteQuerySegmentedAsync(query, null);
            var lst = new List<PingMessageEntity>();
            lst.AddRange(result);
            return mapper.Map<List<PingMessage>>(lst);
        }
        public async Task<bool> LogStatus(PingMessage message)
        {
            try { 
            var pingEntity = mapper.Map<PingLogEntry>(message);
            pingEntity.PartitionKey = "Log";
            pingEntity.RowKey = DateTime.Now.ToString("YYYY_MM_DD_HH_mm_ss_") + Guid.NewGuid().ToString();
            

            TableOperation insertOperation = TableOperation.Insert(pingEntity);

            var r = await tableEventSourcing.ExecuteAsync(insertOperation);
            return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateStatusAsync(PingMessage message)
        {
            try
            {

                var pingEntity = mapper.Map<PingMessageEntity>(message);
                pingEntity.PartitionKey = message.CustomerId;
                pingEntity.RowKey = message.CarId;
                TableOperation insertOrReplaceOperation = TableOperation.InsertOrReplace(pingEntity);

                var r = await tableStatus.ExecuteAsync(insertOrReplaceOperation);
                return true;
            }catch(Exception ex)
            {
                return false;
            }
        }
    }
}
