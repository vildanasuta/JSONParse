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
        [JsonPropertyName("wwpn")]
        public string Wwpn { get; set; }
        [JsonPropertyName("wwnn")]
        public string Wwnn { get; set; }
        [JsonPropertyName("domain-id")]
        public string DomainId { get; set; }
        [JsonPropertyName("fcid")]
        public string FcId { get; set; }
        [JsonPropertyName("port name")]
        public string PortName { get; set; }
        [JsonPropertyName("port number")]
        public string PortNumber { get; set; }
        [JsonPropertyName("firmware-version")]
        public string FirmwareVersion { get; set; }
        [JsonPropertyName("serial-number")]
        public string SerialNumber { get; set; }
    }
}
