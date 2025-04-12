
using System.Collections.Generic;

namespace Data.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int TypeProductId { get; set; }
        public TypeProduct TypeProduct { get; set; }
        public string Company { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public ICollection<OrderProduct> ProductOrders { get; set; }
    }
}
