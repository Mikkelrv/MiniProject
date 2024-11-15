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
        public string? Category { get; set; } = null;
        public string? Query { get; set; } = null;
        public string? Status { get; set; } = null;
    }
}
