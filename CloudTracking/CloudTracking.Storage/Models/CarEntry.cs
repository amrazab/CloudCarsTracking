using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Text;

namespace CloudTracking.Storage.Models
{
    class CarEntry:TableEntity
    {
        public string CarId { get; set; }
    }
}
