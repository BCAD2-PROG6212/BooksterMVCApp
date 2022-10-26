using System;
using System.Collections.Generic;

namespace BooksterMVCApp.Models
{
    public partial class Order
    {
        public Order()
        {
            Deliveries = new HashSet<Delivery>();
            OrderBooks = new HashSet<OrderBook>();
        }

        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public decimal OrderTotal { get; set; }
        public DateTime OrderDate { get; set; }
        public string PaymentStatus { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<Delivery> Deliveries { get; set; }
        public virtual ICollection<OrderBook> OrderBooks { get; set; }
    }
}
