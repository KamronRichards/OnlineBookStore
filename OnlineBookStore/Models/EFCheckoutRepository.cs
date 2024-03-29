﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookStore.Models
{
    public class EFCheckoutRepository : ICheckoutRepository
    {
        private BookstoreContext context;
        public EFCheckoutRepository (BookstoreContext temp)
        {
            context = temp;
        }
        public IQueryable<Checkout> Checkouts => context.Checkouts.Include(x => x.Carts).ThenInclude(x => x.Book);

        public void SaveCheckout(Checkout checkout)
        {
            context.AttachRange(checkout.Carts.Select(x => x.Book));

            if(checkout.CheckoutId == 0)
            {
                context.Checkouts.Add(checkout);
            }

            context.SaveChanges();
        }
    }
}
