using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThriftShopCore.Models
{
    public class ImgurResponse
    {
        public required ImgurData Data { get; set; }
    }

    public class ImgurData
    {
        public required string Link { get; set; }
    }
}
