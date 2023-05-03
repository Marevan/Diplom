using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Diagnostics;
using the_sale_of_sports_goods_for_basketball.Models;

namespace the_sale_of_sports_goods_for_basketball.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Client()
        {
            return View();
        }
    }
}