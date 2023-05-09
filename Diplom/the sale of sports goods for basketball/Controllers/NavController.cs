using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Diagnostics;
using the_sale_of_sports_goods_for_basketball.Models;

namespace the_sale_of_sports_goods_for_basketball.Controllers
{
    public class NavController : Controller
    {
        public IActionResult Warehouse()
        {
            return View();
        }
        public IActionResult Report()
        {
            return View();
        }
    }
}