using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;

namespace SportsStore.Pages
{
    public class CartModel : PageModel
    {
        private readonly IStoreRepository repository;
        public CartModel(IStoreRepository repo, Cart cartService)
        {
            repository = repo;
            Cart = cartService;
        }
        public Cart Cart {get; set;}
        public string ReturnUrl {get; set;} = "/";
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }
        public IActionResult OnPost(long productId, string returnUrl)
        {
            Product? product = repository.Products
                .Where(p => p.ProductId == productId)
                .FirstOrDefault();

            if (product != null)
            {
                Cart.AddItem(product, 1);
            }

            return RedirectToPage(new { returnUrl });
        }
        public IActionResult OnPostRemove(long productId, string returnUrl)
        {
            Cart.RemoveLine(Cart.Lines.First(p => p.Product.ProductId == productId).Product);
            return RedirectToPage(new {returnUrl});
        }
    }
}