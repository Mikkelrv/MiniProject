using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using ThriftShopAPI.Repositories;
using ThriftShopCore.Models;

namespace ThriftShopAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private IUserRepo _userRepo;
        public UserController(IUserRepo userRepo)
        {
            _userRepo = userRepo;

        }

        [HttpGet]
        [Route("get")]
        public IActionResult GetUser(string id)
        {
            var user = _userRepo.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPut]
        [Route("update")]
        public IActionResult UpdateUser(User user)
        {
            _userRepo.UpdateUser(user);
            return Ok();
        }
        [HttpDelete]
        [Route("delete")]
        public IActionResult DeleteUser(string id)
        {
            _userRepo.DeleteUser(id);
            return Ok();
        }
        [HttpPost]
        [Route("add")]
        public IActionResult AddUser(User user)
        {
            _userRepo.AddUser(user);
            return Ok();
        }

    }
}
