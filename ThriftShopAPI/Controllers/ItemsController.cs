﻿using ThriftShopAPI.Repositories;
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

        public ItemsController(IItemsRepo repository)
        {
            _repository = repository;
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
