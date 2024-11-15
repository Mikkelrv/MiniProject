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
            if (id != null) _collection.DeleteOne(item => item._id == id);
        }

        public async Task<IEnumerable<Item>> getItems(int maxPrice, int minPrice, string category, string query, string status)
        {
            var filterList = new List<FilterDefinition<Item>>();

            if (minPrice > 0)
            {
                filterList.Add(Builders<Item>.Filter.Gte(item => item.Price, minPrice));
            }

            if (maxPrice > 0)
            {
                filterList.Add(Builders<Item>.Filter.Lte(item => item.Price, maxPrice));
            }

            if (!string.IsNullOrEmpty(category))
            {
                filterList.Add(Builders<Item>.Filter.Eq(item => item.Category, category));
            }

            if (!string.IsNullOrEmpty(status))
            {
                filterList.Add(Builders<Item>.Filter.Eq(item => item.Status, status));
            }

            if (!string.IsNullOrEmpty(query))
            {
                var queryFilter = Builders<Item>.Filter.Or(
                    Builders<Item>.Filter.Regex(item => item.Name, new BsonRegularExpression(query, "i")),
                    Builders<Item>.Filter.Regex(item => item.Description, new BsonRegularExpression(query, "i"))
                );
                filterList.Add(queryFilter);
            }

            var totalFilter = filterList.Count > 0 ? Builders<Item>.Filter.And(filterList) : Builders<Item>.Filter.Empty;

            var items = await _collection.Find(totalFilter).ToListAsync();

            return items;
        }

        public void updateItem(Item item)
        {
            var filter = Builders<Item>.Filter.Eq(i => i._id, item._id);
            _collection.ReplaceOne(filter, item);
        }

        public async Task updateStatus(Item item) {
            var userFilter = Builders<Item>.Filter.Eq("_id", item._id);
            var updatePush = Builders<User>.Update.Push("Status", item.Status);
        }
    }
}
