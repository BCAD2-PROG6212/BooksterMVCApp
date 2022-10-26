using BooksterMVCApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace BooksterMVCApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            // Add to cart
            // 0. Check if the cart session variable already exists
            // 0.1. If it does, deserialize the list
            // 1. Make the object
            // 2. Add object to the list
            // 3. Serialise the list
            // 4. Add to session variable

            HttpContext.Session.SetString("Test", "EB Rules!");
            ViewBag.Message = HttpContext.Session.GetString("Test");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}