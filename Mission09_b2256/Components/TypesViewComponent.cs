using Microsoft.AspNetCore.Mvc;
using Mission09_b2256.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_b2256.Components
{
    //This is a class that derives from "ViewComponent", which is used to render a partial view.
    //This component will render a list of book categories.
    public class TypesViewComponent : ViewComponent
    {
        //The blah property is an instance of the IBookRepository interface, which represents a collection of books.
        //This property is set via dependency injection in the constructor.
        private IBookRepository blah { get; set; }

        //The constructor takes an instance of IBookRepository as a parameter and assigns it to the blah property.
        public TypesViewComponent(IBookRepository temp)
        {
            blah = temp;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedType = RouteData?.Values["cateGory"];
            // Selects all the categories from the Book repository and sorts them alphabetically
            var types = blah.Book
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

            // Passes the list of categories to the view for rendering
            return View(types);
        }
    }
}

