using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ShopAroundTheCorner.Models;

namespace ShopAroundTheCorner.Components
{
	public class CategoriesViewComponent : ViewComponent
	{
		private IBookstoreRepository repo { get; set; }

		public CategoriesViewComponent(IBookstoreRepository temp)
		{
			repo = temp;
		}

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedType = RouteData?.Values["bookCategory"];

            var categories = repo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

            return View(categories);
        }
    }
}

