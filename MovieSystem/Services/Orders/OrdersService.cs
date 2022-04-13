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

        public async Task<List<Order>> GetOrdersByUserIdAsync(string userId)
        {
            var orders = await _data.Orders.Include(o => o.OrderItems).ThenInclude(o => o.Movie).Where(o => o.UserId == userId).ToListAsync();

            return orders;
        }

        public async Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAdress)
        {
            var order = new Order()
            {
                UserId = userId,
                Email = userEmailAdress
            };

            await _data.Orders.AddAsync(order);

            await _data.SaveChangesAsync();

            foreach (var item in items)
            {
                var orderItem = new OrderItem()
                {
                    Amount = item.Amount,
                    Price = item.Movie.Price,
                    MovieId = item.Movie.Id,
                    OrderId = order.Id
                };

                await _data.OrderItems.AddAsync(orderItem);
            }

            await _data.SaveChangesAsync();
        }
    }
}
