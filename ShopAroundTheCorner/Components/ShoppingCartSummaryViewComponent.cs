using System;
using Microsoft.AspNetCore.Mvc;
using ShopAroundTheCorner.Models;

namespace ShopAroundTheCorner.Components
{
	public class ShoppingCartSummaryViewComponent : ViewComponent
	{
		private ShoppingCart shoppingCart;

        public ShoppingCartSummaryViewComponent(ShoppingCart shoppingCartService)
        {
            shoppingCart = shoppingCartService;
        }

        public IViewComponentResult Invoke()
        {
            return View(shoppingCart);
        }
    }

}

