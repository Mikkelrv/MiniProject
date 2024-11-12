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
            var filterList = new List<FilterDefinition<Item>>();

            if (filter.MinPrice > 0)
            {
                filterList.Add(Builders<Item>.Filter.Gte(item => item.Price, filter.MinPrice));
            }

            if (filter.MaxPrice > 0)
            {
                filterList.Add(Builders<Item>.Filter.Lte(item => item.Price, filter.MaxPrice));
            }

            if (!string.IsNullOrEmpty(filter.Category))
            {
                filterList.Add(Builders<Item>.Filter.Eq(item => item.Category, filter.Category));
            }

            if (!string.IsNullOrEmpty(filter.Status))
            {
                filterList.Add(Builders<Item>.Filter.Eq(item => item.Status, filter.Status));
            }

            if (!string.IsNullOrEmpty(filter.Query))
            {
                var queryFilter = Builders<Item>.Filter.Or(
                    Builders<Item>.Filter.Regex(item => item.Name, new BsonRegularExpression(filter.Query, "i")),
                    Builders<Item>.Filter.Regex(item => item.Description, new BsonRegularExpression(filter.Query, "i"))
                );
                filterList.Add(queryFilter);
            }

            var totalFilter = filterList.Count > 0 ? Builders<Item>.Filter.And(filterList) : Builders<Item>.Filter.Empty;

            return _collection.Find(totalFilter).ToList();
        }

        public void updateItem(Item item)
        {
            var filter = Builders<Item>.Filter.Eq(i => i._id, item._id);
            _collection.ReplaceOne(filter, item);
        }
    }
}
