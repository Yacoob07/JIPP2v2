using System.IO;
using Microsoft.EntityFrameworkCore;
using Sklep_kibica.Data;
using Sklep_kibica.Models;

namespace Sklep_kibica.Repositories
{
    public class ShopManager
    {
        private ShopContext _context;
        public ShopManager(ShopContext context) 
        { 
            _context = context;
        }

        public List<Product> GetProducts() => _context.Products.ToList();

        public Product GetProduct(int id) => _context.Products.FirstOrDefault(p => p.ID == id);

        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void RemoveProduct(int id)
        {
            var product = GetProduct(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }

        public void UpdateProduct(Product product)
        {
            var existing = GetProduct(product.ID);
            if (existing != null)
            {
                existing.Name = product.Name;
                existing.Price = product.Price;
                existing.Quantity = product.Quantity;
                _context.SaveChanges();
            }
        }

        public void AddToCart(int productId)
        {
            var product = GetProduct(productId);
            if (product == null || product.Quantity == 0) return;

            var cartItem = _context.CartItems.FirstOrDefault(c => c.ProductId == productId);
            if (cartItem != null)
            {
                if (cartItem.Quantity < product.Quantity)
                    cartItem.Quantity++;
            }
            else
            {
                _context.CartItems.Add(new CartItem { ProductId = productId, Quantity = 1 });
            }
            _context.SaveChanges();
        }

        public void RemoveFromCart(int productId)
        {
            var item = _context.CartItems.FirstOrDefault(c => c.ProductId == productId);
            if (item != null)
            {
                if (item.Quantity > 1)
                    item.Quantity--;
                else
                    _context.CartItems.Remove(item);

                _context.SaveChanges();
            }
        }

        public List<CartItem> GetCart() => _context.CartItems.Include(c => c.Product).ToList();

        public void FinalizeCart()
        {
            var items = GetCart();
            foreach (var item in items)
            {
                item.Product.Quantity -= item.Quantity;
            }
            _context.CartItems.RemoveRange(items);
            _context.SaveChanges();
        }

        public void ClearCart()
        {
            _context.CartItems.RemoveRange(_context.CartItems);
            _context.SaveChanges();
        }
    }
}