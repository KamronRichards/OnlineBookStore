using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookStore.Models.ViewModels
{
    public class PageInfo
    {
        public int TotalNumBooks { get; set; }
        public int BooksPerPage { get; set; }
        public int CurrentPage { get; set; }

        //Figure put ow many pages we need
        public int TotalPages => (int)Math.Ceiling((double)TotalNumBooks / BooksPerPage);
    }
}
