namespace MovieSystem.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MovieSystem.Models.Carts;
    using MovieSystem.Services.Movies;
    using MovieSystem.Services.Orders;
    using System.Threading.Tasks;

    public class OrdersController : Controller
    {
        private readonly IMoviesService _moviesService;
        private readonly ShopingCart _shopingCart;
        private readonly IOrdersService _ordersService;

        public OrdersController(IMoviesService movieService, ShopingCart shopingCart, IOrdersService ordersService)
        {
            this._moviesService = movieService;
            this._shopingCart = shopingCart;
            this._ordersService = ordersService;
        }

        public async Task<IActionResult> Index()
        {
            string userId = "";

            var orders = await _ordersService.GetOrdersByUserIdAsync(userId);

            return View(orders);
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

        public async Task<IActionResult> CompleteOrder()
        {
            var products = _shopingCart.GetShopingCartItems();

            string userId = "";
            string userEmailAddress = "";

            await _ordersService.StoreOrderAsync(products, userId, userEmailAddress);
            await _shopingCart.ClearShopingCartAsync();

            return View("OrderPurchased");
        }
    }
}
