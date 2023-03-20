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
            using (StreamReader streamReader = new StreamReader(path))
            {
                string line;
                string match="^IP Address";
                Regex regex = new Regex(match);
                while ((line = streamReader.ReadLine()) != null)
                {
                    if (regex.IsMatch(line))
                    {
                        isIpListSection = true;
                        continue;
                    }
                    if (isIpListSection)
                    {
                        string[] fields = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        if (fields.Length >= 6)
                        {
                            IPInfo iPInfo = new IPInfo();
                            iPInfo.IPAddress = fields[0];
                            iPInfo.NIC = fields[1];
                            iPInfo.Status = fields[2];
                            iPInfo.Type = fields[3];
                            iPInfo.Array = fields[4];
                            iPInfo.Controller = fields[5];
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
