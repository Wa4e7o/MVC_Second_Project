namespace MovieSystem.Services.Orders
{
    using MovieSystem.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IOrdersService
    {
        Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAdress);
        Task<List<Order>> GetOrdersByUserIdAsync(string userId);
    }
}
