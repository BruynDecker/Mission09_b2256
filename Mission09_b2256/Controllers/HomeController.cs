using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission09_b2256.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_b2256.Controllers
{
    public class HomeController : Controller
    {
        private IBookRepository repo;

        public HomeController (IBookRepository temp)
        {
            repo = temp;
        }

        public IActionResult Index(int page = 1)
        {
            int PageSize = 5;

            var x = repo.Book.ToList();

            //var books = repo.Book
                //.OrderBy(b => b.BookId)
                //.Skip((page - 1) * PageSize)
                //.Take(PageSize)
               // .ToList();

            return View(x);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
