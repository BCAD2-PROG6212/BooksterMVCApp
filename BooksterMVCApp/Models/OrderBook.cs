using System;
using System.Collections.Generic;

namespace BooksterMVCApp.Models
{
    public partial class OrderBook
    {
        public int BookOrderId { get; set; }
        public int OrderId { get; set; }
        public int BookId { get; set; }
        public decimal ItemPrice { get; set; }
        public int Quantity { get; set; }

        public virtual Book Book { get; set; }
        public virtual Order Order { get; set; }
    }
}
