using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Parsing
{
    public class ParseTXTFile
    {
        public static string Parse(string path)
        {
            List<IPInfo> iPInfoList = new List<IPInfo>();
            bool isIpListSection = false;
            Regex regex = new Regex(@"^(\S+)\s+(\S+)\s+(\S+)\s+(\S+)\s+(\S+)\s+(\S+)$");
            using (StreamReader streamReader = new StreamReader(path))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    if (line.StartsWith("IP Address"))
                    {
                        isIpListSection = true;
                        continue;
                    }
                    if (isIpListSection)
                    {
                        Match match = regex.Match(line);
                        if (match.Success)
                        {
                            IPInfo iPInfo = new IPInfo();
                            iPInfo.IPAddress = match.Groups[1].Value;
                            iPInfo.NIC = match.Groups[2].Value;
                            iPInfo.Status = match.Groups[3].Value;
                            iPInfo.Type = match.Groups[4].Value;
                            iPInfo.Array = match.Groups[5].Value;
                            iPInfo.Controller = match.Groups[6].Value;
                            iPInfoList.Add(iPInfo);
                        }
                    }
                }
            }

            StringBuilder sb = new StringBuilder();
            foreach (IPInfo iPInfo in iPInfoList)
            {
                sb.AppendLine($"IP Address: {iPInfo.IPAddress}");
                sb.AppendLine($"NIC: {iPInfo.NIC}");
                sb.AppendLine($"Status: {iPInfo.Status}");
                sb.AppendLine($"Type: {iPInfo.Type}");
                sb.AppendLine($"Array: {iPInfo.Array}");
                sb.AppendLine($"Controller: {iPInfo.Controller}");
                sb.AppendLine();
            }

            return sb.ToString();
        }


    }
}
