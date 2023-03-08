using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopAroundTheCorner.Infrastructure;
using ShopAroundTheCorner.Models;

namespace ShopAroundTheCorner.Pages
{
	public class CartModel : PageModel
    {
        private IBookstoreRepository repo { get; set; }

        public CartModel(IBookstoreRepository temp)
        {
            repo = temp;
        }

        public ShoppingCart ShoppingCart { get; set; }
        public string ReturnUrl { get; set; }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            ShoppingCart = HttpContext.Session.GetJson<ShoppingCart>("ShoppingCart") ?? new ShoppingCart();
        }

        public IActionResult OnPost(int bookId, string returnUrl)
        {
            Books b = repo.Books.FirstOrDefault(x => x.BookId == bookId);

            ShoppingCart = HttpContext.Session.GetJson<ShoppingCart>("ShoppingCart") ?? new ShoppingCart();
            ShoppingCart.AddItem(b, 1, b.Price);

            HttpContext.Session.SetJson("ShoppingCart", ShoppingCart);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }
}
