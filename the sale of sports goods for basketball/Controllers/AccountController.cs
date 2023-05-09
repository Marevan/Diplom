using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Diagnostics;
using the_sale_of_sports_goods_for_basketball.Models;
using the_sale_of_sports_goods_for_basketball.Data;

namespace the_sale_of_sports_goods_for_basketball.Controllers
{
    public class AccountController : Controller
    {
        private readonly DataContext _db;
        public AccountController(DataContext db)
        {
            _db = db;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginAccountModel obj)
        {
            if (ModelState.IsValid)
            {
                foreach (var a in _db.Clients)
                {
                    if (a.Email == obj.Email && a.Password == obj.Password)
                    {
                        var options = new CookieOptions
                        {
                            Expires = DateTime.Now.AddDays(7),
                            IsEssential = true,
                            SameSite = SameSiteMode.None
                        };

                        Response.Cookies.Append("Email", obj.Email, options);
                        Response.Cookies.Append("Password", obj.Password, options);

                        return RedirectToAction("Warehouse", "Nav");
                    }
                }
            }

            return RedirectToAction("Login", "Account");
        }

        public IActionResult Client()
        {
            return View();
        }
    }
}