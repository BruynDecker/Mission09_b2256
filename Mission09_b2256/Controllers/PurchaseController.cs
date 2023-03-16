using Microsoft.AspNetCore.Mvc;
using Mission09_b2256.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_b2256.Controllers
{
    public class PurchaseController : Controller
    {
        private IPurchaseRepository repo { get; set; } // Dependency injection of IPurchaseRepository
        private Basket basket { get; set; } // Dependency injection of Basket

        public PurchaseController(IPurchaseRepository temp, Basket b)
        {
            repo = temp;
            basket = b;
        }

        [HttpGet] // HttpGet attribute indicates that this method handles GET requests
        public IActionResult Checkout()
        {
            return View(new Cart()); // Displays Checkout view with a new instance of Cart object
        }

        [HttpPost] // HttpPost attribute indicates that this method handles POST requests
        public IActionResult Checkout(Cart cart)
        {
            if (basket.Items.Count() == 0) // Check if the basket is empty
            {
                ModelState.AddModelError("", "Sorry, your basket's empty!"); // Add a model error message
            }

            if (ModelState.IsValid) // If model state is valid, proceed with the purchase
            {
                cart.Lines = basket.Items.ToArray(); // Assign items in the basket to the cart
                repo.SavePurchase(cart); // Save the purchase to the repository
                basket.ClearBasket(); // Clear the basket

                return RedirectToPage("/Completion"); // Redirect to the Completion page
            }
            else // If model state is invalid, redisplay the Checkout view
            {
                return View();
            }
        }
    }
}

//This is a PurchaseController class that handles purchase-related requests. It has two action methods:

//1. `Checkout` -a GET method that displays a view to the user with a new instance of `Cart` object.
//2. `Checkout` -a POST method that processes the form data submitted by the user.
