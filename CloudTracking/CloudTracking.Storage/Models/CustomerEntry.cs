using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Text;

namespace CloudTracking.Storage.Models
{
    class CustomerEntry : TableEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
