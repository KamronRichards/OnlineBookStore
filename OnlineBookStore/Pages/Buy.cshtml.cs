using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineBookStore.Infastructure;
using OnlineBookStore.Models;

namespace OnlineBookStore.Pages
{
    public class BuyModel : PageModel
    {
        private IOnlineBookStoreRepository repo { get; set; }

        public BuyModel(IOnlineBookStoreRepository temp, Cart c)
        {
            repo = temp;
            cart = c;
        }

        public Cart cart { get; set; }
        public string ReturnUrl { get; set; }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }

        public IActionResult OnPost(int BookId, string returnUrl)
        {
            Book p = repo.Books.FirstOrDefault(x => x.BookId == BookId);

            cart.AddItem(p, 1);

            return RedirectToPage(new { ReturnUrl = returnUrl });

        }

        public IActionResult OnPostRemove(int bookId, string returnUrl)
        {
            cart.RemoveItem(cart.Items.First(x => x.Book.BookId == bookId).Book);

            return RedirectToPage (new {ReturnUrl = returnUrl});
        }
    }
}
