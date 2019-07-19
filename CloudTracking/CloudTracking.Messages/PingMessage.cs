using System;

namespace CloudTracking.Messages
{
    public class PingMessage
    {
        public DateTime Time { get; set; }
        public string CarId { get; set; }
        public string CustomerId { get; set; }
        public int OilLevel { get; set; }
        public int Speed { get; set; }
        public CarStatus CarStatus { get; set; }
        public string ErrorMessage { get; set; }

     

    }
}
