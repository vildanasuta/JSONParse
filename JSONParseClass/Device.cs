using Newtonsoft.Json;
using System.Text.Json;
using System.Xml.Serialization;

namespace Parsing
{
    [XmlRoot("root", Namespace = "")]
    public class Device
    {
        [JsonProperty("deviceName")]
        [XmlElement("deviceName")]
        public string? DeviceName { get; set; }
        [JsonProperty("manufacturer")]
        [XmlElement("manufacturer")]
        public string? Manufacturer { get; set; }
        [JsonProperty("part-number")]
        [XmlElement("part-number")]
        public string? PartNumber { get; set; }
        [JsonProperty("serial-number")]
        [XmlElement("serial-number")]
        public string? SerialNumber { get; set; }
        [JsonProperty("product-name")]
        [XmlElement("product-name")]
        public string? ProductName { get; set; }
        [JsonProperty("vendor-part-number")]
        [XmlElement("vendor-part-number")]
        public string? VendorPartNumber { get; set; }
        [JsonProperty("vendor-serial-number")]
        [XmlElement("vendor-serial-number")]
        public string? VendorSerialNumber { get; set; }
        [JsonProperty("license-id")]
        [XmlElement("license-id")]
        public string? LicenseId { get; set; }
        [JsonProperty("chassis-wwn")]
        [XmlElement("chassis-wwn")]
        public string? ChassisWwn { get; set; }
        [JsonProperty("collectorDate")]
        [XmlElement("collectorDate")]
        public string? CollectorDate { get; set; }
        [XmlElement("ports")]
        public List<Port>? Ports { get; set; }
    }
}