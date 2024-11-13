using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ThriftShopCore.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? _id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public List<Item> Purchases { get; set; } = new();
        public List<Item> Selling { get; set; } = new();

        public required string Password { get; set; }
    }
}
