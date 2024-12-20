﻿using MongoDB.Bson;
using ThriftShopCore.Models;
namespace ThriftShopAPI.Repositories
{
    public interface IUserRepo
    {
        Task<User> GetUser(string email);
        Task<User?> AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(string email);
        public Task AddItemListing(Item item);
        public Task updateItemListing(Item item);
        public Task addItemPurchase(Item item);

    }
}
