namespace MovieSystem.Models.ViewComponents.Carts
{
    using Microsoft.AspNetCore.Mvc;
    using MovieSystem.Models.Carts;

    public class ShopingCartSumViewCompon : ViewComponent
    {
        private readonly ShopingCart _shopingCart;

        public ShopingCartSumViewCompon(ShopingCart shopingCart)
        {
            this._shopingCart = shopingCart;
        }

        public IViewComponentResult Invoke()
        {
            var items = _shopingCart.GetShopingCartItems();

            return View(items.Count);
        }
    }
}
