using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShopAroundTheCorner.Models;
using ShopAroundTheCorner.Models.ViewModels;

namespace ShopAroundTheCorner.Controllers
{
    public class HomeController : Controller
    {
        private IBookstoreRepository repo;

        public HomeController(IBookstoreRepository temp)
        {
            repo = temp;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult BookList(string bookCategory, int pageNum = 1)
        {
            // sets the number of books per page
            int pageSize = 10;
            // gathers content needed for the pages and sends through the view
            var pageContent = new BooksViewModel
            {
                Books = repo.Books
                .Where(b => b.Category == bookCategory || bookCategory == null)
                .OrderBy(b => b.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumBooks =
                    (bookCategory == null
                    ? repo.Books.Count()
                    : repo.Books.Where(pageContent => pageContent.Category == bookCategory).Count()),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };
            // sends pageContent through the view
            return View(pageContent);
        }




        public IActionResult Privacy()
        {
            return View();
        }
    }
}

