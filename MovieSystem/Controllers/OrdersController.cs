namespace MovieSystem.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MovieSystem.Models.Carts;
    using MovieSystem.Services.Movies;
    using System.Threading.Tasks;

    public class OrdersController : Controller
    {
        private readonly IMoviesService _moviesService;
        private readonly ShopingCart _shopingCart;

        public OrdersController(IMoviesService movieService, ShopingCart shopingCart)
        {
            this._moviesService = movieService;
            this._shopingCart = shopingCart;
        }

        public IActionResult ShopingCart()
        {
            var products = _shopingCart.GetShopingCartItems();
            _shopingCart.ShoppingCartItems = products;

            var response = new ShopingCartViewModel()
            {
                ShopingCart = _shopingCart,
                ShopingCartTotal = _shopingCart.GetShopingCartTotal()
            };

            return View(response);
        }

        public async Task<IActionResult> AddProductToShopingCart(int id)
        {
            var product = await _moviesService.GetMovieByIdAsync(id);

            if (product != null)
            {
                _shopingCart.AddItemToCart(product);
            }

            return RedirectToAction(nameof(ShopingCart));

        }

        public async Task<IActionResult> RemoveProduct(int id)
        {
            var product = await _moviesService.GetMovieByIdAsync(id);

            if (product != null)
            {
                _shopingCart.RemoveItemFromCart(product);
            }

            return RedirectToAction(nameof(ShopingCart));

        }
    }
}
