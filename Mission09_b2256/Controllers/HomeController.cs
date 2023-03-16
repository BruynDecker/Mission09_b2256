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
        private IBookRepository repo; // Declare an instance variable for the repository.

        // Create a constructor that takes an IBookRepository parameter and assigns it to the instance variable.
        public HomeController(IBookRepository temp)
        {
            repo = temp;
        }

        // Define an action method called "Index" that accepts a string parameter "cateGory" and an optional integer parameter "pagenum".
        public IActionResult Index(string cateGory, int pagenum = 1)
        {
            int pageSize = 5; // Set the number of items to display per page.

            // Create a ProjectsViewModel object that contains a subset of the books in the repository based on the specified category and page number.
            var x = new ProjectsViewModel
            {
                Book = repo.Book // Get all books from the repository.
                .Where(b => b.Category == cateGory || cateGory == null) // Filter the books based on the category parameter (if specified).
                .OrderBy(b => b.Title)
                .Skip(((pagenum) - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumProjects = 
                        (cateGory == null 
                            ? repo.Book.Count() 
                            : repo.Book.Where(x => x.Category == cateGory).Count()),
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
