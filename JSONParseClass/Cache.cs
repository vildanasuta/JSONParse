using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsing
{
    public class Cache
    {

        public Cache(string? module, string? label, string? cmgSize, string? cacheSize, string? smSize, string? residencySize)
        {
            ModuleNumber = module;
            Label = label;
            CMGSize = cmgSize;
            CacheSize = cacheSize;
            SMSize = smSize;
            CacheResidencySize = residencySize;
        }

        [Name("Module#")]
        public string? ModuleNumber {get;set;}
        [Name("Label")]
        public string? Label { get; set; }
        [Name("CMG Size(GB)")]
        public string? CMGSize { get; set; }
        [Name("Cache Size(GB)")]
        public string? CacheSize { get; set; }
        [Name("SM Size(GB)")]
        public string? SMSize { get; set; }
        [Name("Cache Residency Size(MB)")]
        public string? CacheResidencySize { get; set; }
    }
}
