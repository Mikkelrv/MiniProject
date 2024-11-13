using ThriftShopCore.Models;

namespace ThriftShopApp.Services
{

    public interface ILoginService
    {
        // If a user is logged in, the user will be returned.
        // If no user is logged in, null will be returned
        Task<User?> GetUserLoggedIn();

        // If user is valid the function will return true and the
        // user is set to be logged in.
        void Login(User user);

        void Logout();
    }
}

