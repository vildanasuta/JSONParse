using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using CsvHelper;
using System.Formats.Asn1;
using System.Globalization;
using CsvHelper.Configuration;
using System.Reflection.PortableExecutable;
using System.Text.RegularExpressions;

namespace Parsing
{
    public class ParseCSVFile
    {
        public static string Parse(string path)
        {
            List<Cache> cacheList = new List<Cache>();

            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                bool isInsideCacheSection = false;
                Regex regex = new Regex("^Module#");
                Regex regex1 = new Regex("^Cache Memory");
                while (csv.Read())
                {
                    if (regex.IsMatch(csv.GetField<string>(0)))
                    {
                        isInsideCacheSection = true;
                    }
                    else if (isInsideCacheSection)
                    {
                        var module = csv.GetField<string>(0) == "" ? " " : csv.GetField<string>(0);
                        var label = csv.GetField<string>(1) == "" ? " " : csv.GetField<string>(1);
                        var cmgSize = csv.GetField<string>(2) == "" ? " " : csv.GetField<string>(2);
                        var cacheSize = csv.GetField<string>(3) == "" ? " " : csv.GetField<string>(3);
                        var smSize = csv.GetField<string>(4) == "" ? " " : csv.GetField<string>(4);
                        var residencySize = csv.GetField<string>(5) == "" ? " " : csv.GetField<string>(5);
                        var cache = new Cache(module, label, cmgSize, cacheSize, smSize, residencySize);
                        cacheList.Add(cache);

                        if (!regex1.IsMatch(csv.GetField<string>(1)))
                        {
                            isInsideCacheSection = false;
                        }
                    }
                }
            }
            StringBuilder sb = new StringBuilder();
            foreach (Cache cache in cacheList)
            {
                sb.AppendLine($"Module number: {cache.ModuleNumber}\r\n" +
                    $"Label: {cache.Label}\r\n" +
                    $"CMG size: {cache.CMGSize}\r\n" +
                    $"Cache size: {cache.CacheSize}\r\n" +
                    $"SM size: {cache.SMSize}\r\n" +
                    $"Cache Residency Size: {cache.CacheResidencySize}\r\n");
            }
            return sb.ToString();
        }
    }
}
