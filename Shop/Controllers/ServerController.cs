using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Shop.Controllers
{
    public class ServerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult Post()
        {
            ViewBag.Message = "Вы в системе";
            return View("Index");
        }
    }
}
