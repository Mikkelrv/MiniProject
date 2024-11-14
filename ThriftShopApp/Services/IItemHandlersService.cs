using ThriftShopCore.Models;

namespace ThriftShopApp.Services
{
    public interface IItemHandlersService
    {
        public Task createItem(Item item);
        public void updateItem(Item item);
        public void updateItemStatus(Item item);
        public void purchaseItem(Item item);
        public void deleteItem(Item item);
    }
}
