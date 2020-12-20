using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Models;

namespace Shop.Controllers
{
    public class CartController : Controller
    {
        private Models.ApplicationContext db;
        public CartController(Models.ApplicationContext context)
        {

            db = context;

        }

        public IActionResult Index()

        {

            Cart cart = new Cart();

            if (HttpContext.Session.Keys.Contains("Cart"))//Проверяем есть ли сохранённая корзина у пользователя

                cart = JsonSerializer.Deserialize<Cart>(HttpContext.Session.GetString("Cart")); //десериализируем корзину из сессии

            return View(cart);

        }

        public IActionResult AddToCart()

        {

            int ID = Convert.ToInt32(Request.Query["ID"]); // Получаем ID из строки

            Cart cart = new Cart();

            if (HttpContext.Session.Keys.Contains("Cart"))//Проверяем есть ли сохранённая корзина у пользователя

                cart = JsonSerializer.Deserialize<Cart>(HttpContext.Session.GetString("Cart")); //десериализируем корзину из сессии

            cart.CartLines.Add(db.Products.Find(ID)); //Добавляем в корзину элемент Product по первичному ключу

            HttpContext.Session.SetString("Cart", JsonSerializer.Serialize<Cart>(cart)); // Сохраняем новую корзину в сессию

            return Redirect("/"); //Возвращение пользователя на первоначальную страницу

        }

        public IActionResult RemoveFromCart()

        {

            int number = Convert.ToInt32(Request.Query["Number"]); // Получаем номер позиции в корзине

            Cart cart = new Cart();

            if (HttpContext.Session.Keys.Contains("Cart")) // Проверяем есть ли сохранённая корзина у пользователя

                cart = JsonSerializer.Deserialize<Cart>(HttpContext.Session.GetString("Cart")); // десериализируем корзину из сессии

            cart.CartLines.RemoveAt(number); // Удаляем товар из корзины но индексу

            HttpContext.Session.SetString("Cart", JsonSerializer.Serialize<Cart>(cart)); // Сохраняем новую корзину в сессию

            return Redirect("/Cart"); //Возвращение пользователя на страницу с корзиной

        }
    }
}
