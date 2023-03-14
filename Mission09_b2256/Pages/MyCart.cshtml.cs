using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mission09_b2256.Infrastructure;
using Mission09_b2256.Models;

namespace Mission09_b2256.Pages
{
    public class PurchaseModel : PageModel
    {
        private IBookRepository repo { get; set; }
        public Basket basket { get; set; }
        public string ReturnUrl { get; set; }
        public PurchaseModel(IBookRepository temp, Basket b)
        {
            repo = temp;
            basket = b;
        }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }
        public IActionResult OnPost(int bookID, string returnUrl)
        {
            Books p = repo.Book.FirstOrDefault(x => x.BookId == bookID);
            basket.AddItem(p, 1);


            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
        public IActionResult OnPostRemove(int BookId, string returnUrl)
        {
            basket.RemoveItem(basket.Items.First(x => x.Book.BookId == BookId).Book);
            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }
}
