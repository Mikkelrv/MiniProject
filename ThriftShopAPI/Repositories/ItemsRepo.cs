using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using ThriftShopCore.Models;
using MongoDB.Bson;

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
            _collection.InsertOne(item);    
        }

        public void deleteItem(ObjectId id)
        {
            _collection.DeleteOne(item => item._id == id);
        }

        public Item getItem(ObjectId id)
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
