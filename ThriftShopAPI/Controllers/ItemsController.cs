using ThriftShopAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using ThriftShopCore.Models;
using MongoDB.Bson;
namespace ThriftShopAPI.Controllers
{
    [ApiController]
    [Route("api/items")]
    public class ItemsController : ControllerBase
    {
        private readonly IItemsRepo _repository;

        public ItemsController(IItemsRepo repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("get/all")]
        public IActionResult GetItems(Filter filter)
        {
            var items = _repository.getItems(filter);
            return Ok(items);
        }
        [HttpDelete]
        [Route("delete")]
        public IActionResult DeleteItem(string id)
        {
            _repository.deleteItem(id);
            return Ok();
        }

        [HttpPost]
        [Route("add")]
        public IActionResult AddItem(Item item)
        {
            _repository.addItem(item);
            return Ok();
        }

        [HttpPut]
        [Route("update")]

        public IActionResult UpdateItem(string id, Item item)
        {
            _repository.updateItem(item);
            return Ok();
        }

    }
}
