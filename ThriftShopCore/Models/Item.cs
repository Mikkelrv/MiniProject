namespace ThriftShopCore.Models

{
    public class Item
    {
        public required string Name { get; set; }
        public required double Price { get; set; }
        public required string Description { get; set; }
        public required string ImageUrl { get; set; }
        public required DateTime Listed { get; set; } = DateTime.Now;
        public required Status Status { get; set; }
        public required string SellerEmail { get; set; }
        public DateTime? SoldTime { get; set; } 

    }
}
