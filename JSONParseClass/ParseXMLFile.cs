using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace JSONParseClass
{
    public class ParseXMLFile
    {
        public static string ParseDevice(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Device));
            Device? device;

            using (StreamReader reader = new StreamReader(path))
            {
                device = serializer.Deserialize(reader) as Device;
            }

            string parsed = $"Device Name: {device.DeviceName}\r\n" +
                       $"Manufacturer: {device.Manufacturer}\r\n" +
                       $"Part Number: {device.PartNumber}\r\n" +
                       $"Serial Number: {device.SerialNumber}\r\n" +
                       $"Product Name: {device.ProductName}\r\n" +
                       $"Vendor Part Number: {device.VendorPartNumber}\r\n" +
                       $"Vendor Serial Number: {device.VendorSerialNumber}\r\n" +
                       $"License ID: {device.LicenseId}\r\n" +
                       $"Chassis Wwn: {device.ChassisWwn}\r\n" +
                       $"Collector Date: {device.CollectorDate}\r\n\r\n" +
                       "Ports:\r\n";
            parsed += ParsePorts(device);
            return parsed;

        }
        public static string ParsePorts(Device device)
        {
            int n = 0;
            string parsedPort = " ";
            foreach (Port port in device.Ports)
            {
                parsedPort += ++n + ".\r\n" + $"Wwpn: {port.Wwpn}\r\n" +
                        $"Wwnn: {port.Wwnn}\r\n" +
                        $"Domain ID: {port.DomainId}\r\n" +
                        $"Fc ID: {port.FcId}\r\n" +
                        $"Port Name: {port.PortName}\r\n" +
                        $"Port Number: {port.PortNumber}\r\n" +
                        $"Firmware Version: {port.FirmwareVersion}\r\n" +
                        $"Serial Number: {port.SerialNumber}\r\n\r\n";
            }
            return parsedPort;
        }
    }
}
