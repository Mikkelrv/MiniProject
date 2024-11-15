using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ThriftShopCore.Models

{
    public class Item
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? _id { get; set; }
        public required string Name { get; set; }
        public required double Price { get; set; }
        public required string Description { get; set; }
        public required string Category { get; set; }
        public required string ImageUrl { get; set; }
        public required DateTime Listed { get; set; } = DateTime.Now;
        public required string Status { get; set; } = "Active";
        public required string SellerEmail { get; set; }
        public DateTime? SoldTime { get; set; }
        public string? BuyerEmail { get; set; }
    }
}
