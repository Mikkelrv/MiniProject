using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using ThriftShopCore.Models;
namespace ThriftShopAPI.Repositories
{
    public interface IItemsRepo
    {
        void addItem(Item item);
        void deleteItem(string id);
        List<Item> getItems(Filter filter);
        void updateItem(Item item);
    }
}
