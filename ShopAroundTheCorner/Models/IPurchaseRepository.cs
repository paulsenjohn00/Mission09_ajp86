using System;
using System.Linq;

namespace ShopAroundTheCorner.Models
{
	public interface IPurchaseRepository
	{
		public IQueryable<Purchase> Purchases { get; }

		void SavePurchase(Purchase purchase);
	}
}

