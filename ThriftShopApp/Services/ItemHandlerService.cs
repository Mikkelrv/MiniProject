using Blazored.LocalStorage;
using System.Net.Http.Json;
using ThriftShopCore.Models;
using static System.Net.WebRequestMethods;

namespace ThriftShopApp.Services
{
    public class ItemHandlerService : IItemHandlersService
    {
        public ILocalStorageService localStorage { get; set; }
        public HttpClient http { get; set; }

        public ItemHandlerService(ILocalStorageService localStorage, HttpClient http)
        {
            this.localStorage = localStorage;
            this.http = http;
        }
        public async Task createItem(Item item)
        {
            var response = await http.PostAsJsonAsync("https://localhost:7077/api/items/add", item);
            if (response.IsSuccessStatusCode)
            {
                Item storedItem = await response.Content.ReadFromJsonAsync<Item>() ?? null!;
                if (storedItem != null) {
                    var user = await localStorage.GetItemAsync<User>("user");
                    user.Selling.Add(storedItem);
                }
            }
        }

        public void deleteItem(Item item)
        {
            throw new NotImplementedException();
        }

        public void purchaseItem(Item item)
        {
            throw new NotImplementedException();
        }

        public void updateItem(Item item)
        {
            throw new NotImplementedException();
        }

        public void updateItemStatus(Item item)
        {
            throw new NotImplementedException();
        }
    }
}
