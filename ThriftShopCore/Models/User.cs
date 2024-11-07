using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThriftShopCore.Models
{
    public class User
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public List<Item> Purchases { get; set; } = new();
        public List<Item> Selling { get; set; } = new();
    }
}
