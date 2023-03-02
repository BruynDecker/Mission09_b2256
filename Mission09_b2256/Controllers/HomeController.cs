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
        private readonly ILogger<HomeController> _logger;

        private BookstoreContext blahContext { get; set; }

        public HomeController(ILogger<HomeController> logger, BookstoreContext daContext)
        {
            _logger = logger;
            blahContext = daContext;
        }



        public IActionResult Index(int page = 1)
        {
            const int PageSize = 10;

            var books = blahContext.Books
                .OrderBy(b => b.BookId)
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .ToList();

            return View(books);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
