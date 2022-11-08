namespace BooksterMVCApp.ViewModels
{
    public class CheckoutViewModel
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }

        public int AddressId { get; set; }
        public string AddressLineOne { get; set; }
        public string AddressLineTwo { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }

        public List<CartViewModel> cart { get; set; }

        public CheckoutViewModel(int customerId, string customerName, string customerSurname, string customerEmail, string customerPhone, int addressId, string addressLineOne, string addressLineTwo, string city, string postCode, List<CartViewModel> cart)
        {
            CustomerId = customerId;
            CustomerName = customerName;
            CustomerSurname = customerSurname;
            CustomerEmail = customerEmail;
            CustomerPhone = customerPhone;
            AddressId = addressId;
            AddressLineOne = addressLineOne;
            AddressLineTwo = addressLineTwo;
            City = city;
            PostCode = postCode;
            this.cart = cart;
        }
    }
}
