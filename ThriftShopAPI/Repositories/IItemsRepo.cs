using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using ThriftShopCore.Models;
namespace ThriftShopAPI.Repositories
{
    public interface IItemsRepo
    {
        void addItem(Item item);
        void deleteItem(string id);
        Task<IEnumerable<Item>> getItems(int maxPrice, int minPrice, string category, string query, string status);
        void updateItem(Item item);
        Task updateStatus(Item item);
    }
}
