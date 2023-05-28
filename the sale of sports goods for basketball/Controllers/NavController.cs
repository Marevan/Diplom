using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Diagnostics;
using the_sale_of_sports_goods_for_basketball.Models;
using the_sale_of_sports_goods_for_basketball.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace the_sale_of_sports_goods_for_basketball.Controllers
{
    public class NavController : Controller
    {
        private readonly DataContext _db;
        private List<Product> products { get; set; } = new();
        private List<Order> orders { get; set; } = new();

        public NavController(DataContext db)
        {
            _db = db;
        }
        public IActionResult Warehouse()
        {
            products = _db.Products.Where(prod => prod.Amount > 0).ToList();
           
            return View(products);
        }
        public IActionResult Upsert()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Upsert(Product obj)
        {
            if (ModelState.IsValid)
            {
                var product = new Product()
                {
                    Id = 0,
                    Name = obj.Name,
                    Category = obj.Category,
                    Description = obj.Description,
                    Amount = obj.Amount,
                    Price = obj.Price,
                };
                if (product.Id != 0)
                {
                    await _db.Products.AddAsync(product);
                }
                else
                {
                    _db.Products.Update(product);
                }
                await _db.SaveChangesAsync();
                return RedirectToAction("Warehouse", "Nav");
            }
            return null;
        }
        [HttpGet, ActionName("Sale")]
        public async Task<IActionResult> SaleGet(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var products = await _db.Products.FirstOrDefaultAsync(u => u.Id == id);

            if (products == null)
            {
                return NotFound();
            }
            return View(products);
        }

        [HttpPost,ActionName("Sale")]
        public async Task<IActionResult> SalePost(int? id, int amount)
        {
            if (ModelState.IsValid)
            {
                var products = await _db.Products.FirstOrDefaultAsync(u => u.Id == id);

                if (products == null)
                {
                    return NotFound();
                }

                var order = new Order()
                {
                    Product = products,
                    OrderDate = DateTime.Today,
                };
                order.TotalPrice = order.Product.Price * order.Product.Amount;

                _db.Orders.Add(order);
                products.Amount -= amount;
                if (products.Amount < 0)
                {
                    ModelState.AddModelError(string.Empty, "Недостатньо товару на складі");
                    return View("Sale", products);
                }
                await _db.SaveChangesAsync();

                return View("Warehouse");
            }
            return BadRequest(ModelState);
        }
        public IActionResult Record()
        {
            orders = _db.Orders.ToList();
            return View(orders);
        }
        
        //public async Task<IActionResult> Record()
        //{
        //    orders = _db.Orders.ToList();
        //    return View(orders);
        //}
        public IActionResult Report()
        {
            return View();
        }
    }
}