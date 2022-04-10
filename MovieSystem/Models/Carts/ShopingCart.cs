namespace MovieSystem.Models.Carts
{
    using Microsoft.EntityFrameworkCore;
    using MovieSystem.Data;
    using MovieSystem.Data.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class ShopingCart
    {
        public MovieSystemDbContext _data { get; set; }

        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public ShopingCart(MovieSystemDbContext data)
        {
            _data = data;
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

            if (shoppingCartItem == null)
            {
                if (shoppingCartItem.Amount>1)
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

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ?? (ShoppingCartItems = _data.ShoppingCartItems.Where(s => s.ShoppingCartId == ShoppingCartId).Include(s => s.Movie).ToList());
        }

        public double GetShoppingCartTotal() => _data.ShoppingCartItems.Where(s => s.ShoppingCartId == ShoppingCartId).Select(s => s.Movie.Price * s.Amount).Sum();
    }
}
