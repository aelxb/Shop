using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Shop.Models;

namespace Shop.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public ApplicationContext db;
        public HomeController(ApplicationContext context)
        {
            this.db = context;
        }
        public async Task<IActionResult> Korzina()
        {
            return View(await db.Products.ToListAsync());
        }
        public async Task<IActionResult> Product(int id)
        {
            return View(await db.Products.FindAsync(id));
        }

        public IActionResult About()
        {
            ViewData["Message"] = "ООО 'Рога и копыта'";
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "О нас";
            return View();
        }
        public IActionResult LCab()
        {
            ViewBag.Message = "Личный кабинет";

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
