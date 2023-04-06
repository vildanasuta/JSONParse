using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Parsing
{
    public class ParseJSONFile
    {
        public static Device Parse(string path)
        {
            string jsonString = File.ReadAllText(path);
            Device device = JsonConvert.DeserializeObject<Device>(jsonString);
            return device;
        }
        public static string ParseDevice(string path)
        {
            var device = Parse(path);
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
        public static string ParsePorts(Device device) {
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
        public static string ParsePeople(string path)
        {
            string jsonString = File.ReadAllText(path);
            JObject jsonObject = JObject.Parse(jsonString);
            JArray peopleArray = (JArray)jsonObject["people"];
            string parsedPeople = "";
            foreach (JObject personObject in peopleArray)
            {
                string parsedPerson = $"First name: {personObject["firstName"]}\r\n" +
                                      $"Last name: {personObject["lastName"]}\r\n" +
                                      $"Gender: {personObject["gender"]}\r\n" +
                                      $"Age: {personObject["age"]}\r\n" +
                                      $"Number: {personObject["number"]}\r\n";
                parsedPeople += parsedPerson;
                parsedPeople += "\r\n";
            }
            return parsedPeople;
        }
        public static string ParsePeopleRegexImpl(string path)
        {
            string jsonString = File.ReadAllText(path);
            string pattern = "\"firstName\":\\s*\"(?<firstName>[^\"]+)\",\\s*\"lastName\":\\s*\"(?<lastName>[^\"]+)\",\\s*\"gender\":\\s*\"(?<gender>[^\"]+)\",\\s*\"age\":\\s*(?<age>[0-9]+),\\s*\"number\":\\s*\"(?<number>[^\"]+)\"";
            MatchCollection matches = Regex.Matches(jsonString, pattern);
            string parsedPeople = "";
            foreach (Match match in matches)
            {
                string parsedPerson = $"First name: {match.Groups["firstName"].Value}\r\n" +
                                      $"Last name: {match.Groups["lastName"].Value}\r\n" +
                                      $"Gender: {match.Groups["gender"].Value}\r\n" +
                                      $"Age: {match.Groups["age"].Value}\r\n" +
                                      $"Number: {match.Groups["number"].Value}\r\n";
                parsedPeople += parsedPerson;
                parsedPeople += "\r\n";
            }
            return parsedPeople;
        }
    }
}
