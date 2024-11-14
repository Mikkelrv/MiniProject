using ThriftShopCore.Models;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;

namespace ThriftShopApp.Services
{
    public class LoginServiceImpl : ILoginService
    {
        public ILocalStorageService localStorage { get; set; }

        public LoginServiceImpl(ILocalStorageService localStorage)
        {
            this.localStorage = localStorage;
        }
        public async Task<User?> GetUserLoggedIn()
        {
            var res = await localStorage.GetItemAsync<User>("user");
            return res;
        }

        public async Task Login(User user)
        {
            await localStorage.SetItemAsync("user", user);
        }

        public async Task Logout()
        {
            await localStorage.ClearAsync();
        }
    }
}
