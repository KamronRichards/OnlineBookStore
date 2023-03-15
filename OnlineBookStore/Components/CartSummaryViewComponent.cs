using Microsoft.AspNetCore.Mvc;
using OnlineBookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookStore.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private Cart Cart;
        public CartSummaryViewComponent(Cart cartService)
        {
            Cart = cartService;
        }
        public IViewComponentResult Invoke()
        {
            return View(Cart);
        }
    }
}
