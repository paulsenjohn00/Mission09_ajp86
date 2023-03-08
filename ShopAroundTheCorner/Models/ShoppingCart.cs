using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ShopAroundTheCorner.Models
{
	public class ShoppingCart
	{
		public List<ShoppingCartLineItem> Items { get; set; } = new List<ShoppingCartLineItem>();

		public void AddItem(Books book, int qty, double price)
		{
            ShoppingCartLineItem lineItem = Items
                .Where(b => b.Book.BookId == book.BookId)
                .FirstOrDefault();

            // if the item is not in the cart then create a new item
            if (lineItem == null)
            {
                Items.Add(new ShoppingCartLineItem
                {
                    Book = book,
                    Quantity = qty,
                    Price = price
                });
            }
            // if the line item exists then add to Quantity only
            else
            {
                lineItem.Quantity += qty;
            }
        }

        public string CalculateTotal()
        {
            CultureInfo culture = new CultureInfo("en-US");

            double sum = Items.Sum(x => x.Quantity * x.Price);

            string formattedAmount = sum.ToString("C", culture);

            return formattedAmount;
        }


        public class ShoppingCartLineItem
        {
            public int LineId { get; set; }
            public Books Book { get; set; }
            public int Quantity { get; set; }
            public double Price { get; set; }
        }
    }
}

