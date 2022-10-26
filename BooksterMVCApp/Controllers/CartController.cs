using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BooksterMVCApp.Models;
using BooksterMVCApp.Utils;

namespace BooksterMVCApp.Controllers
{
    public class CartController : Controller
    {
        public IActionResult ViewCart()
        {
            return View(CartUtil.cart);
        }
        
    }
}
