using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;

namespace SportsStore.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        public CartSummaryViewComponent(Cart cartService)
        {
            cart = cartService;
        }
        public Cart cart;
        public IViewComponentResult Invoke()
        {
            return View(cart);
        }
    }
}