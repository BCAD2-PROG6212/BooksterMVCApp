using System;
using System.Collections.Generic;

namespace BooksterMVCApp.Models
{
    public partial class Address
    {
        public Address()
        {
            Deliveries = new HashSet<Delivery>();
        }

        public int AddressId { get; set; }
        public int CustomerId { get; set; }
        public string AddressLineOne { get; set; }
        public string AddressLineTwo { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<Delivery> Deliveries { get; set; }
    }
}
