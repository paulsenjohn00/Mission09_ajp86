using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ShopAroundTheCorner.Models
{
	public class EfPurchaseRepository : IPurchaseRepository
	{
        private BookstoreContext context;

		public EfPurchaseRepository(BookstoreContext temp)
		{
            context = temp;
		}

        public IQueryable<Purchase> Purchases => context.Purchases
            .Include(x => x.Lines)
            .ThenInclude(x => x.Book);

        public void SavePurchase(Purchase purchase)
        {
            context.AttachRange(purchase.Lines.Select(x => x.Book));

            if (purchase.purchaseId == 0)
            {
                context.Purchases.Add(purchase);
            }

            context.SaveChanges();
        }
    }
}

