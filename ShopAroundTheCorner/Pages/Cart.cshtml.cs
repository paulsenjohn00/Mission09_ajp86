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

        public ShoppingCart ShoppingCart { get; set; }
        public string ReturnUrl { get; set; }

        public CartModel(IBookstoreRepository temp, ShoppingCart cart)
        {
            repo = temp;
            ShoppingCart = cart;
        }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }

        public IActionResult OnPost(int bookId, string returnUrl)
        {
            Books b = repo.Books.FirstOrDefault(x => x.BookId == bookId);

            ShoppingCart.AddItem(b, 1, b.Price);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }

        // function associated with the remove button
        public IActionResult OnPostRemove(int bookId, string returnUrl)
        {
            ShoppingCart.RemoveItem(ShoppingCart.Items.First(x => x.Book.BookId == bookId).Book);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }
}
