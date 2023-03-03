using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission09_b2256.Models;
using Mission09_b2256.Models.ViewModels;
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

        public IActionResult Index(int pagenum =1)
        {
            int pageSize = 5;

            var x = new ProjectsViewModel
            {
                Book = repo.Book
                .OrderBy(b => b.Title)
                .Skip(((pagenum) - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumProjects = repo.Book.Count(),
                    ProjectsPerPage = pageSize,
                    CurrentPage = pagenum

                }
            };

            return View(x);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
