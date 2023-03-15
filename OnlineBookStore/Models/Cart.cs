using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookStore.Models
{
    public class Cart
    {
        public List<BookCartItem> Items { get; set; } = new List<BookCartItem>();

        public virtual void AddItem(Book book, int qty)
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

        public virtual void RemoveItem (Book book)
        {
            Items.RemoveAll(x => x.Book.BookId == book.BookId);
        }

        public virtual void ClearCart()
        {
            Items.Clear();
        }
        public double CalculateTotal()
        {
            double sum = Items.Sum(x => x.Quantity * x.Book.Price);

            return sum;
        }
    }


    public class BookCartItem
    {
        [Key]
        public int CartID { get; set; }
        public Book Book { get; set; }
        public int Quantity { get; set; }
    }
}

