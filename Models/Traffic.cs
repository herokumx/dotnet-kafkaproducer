using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FXProducer.Models
{
    public class Traffic
    {
        public string IPAddress { get; set; }
        public string DateTimeStamp { get; set; }
        public string HTTPMethod { get; set; }
        public string RequestedURL { get; set; }
        public string HTTPProtocol { get; set; }
        public string ServerResponse { get; set; }
        public string RequestSize { get; set; }
        public string BrowserRequestHeader { get; set; }
        public string cookieID { get; set; }
        public string eventSource { get; set; }
    }
}
