using Microsoft.AspNetCore.Mvc;
using Sklep_kibica.Data;
using Sklep_kibica.Models;
using Sklep_kibica.Repositories;

namespace Sklep_kibica.Controllers
{
    public class ShopController : Controller
    {
        private readonly ShopManager _manager;

        public ShopController(ShopManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index() => View(_manager.GetProducts());

        public IActionResult Add() => View();

        [HttpPost]
        public IActionResult Add(Product product)
        {
            _manager.AddProduct(product);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id) => View(_manager.GetProduct(id));

        [HttpPost]
        public IActionResult Remove(int id)
        {
            _manager.RemoveProduct(id);
            return RedirectToAction("Index");
        }

        public IActionResult AddToCart(int id)
        {
            _manager.AddToCart(id);
            return RedirectToAction("Index");
        }

        public IActionResult AddToCart2(int id)
        {
            _manager.AddToCart(id);
            return RedirectToAction("Cart");
        }

        public IActionResult RemoveFromCart(int id)
        {
            _manager.RemoveFromCart(id);
            return RedirectToAction("Cart");
        }

        public IActionResult Cart() => View(_manager.GetCart());

        [HttpPost]
        public IActionResult Finalize()
        {
            var cart = _manager.GetCart();
            _manager.FinalizeCart();
            return View("Finalize", cart);
        }

        [HttpPost]
        public IActionResult ClearCart()
        {
            _manager.ClearCart();
            return RedirectToAction("Cart");
        }


    }
}
