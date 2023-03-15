using System;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using ShopAroundTheCorner.Infrastructure;

namespace ShopAroundTheCorner.Models
{
	public class SessionShoppingCart : ShoppingCart
	{
        public static ShoppingCart GetShoppingCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            SessionShoppingCart shoppingCart = session?.GetJson<SessionShoppingCart>("ShoppingCart") ?? new SessionShoppingCart();

            shoppingCart.Session = session;

            return shoppingCart;
        }

		[JsonIgnore]
		public ISession Session { get; set; }

        public override void AddItem(Books book, int qty, double price)
        {
            base.AddItem(book, qty, price);
            Session.SetJson("ShoppingCart", this);
        }

        public override void RemoveItem(Books book)
        {
            base.RemoveItem(book);
            Session.SetJson("ShoppingCart", this);
        }

        public override void ClearShoppingCart()
        {
            base.ClearShoppingCart();
            Session.Remove("ShoppingCart");
        }
    }
}

