using System.Net.Http.Headers;

namespace Sklep_kibica.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
