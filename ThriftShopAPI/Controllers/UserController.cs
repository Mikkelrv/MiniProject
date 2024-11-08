using Microsoft.AspNetCore.Mvc;
using ThriftShopAPI.Repositories;

namespace ThriftShopAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IUserRepo _userRepo;
        public UserController(IUserRepo userRepo)
        {
            _userRepo = userRepo;

        }

    }
}
