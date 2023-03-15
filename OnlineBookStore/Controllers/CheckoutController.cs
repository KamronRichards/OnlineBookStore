using Microsoft.AspNetCore.Mvc;
using OnlineBookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookStore.Controllers
{
    public class CheckoutController : Controller
    {
        private ICheckoutRepository repo { get; set; }
        private Cart cart { get; set; }
        public CheckoutController(ICheckoutRepository temp, Cart c)
        {
            repo = temp;
            cart = c;
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new Checkout());
        }

        [HttpPost]
        public IActionResult Checkout(Checkout checkout)
        {
            if(cart.Items.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty");
            }

            if (ModelState.IsValid)
            {
                checkout.Carts = cart.Items.ToArray();
                repo.SaveCheckout(checkout);
                cart.ClearCart();

                return RedirectToPage("/CheckoutComplete");
            }
            else
            {
                return View();
            }
        }
    }
}
