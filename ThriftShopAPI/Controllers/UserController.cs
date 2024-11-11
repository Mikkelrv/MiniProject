using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using ThriftShopAPI.Repositories;
using ThriftShopCore.Models;

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

        [HttpGet]
        [Route("get/{id : string}")]
        public IActionResult GetUser(ObjectId id)
        {
            var user = _userRepo.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPut]
        [Route("update/{user : User}")]
        public IActionResult UpdateUser(User user)
        {
            _userRepo.UpdateUser(user);
            return Ok();
        }
        [HttpDelete]
        [Route("delete/{id : string}")]
        public IActionResult DeleteUser(ObjectId id)
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
