using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopAroundTheCorner.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShopAroundTheCorner.Controllers
{
    public class PurchaseController : Controller
    {
        private IPurchaseRepository repository { get; set; }
        private ShoppingCart shoppingCart { get; set; }

        public PurchaseController(IPurchaseRepository temp, ShoppingCart cart)
        {
            repository = temp;
            shoppingCart = cart;
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new Purchase());
        }

        [HttpPost]
        public IActionResult Checkout(Purchase purchase)
        {
            if (shoppingCart.Items.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty");
            }

            // if the model state is valid redirect to the order complete page
            if (ModelState.IsValid)
            {
                purchase.Lines = shoppingCart.Items.ToArray();
                repository.SavePurchase(purchase);
                shoppingCart.ClearShoppingCart();

                return RedirectToPage("/PurchaseComplete");
            }
            else
            {
                return View();
            }           
        }
    }
}

