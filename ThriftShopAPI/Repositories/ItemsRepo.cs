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

        public void deleteItem(string id)
        {
            _collection.DeleteOne(item => item._id == id);
        }

        public List<Item> getItems(Filter filter)
        {
            var minPriceFilter = Builders<Item>.Filter.Gte(item => item.Price, filter.MinPrice);
            var maxPriceFilter = Builders<Item>.Filter.Lte(item => item.Price, filter.MaxPrice);
            var categoryFilter = Builders<Item>.Filter.Eq(item => item.Category, filter.Category);
            var statusFilter = Builders<Item>.Filter.Eq(item => item.Status, filter.Status);
            var queryFilterName = Builders<Item>.Filter.Regex(item => item.Name, new BsonRegularExpression(filter.Query, "i"));
            var queryFilterDescription = Builders<Item>.Filter.Regex(item => item.Description, new BsonRegularExpression(filter.Query, "i"));

            var totalFilter = Builders<Item>.Filter.Empty;
            if (filter.MinPrice != 0)
            {
                totalFilter = Builders<Item>.Filter.And(totalFilter, minPriceFilter);
            }
            if (filter.MaxPrice != 0) {
                totalFilter = Builders<Item>.Filter.And(totalFilter, maxPriceFilter);
            }
            if (filter.Category != null)
            {
                totalFilter = Builders<Item>.Filter.And(totalFilter, categoryFilter);
            }
            if (filter.Status != null)
            {
                totalFilter = Builders<Item>.Filter.And(totalFilter, statusFilter);
            }
            if (filter.Query != null)
            {
                totalFilter = Builders<Item>.Filter.And(totalFilter, Builders<Item>.Filter.Or(queryFilterName, queryFilterDescription));
            }

            return _collection.Find(totalFilter).ToList();


        }

        public void updateItem(Item item)
        {
            var filter = Builders<Item>.Filter.Eq(i => i._id, item._id);
            _collection.ReplaceOne(filter, item);
        }
    }
}
