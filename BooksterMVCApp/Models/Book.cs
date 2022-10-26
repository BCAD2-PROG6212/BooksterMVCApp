using System;
using System.Collections.Generic;

namespace BooksterMVCApp.Models
{
    public partial class Book
    {
        public Book()
        {
            OrderBooks = new HashSet<OrderBook>();
        }

        public int BookId { get; set; }
        public string BookName { get; set; }
        public string BookAuthor { get; set; }
        public decimal BookPrice { get; set; }
        public int BookRating { get; set; }

        public virtual ICollection<OrderBook> OrderBooks { get; set; }
    }
}
