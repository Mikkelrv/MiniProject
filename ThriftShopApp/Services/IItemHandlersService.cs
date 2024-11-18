using ThriftShopCore.Models;

namespace ThriftShopApp.Services
{
    public interface IItemHandlersService
    {
        public Task<User> createItem(Item item);
        public Task<User> updateItem(Item item);
        public Task<User> updateItemStatus(Item item);
        public Task<User> purchaseItems(List<Item> items);
        public Task<User> deleteItem(Item item);
        public Task<List<Item>> getItems(Filter filter);
    }
}
