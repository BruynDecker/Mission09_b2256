using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_b2256.Models
{
    public class EFPurchaseRepository : IPurchaseRepository
    {
        private BookstoreContext context;
        public EFPurchaseRepository(BookstoreContext temp)
        {
            context = temp;
        }
        public IQueryable<Cart> Cart => context.Carts.Include(x => x.Lines).ThenInclude(x => x.Book);

        public void SavePurchase(Cart cart)
        {
            context.AttachRange(cart.Lines.Select(x => x.Book));

            if (cart.DonationId == 0)
            {
                context.Carts.Add(cart);
            }
            context.SaveChanges();
        }
    }
}
