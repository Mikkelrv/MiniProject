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
        public async Task<User> createItem(Item item)
        {
            var response = await http.PostAsJsonAsync("https://localhost:7077/api/items/add", item);
            User? user = null;
            if (response.IsSuccessStatusCode)
            {
                Item storedItem = await response.Content.ReadFromJsonAsync<Item>() ?? null!;
                if (storedItem != null) {
                    user = await localStorage.GetItemAsync<User>("user");
                    user.Selling.Add(storedItem);
                    localStorage.SetItemAsync<User>("user", user);
                }
            }
            return user;
        }

        public async Task<User> deleteItem(Item item)
        {
            var response = await http.PostAsJsonAsync("https://localhost:7077/api/items/delete", item);
            User? user = null;
            if (response.IsSuccessStatusCode)
            {
                Item storedItem = await response.Content.ReadFromJsonAsync<Item>() ?? null!;
                if (storedItem != null)
                {
                    user = await localStorage.GetItemAsync<User>("user");
                    user.Selling.RemoveAll(item => item._id == storedItem._id);
                    localStorage.SetItemAsync<User>("user", user);
                }
            }
            return user;
        }

        public async Task<User> purchaseItem(List<Item> items)
        {
            var response = await http.PostAsJsonAsync("https://localhost:7077/api/items/update/itemlisting", items);
            User? user = null;
            if (response.IsSuccessStatusCode)
            {
                List<Item> storedItems = await response.Content.ReadFromJsonAsync<List<Item>>() ?? null!;
                if (storedItems != null)
                {
                    user = await localStorage.GetItemAsync<User>("user");
                    user.Purchases.Concat(storedItems);
                    localStorage.SetItemAsync<User>("user", user);
                }
            }
            return user;
        }

        public async Task<User> updateItem(Item item)
        {
            throw new NotImplementedException();
        }

        public async Task<User> updateItemStatus(Item item)
        {
            var response = await http.PostAsJsonAsync("https://localhost:7077/api/items/update/itemlisting", item);
            User? user = null;
            if (response.IsSuccessStatusCode)
            {
                Item storedItem = await response.Content.ReadFromJsonAsync<Item>() ?? null!;
                if (storedItem != null)
                {
                    user = await localStorage.GetItemAsync<User>("user");
                    user.Selling.RemoveAll(item => item._id == storedItem._id);
                    user.Selling.Add(item);
                    localStorage.SetItemAsync<User>("user", user);
                }
            }
            return user;
        }
    }
}
