using MongoDB.Bson;
using MongoDB.Driver;
using ThriftShopCore.Models;

namespace ThriftShopAPI.Repositories
{
    public class UserRepo : IUserRepo
    {
        readonly private IConfiguration _config;
        IMongoClient _mongoClient;
        IMongoDatabase _database;
        IMongoCollection<User> _collection;


        public UserRepo(IConfiguration config)
        {
            _config = config;
            _mongoClient = new MongoClient(_config["ConnectionStrings:mongoDB"]);
            _database = _mongoClient.GetDatabase("ThriftShop");
            _collection = _database.GetCollection<User>("Users");
        }

        public async Task AddItemListing(Item item)
        {
            var userFilter = Builders<User>.Filter.Eq("Email", item.SellerEmail);
            var updatePush = Builders<User>.Update.Push("Selling", item);

            await _collection.UpdateOneAsync(userFilter, updatePush);
        }

        public async Task<User?> AddUser(User user)
        {
            User? response = await _collection.Find(Builders<User>.Filter.Eq("Email", user.Email)).FirstOrDefaultAsync();
            if (response == null)
            {
                _collection.InsertOne(user);
                return user;
            }
            else
                return null;

        }

        public void DeleteUser(string email)
        {
            _collection.DeleteOne(user => user.Email == email);
        }

        public async Task<User> GetUser(string email)
        {
            return await _collection.Find(Builders<User>.Filter.Eq("Email", email)).FirstOrDefaultAsync();
        }

        public void UpdateUser(User updatedUser)
        {
            var filter = Builders<User>.Filter.Eq("Email", updatedUser.Email);
            var update = Builders<User>.Update
                .Set(u => u.Name, updatedUser.Name)
                .Set(u => u.Purchases, updatedUser.Purchases)
                .Set(u => u.Selling, updatedUser.Selling);

            _collection.UpdateOne(filter, update);
        }

        public async Task updateItemListing(Item item) {
            var userFilter = Builders<User>.Filter.Eq("Email", item.SellerEmail);
            var arrayFilter = Builders<User>.Filter.Eq("Selling._id", item._id);
            var combinedFilter = Builders<User>.Filter.And(userFilter, arrayFilter);

            var update = Builders<User>.Update.Set("Selling.$", item);

            await _collection.UpdateOneAsync(combinedFilter, update);

        }
    }
}
