using System;
using System.Linq;

namespace ShopAroundTheCorner.Models.ViewModels
{
	public class BooksViewModel
	{
		//books and page info can be brought in using only one model
		public IQueryable<Books> Books { get; set; }
		public PageInfo PageInfo { get; set; }
	}
}

