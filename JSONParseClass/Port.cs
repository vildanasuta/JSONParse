using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace JSONParseClass
{
    public class Port
    {
        [JsonProperty("wwpn")]
        public string Wwpn { get; set; }
        [JsonProperty("wwnn")]
        public string Wwnn { get; set; }
        [JsonProperty("domain-id")]
        public object DomainId { get; set; }
        [JsonProperty("fcid")]
        public int FcId { get; set; }
        [JsonProperty("port name")]
        public string PortName { get; set; }
        [JsonProperty("port number")]
        public string PortNumber { get; set; }
        [JsonProperty("firmware-version")]
        public string FirmwareVersion { get; set; }
        [JsonProperty("serial-number")]
        public string SerialNumber { get; set; }
    }

}
