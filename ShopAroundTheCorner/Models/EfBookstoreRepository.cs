using System;
using System.Linq;

namespace ShopAroundTheCorner.Models
{
	public class EfBookstoreRepository : IBookstoreRepository
	{
		private BookstoreContext context { get; set; }

		public EfBookstoreRepository(BookstoreContext temp)
		{
			context = temp;
		}

		public IQueryable<Books> Books => context.Books;
	}
}

