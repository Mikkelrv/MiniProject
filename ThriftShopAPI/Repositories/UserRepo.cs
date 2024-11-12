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

        public void DeleteUser(string id)
        {
            _collection.DeleteOne(user => user._id == id);
        }

        public User GetUser(string id)
        {
            return _collection.Find(user => user._id == id).FirstOrDefault();
        }

        public void UpdateUser(User user)
        {
            _collection.ReplaceOne(user => user._id == user._id, user);
        }
    }
}
