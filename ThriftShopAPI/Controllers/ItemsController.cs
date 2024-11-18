using ThriftShopAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using ThriftShopCore.Models;
using MongoDB.Bson;
using System.Collections;
namespace ThriftShopAPI.Controllers
{
    [ApiController]
    [Route("api/items")]
    public class ItemsController : ControllerBase
    {
        private readonly IItemsRepo _repository;
        private readonly IUserRepo _userRepo;

        public ItemsController(IItemsRepo repository, IUserRepo userRepo)
        {
            _repository = repository;
            _userRepo = userRepo;
        }

        [HttpGet]
        [Route("get/all")]
        public async Task<IEnumerable<Item>> GetItems([FromQuery] Filter filter)
        {
            var items = await _repository.getItems(filter.MaxPrice, filter.MinPrice, filter.Category, filter.Query, filter.Status);
            if (items == null) {
                throw new Exception("List is null");
            }
            if (items.Count() == 0) {
                throw new Exception("List is empty");
            }

            return items;
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
            _userRepo.AddItemListing(item);
            return Ok(item);
        }

        [HttpPost]
        [Route("queryfilter")]
        public async Task<IEnumerable<Item>> getItemsByFilter(Filter filter)
        {
            var items = await _repository.getItems(filter.MaxPrice, filter.MinPrice, filter.Category, filter.Query, filter.Status);
            return items;
        }

        [HttpPost]
        [Route("update")]
        public IActionResult UpdateItem(Item item)
        {
            _repository.updateItem(item);
            _userRepo.updateItemListing(item);
            return Ok(item);
        }

        [HttpPut]
        [Route("update/itemstatus")]
        public async Task<IActionResult> UpdateItemListing(Item item) {
            Console.WriteLine("I was called");
            await _repository.updateStatus(item);
            await _userRepo.updateItemListing(item);
            return Ok(item);
        }

        [HttpPost]
        [Route("purchase")]
        public async Task<IActionResult> UpdateItemPurchase(List<Item> items)
        {
            foreach (var item in items)
            {
                await _repository.updateItem(item);
                await _userRepo.updateItemListing(item);
                await _userRepo.addItemPurchase(item);
            }
            return Ok(items);
        }

    }
}
