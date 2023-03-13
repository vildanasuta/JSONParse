using Newtonsoft.Json;
using System.Text.Json;

namespace JSONParseClass
{
    public class Device
    {
        [JsonProperty("deviceName")]
        public string DeviceName { get; set; }
        [JsonProperty("manufacturer")]
        public string Manufacturer { get; set; }
        [JsonProperty("part-number")]
        public string PartNumber { get; set; }
        [JsonProperty("serial-number")]
        public string SerialNumber { get; set; }
        [JsonProperty("product-name")]
        public string ProductName { get; set; }
        [JsonProperty("vendor-part-number")]

        public string VendorPartNumber { get; set; }
        [JsonProperty("vendor-serial-number")]

        public string VendorSerialNumber { get; set; }
        [JsonProperty("license-id")]

        public string LicenseId { get; set; }
        [JsonProperty("chassis-wwn")]

        public string ChassisWwn { get; set; }
        [JsonProperty("collectorDate")]

        public string CollectorDate { get; set; }
        public List<Port> Ports { get; set; }
    }
}