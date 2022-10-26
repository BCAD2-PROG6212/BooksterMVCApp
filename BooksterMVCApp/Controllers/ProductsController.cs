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
    public class ProductsController : Controller
    {
        private readonly BooksterContext _context;

        public ProductsController(BooksterContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
              return View(await _context.Books.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Index(string searchTerm)
        {
            return View(await _context.Books.Where(b =>
            b.BookName.Contains(searchTerm) ||
            b.BookAuthor.Contains(searchTerm)).ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Books == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (book == null)
            {
                return NotFound();
            }

            return View();
        }

        public async Task<IActionResult> AddToCart(int bookId, int qty)
        {
            Book temp = _context.Books.Where(b => b.BookId == bookId).First();
                        
            CartViewModel cartItem = new CartViewModel(bookId, temp.BookName, qty, 
                temp.BookPrice);

            /*
            OrderBook ob = new OrderBook();

            ob.BookId = bookId;
            ob.Quantity = qty;
            */
            CartUtil.cart.Add(cartItem);
        
            return RedirectToAction("Index");
        }
    }
}
