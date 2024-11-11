using MongoDB.Bson;
using ThriftShopCore.Models;
namespace ThriftShopAPI.Repositories
{
    public interface IUserRepo
    {
        User GetUser(ObjectId id);
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(ObjectId id);

    }
}
