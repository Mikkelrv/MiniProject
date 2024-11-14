using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThriftShopCore.Models
{
    public class Filter
    {
        public int MinPrice { get; set; } = 0;
        public int MaxPrice { get; set; } = 0;
        public string Category { get; set; } = string.Empty;
        public string Query { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }
}
