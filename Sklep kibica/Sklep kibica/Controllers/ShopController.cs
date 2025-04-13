using Microsoft.AspNetCore.Mvc;
using Sklep_kibica.Data;
using Sklep_kibica.Models;

namespace Sklep_kibica.Controllers
{
    public class ShopController : Controller
    {
        private ShopContext _context;
        public ShopController(ShopContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var produkt = new ShopModel();
            produkt.ID = 0;
            produkt.Name = "Koszulka";
            produkt.Price = 299;
            produkt.Amount = 100;
            _context.Shops.Add(produkt);
            _context.SaveChanges();

            return View();
        }
    }
}
