using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace JSONParseClass
{
    public class Port
    {
        [JsonProperty("wwpn")]
        [XmlElement("wwpn")]
        public string Wwpn { get; set; }
        [JsonProperty("wwnn")]
        [XmlElement("wwnn")]
        public string Wwnn { get; set; }
        [JsonProperty("domain-id")]
        [XmlElement("domain-id")]
        public object DomainId { get; set; }
        [JsonProperty("fcid")]
        [XmlElement("fcid")]
        public int FcId { get; set; }
        [JsonProperty("port name")]
        [XmlElement("port_name")]
        public string PortName { get; set; }
        [JsonProperty("port number")]
        [XmlElement("port_number")]
        public string PortNumber { get; set; }
        [JsonProperty("firmware-version")]
        [XmlElement("firmware-version")]
        public string FirmwareVersion { get; set; }
        [JsonProperty("serial-number")]
        [XmlElement("serial-number")]
        public string SerialNumber { get; set; }
    }

}
