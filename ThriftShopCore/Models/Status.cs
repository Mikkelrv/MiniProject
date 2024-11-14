using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThriftShopCore.Models
{
    public class Status
    {
       public List<string> StatusList { get; set; } = new() { "Sold", "Active", "Inactive", "Reserved" };
    }
}
