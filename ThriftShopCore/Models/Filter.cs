using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThriftShopCore.Models
{
    public class Filter
    {
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }
        public string Category { get; set; }
        public string Query { get; set; }
        public string Status { get; set; }
    }
}
