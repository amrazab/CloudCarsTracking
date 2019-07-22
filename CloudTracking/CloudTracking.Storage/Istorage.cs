using CloudTracking.Messages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CloudTracking.Storage
{
    public interface IStorage
    {
         Task<bool> UpdateStatusAsync(PingMessage message);
         Task<bool> LogStatus(PingMessage message);
        Task<List<PingMessage>> GetStatusAsync(int? status, string customerId);

    }
}
