using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Text;

namespace CloudTracking.Storage.Models
{
    class PingLogEntry: TableEntity
        {
            public DateTime Time { get; set; }
            public string CarId { get; set; }
            public string CustomerId { get; set; }
            public int OilLevel { get; set; }
            public int Speed { get; set; }
            public int CarStatus { get; set; }
            public string ErrorMessage { get; set; }
           
        }
    }
