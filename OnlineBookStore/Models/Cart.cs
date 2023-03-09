using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookStore.Models
{
    public class Cart
    {
        public List<BookCartItem> Items { get; set; } = new List<BookCartItem>();

        public void AddItem(Book book, int qty)
        {
            BookCartItem cart = Items
                .Where(p => p.Book.BookId == book.BookId)
                .FirstOrDefault();

            if (cart == null)
            {
                Items.Add(new BookCartItem
                {
                    Book = book,
                    Quantity = qty
                });
            }
            else
            {
                cart.Quantity += qty;
            }
        }

        public double CalculateTotal()
        {
            double sum = Items.Sum(x => x.Quantity * x.Book.Price);

            return sum;
        }
    }


    public class BookCartItem
    {
        public int CartID { get; set; }
        public Book Book { get; set; }
        public int Quantity { get; set; }
    }
}

