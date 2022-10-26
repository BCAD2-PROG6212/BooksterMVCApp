using MessagePack;

namespace BooksterMVCApp.ViewModels
{
    public class CartViewModel
    {
        public int cartItemId { get; set; }
        public int bookId { get; set; }
        public string BookName { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }

        public CartViewModel(int bookId, string bookName, int qty, decimal price)
        {
            this.bookId = bookId;
            BookName = bookName;
            Qty = qty;
            Price = price;
        }
    }
}
