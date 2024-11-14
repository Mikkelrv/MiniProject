using MongoDB.Bson;
using ThriftShopCore.Models;
namespace ThriftShopAPI.Repositories
{
    public interface IUserRepo
    {
        Task<User> GetUser(string email);
        Task<User?> AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(string email);
        void addItemListing(Item item);

    }
}
