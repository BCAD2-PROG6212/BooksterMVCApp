using System;
using System.Collections.Generic;

namespace BooksterMVCApp.Models
{
    public partial class Delivery
    {
        public int DeliveryId { get; set; }
        public int OrderId { get; set; }
        public int AddressId { get; set; }
        public DateTime DeliveryDate { get; set; }

        public virtual Address Address { get; set; }
        public virtual Order Order { get; set; }
    }
}
