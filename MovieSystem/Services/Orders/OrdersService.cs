namespace MovieSystem.Services.Orders
{
    using Microsoft.EntityFrameworkCore;
    using MovieSystem.Data;
    using MovieSystem.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class OrdersService : IOrdersService
    {
        private readonly MovieSystemDbContext _data;

        public OrdersService(MovieSystemDbContext data)
        {
            _data = data;
        }

        public Task<List<Order>> GetOrdersByUserIdAsync(string userId)
        {
            var orders = _data.Orders.Include(o => o.OrderItems).ThenInclude(o => o.Movie).Where(o => o.UserId == userId).ToListAsync();
        }

        public Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAdress)
        {
            throw new NotImplementedException();
        }
    }
}
