using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace Parsing
{
    public class ParseHTMLFile
    {
        public static string Parse(string path)
        {
            HtmlDocument doc = new HtmlDocument();
            doc.Load(path);
            HtmlNode node = doc.DocumentNode.SelectSingleNode("//a[@name='showsysd']");
            string text = node?.NextSibling.InnerText.Trim();

            string info = "";
            string[] lines = text.Split('\n');

            foreach (string line in lines)
            {
                if (line.Contains("System Name"))
                {
                    string value = line.Substring(line.IndexOf(":") + 1).Trim();
                    info += "System Name: " + value + "\r\n";
                }
                else if (line.Contains("System Model"))
                {
                    string value = line.Substring(line.IndexOf(":") + 1).Trim();
                    info += "System Model: " + value + "\r\n";
                }
                else if (line.Contains("System ID"))
                {
                    string value = line.Substring(line.IndexOf(":") + 1).Trim();
                    info += "System ID: " + value + "\r\n";
                }
                else if (line.Contains("Chunklet Size"))
                {
                    string value = line.Substring(line.IndexOf(":") + 1).Trim();
                    info += "Chunklet Size: " + value + "\r\n";
                }
                else if (line.Contains("Total Capacity"))
                {
                    string value = line.Substring(line.IndexOf(":") + 1).Trim();
                    info += "Total Capacity: " + double.Parse(value)/1000 + " GB" + "\r\n";
                }
                else if (line.Contains("Free Capacity"))
                {
                    string value = line.Substring(line.IndexOf(":") + 1).Trim();
                    info += "Free Capacity: " + double.Parse(value) / 1000 + " GB" + "\r\n";
                }
            }

            return info;
        }

    }


}
