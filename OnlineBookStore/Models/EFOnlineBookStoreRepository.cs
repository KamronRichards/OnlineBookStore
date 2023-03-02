using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookStore.Models
{
    public class EFOnlineBookStoreRepository : IOnlineBookStoreRepository
    {
        private BookstoreContext context { get; set; }
        public EFOnlineBookStoreRepository(BookstoreContext temp)
        {
            context = temp;
        }
        public IQueryable<Book> Books => context.Books;
    }
}
