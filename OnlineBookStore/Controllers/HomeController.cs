using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineBookStore.Models;
using OnlineBookStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookStore.Controllers
{
    public class HomeController : Controller
    {
        private IOnlineBookStoreRepository repo;
        public HomeController(IOnlineBookStoreRepository temp)
        {
            repo = temp;
        }

        public IActionResult Index(int pageNum = 1)
        {
            int pageSize = 10;

            var x = new BooksViewModel
            {
                Books = repo.Books
                .OrderBy(p => p.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumBooks = repo.Books.Count(),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };


            return View(x);
        }
    }
}
