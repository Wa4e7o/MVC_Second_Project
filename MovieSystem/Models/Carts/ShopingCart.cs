namespace MovieSystem.Models.Carts
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using MovieSystem.Data;
    using MovieSystem.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ShopingCart
    {
        public MovieSystemDbContext _data { get; set; }

        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public ShopingCart(MovieSystemDbContext data)
        {
            _data = data;
        }

        public static ShopingCart GetShopingCart(IServiceProvider services)
        {
            //With this method we get session data with service provider.
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<MovieSystemDbContext>();

            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);

            return new ShopingCart(context) { ShoppingCartId = cartId };
        }

        public void AddItemToCart(Movie movie)
        {
            var shoppingCartItem = _data.ShoppingCartItems.FirstOrDefault(s => s.Movie.Id == movie.Id && s.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem()
                {
                    ShoppingCartId = ShoppingCartId,
                    Movie = movie,
                    Amount = 1
                };

                _data.ShoppingCartItems.Add(shoppingCartItem);
            }

            else
            {
                shoppingCartItem.Amount++;
            }

            _data.SaveChanges();
        }

        public void RemoveItemFromCart(Movie movie)
        {
            var shoppingCartItem = _data.ShoppingCartItems.FirstOrDefault(s => s.Movie.Id == movie.Id && s.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                }

                else
                {
                    _data.ShoppingCartItems.Remove(shoppingCartItem);
                }

            }

            _data.SaveChanges();
        }

        public List<ShoppingCartItem> GetShopingCartItems()
        {
            return ShoppingCartItems ?? (ShoppingCartItems = _data.ShoppingCartItems.Where(s => s.ShoppingCartId == ShoppingCartId).Include(s => s.Movie).ToList());
        }

        public double GetShopingCartTotal() => _data.ShoppingCartItems.Where(s => s.ShoppingCartId == ShoppingCartId).Select(s => s.Movie.Price * s.Amount).Sum();

        public async Task ClearShopingCartAsync()
        {
            var items = await _data.ShoppingCartItems.Where(m => m.ShoppingCartId == ShoppingCartId).ToListAsync();
            _data.ShoppingCartItems.RemoveRange(items);
            await _data.SaveChangesAsync();
        }
    }
}
