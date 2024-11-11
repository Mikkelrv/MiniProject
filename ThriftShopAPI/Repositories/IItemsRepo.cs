using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using ThriftShopCore.Models;
namespace ThriftShopAPI.Repositories
{
    public interface IItemsRepo
    {
        void addItem(Item item);
        void deleteItem(ObjectId id);
        List<Item> getItems(Filter filter);
        Item getItem(ObjectId id);
        void updateItem(Item item);
    }
}
