using ThriftShopCore.Models;
namespace ThriftShopAPI.Repositories
{
    public interface IItemsRepo
    {
        void addItem(Item item);
        void deleteItem(string id);
        List<Item> getItems(Filter filter);
        Item getItem(string id);
        void updateItem(Item item);
    }
}
