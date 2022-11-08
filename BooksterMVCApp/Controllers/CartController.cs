using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BooksterMVCApp.Models;
using BooksterMVCApp.Utils;
using BooksterMVCApp.ViewModels;

namespace BooksterMVCApp.Controllers
{
    public class CartController : Controller
    {
        private readonly BooksterContext _context;

        public CartController(BooksterContext context)
        {
            _context = context;
        }

        public IActionResult ViewCart()
        {
            return View(CartUtil.cart);
        }
        
        public IActionResult Checkout(string CurrentUser, decimal OrderTotal)
        {
            Customer c = _context.Customers.Where(cust => cust.CustomerEmail.Equals(CurrentUser)).First();
            Address a = _context.Addresses.Where(addr => addr.CustomerId.Equals(c.CustomerId)).First();

            CheckoutViewModel checkout = new CheckoutViewModel(c.CustomerId, c.CustomerName,
                c.CustomerSurname, c.CustomerEmail, c.CustomerPhone, a.AddressId,
                a.AddressLineOne, a.AddressLineTwo, a.City, a.PostCode, CartUtil.cart);

            return View(checkout);

        }

        public IActionResult ConfirmOrder(string CurrentUser, decimal OrderTotal)
        {
            Customer c = _context.Customers.Where(cust => cust.CustomerEmail.Equals(CurrentUser)).First();
            Address a = _context.Addresses.Where(addr => addr.CustomerId.Equals(c.CustomerId)).First();

            Order o = new Order();
            o.CustomerId = c.CustomerId;
            o.OrderTotal = OrderTotal;
            o.OrderDate = DateTime.Now;
            o.PaymentStatus = "Complete";

            _context.Orders.Add(o);
            _context.SaveChanges();

            Order writtenOrder = _context.Orders.Where(ord => ord.CustomerId.Equals(c.CustomerId)).OrderBy(sort => sort.OrderId).Last();

            Delivery del = new Delivery();
            del.OrderId = writtenOrder.OrderId;
            del.AddressId = a.AddressId;
            del.DeliveryDate = DateTime.Today.AddDays(5);
            _context.Deliveries.Add(del);

            foreach (var cartItem in CartUtil.cart)
            {
                OrderBook ob = new OrderBook();
                ob.OrderId = writtenOrder.OrderId;
                ob.BookId = cartItem.bookId;
                ob.ItemPrice = cartItem.Price;
                ob.Quantity = cartItem.Qty;
                _context.OrderBooks.Add(ob);
            }

            _context.SaveChanges();
            return View();
        }
    }
}
