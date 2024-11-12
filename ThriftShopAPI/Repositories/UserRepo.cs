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
        public void AddUser(User user)
        {
            _collection.InsertOne(user);
        }

        public void DeleteUser(string email)
        {
            _collection.DeleteOne(user => user.Email == email);
        }

        public User GetUser(string email)
        {
            return _collection.Find(user => user.Email == email).FirstOrDefault();
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
    }
}
