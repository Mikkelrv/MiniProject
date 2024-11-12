using MongoDB.Bson;
using ThriftShopCore.Models;
namespace ThriftShopAPI.Repositories
{
    public interface IUserRepo
    {
        User GetUser(string email);
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(string email);

    }
}
