using MongoDB.Driver;
using ThriftShopCore.Models;

namespace ThriftShopAPI.Repositories
{
    
    public class ItemsRepo : IItemsRepo
    {
        readonly private IConfiguration _config;
        IMongoClient _mongoClient;
        IMongoDatabase _database;
        IMongoCollection<Item> _collection;


        public ItemsRepo(IConfiguration config)
        {
            _config = config;
            _mongoClient = new MongoClient(_config["ConnectionStrings:mongoDB"]);
            _database = _mongoClient.GetDatabase("ThriftShop");
            _collection = _database.GetCollection<Item>("Items");
        }
        public void addItem(Item item)
        {
            throw new NotImplementedException();
        }

        public void deleteItem(string id)
        {
            throw new NotImplementedException();
        }

        public Item getItem(string id)
        {
            throw new NotImplementedException();
        }

        public List<Item> getItems(Filter filter)
        {
            throw new NotImplementedException();
        }

        public void updateItem(Item item)
        {
            throw new NotImplementedException();
        }
    }
}
