using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Diagnostics;
using the_sale_of_sports_goods_for_basketball.Models;

namespace the_sale_of_sports_goods_for_basketball.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext _appContext;

        public HomeController(ILogger<HomeController> logger,DataContext appContext)
        {
            _logger = logger;
            _appContext = appContext; 
        }

        public IActionResult Index()
        {
            //System.Net.Dns.GetHostAddressesAsync(hostName);
            var products = _appContext.Products.ToList();
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