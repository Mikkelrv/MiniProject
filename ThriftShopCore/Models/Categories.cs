using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThriftShopCore.Models
{

    public class Categories
    {
        public List<string> CategoriesList { get; set; } = new() { "Clothing", "Electronics", "Furniture", "Books", "Miscellaneous" };
    }

}
