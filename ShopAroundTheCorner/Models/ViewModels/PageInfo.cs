using System;
namespace ShopAroundTheCorner.Models.ViewModels
{
	public class PageInfo
	{
        public int TotalNumBooks { get; set; }
        public int BooksPerPage { get; set; }
        public int CurrentPage { get; set; }

        // find the total number of pages needed
        public int TotalPages => (int)Math.Ceiling((double)TotalNumBooks / BooksPerPage);
    }
}

