using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Diagnostics;
using the_sale_of_sports_goods_for_basketball.Models;
using the_sale_of_sports_goods_for_basketball.Data;

namespace the_sale_of_sports_goods_for_basketball.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext _db;

        public HomeController(ILogger<HomeController> logger, DataContext db)
        {
            _logger = logger;
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CreateAccountModel obj)
        {
            if (ModelState.IsValid)
            {
                var client = new Client()
                {
                    Id = 0,
                    FirstName = obj.FirstName,
                    LastName = obj.LastName,
                    Email = obj.Email,
                    Password=obj.Password,
                };
                if (client.Id == 0)
                {
                    await _db.Clients.AddAsync(client);
                }
                else
                {
                    _db.Clients.Update(client);
                }

                await _db.SaveChangesAsync();
                return RedirectToAction("Login","Account");
            }
            return null;
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