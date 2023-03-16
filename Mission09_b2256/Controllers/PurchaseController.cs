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
        private IPurchaseRepository repo { get; set; }
        private Basket basket { get; set; }
        public PurchaseController(IPurchaseRepository temp, Basket b)
        {
            repo = temp;
            basket = b;
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new Cart());
        }
        [HttpPost]
        public IActionResult Checkout(Cart cart)
        {
            if (basket.Items.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your basket's empty!");

            }
            if (ModelState.IsValid)
            {
                cart.Lines = basket.Items.ToArray();
                repo.SavePurchase(cart);
                basket.ClearBasket();

                return RedirectToPage("/Completion");
            }
            else
            {
                return View();
            }
        }
    }
}
