using Data;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.businessLogic
{
    public class OrderProductBusiness
    {
        private GameShopContext context;

        public OrderProductBusiness(GameShopContext context)
        {
            this.context = context;
        }

        public List<OrderProduct> GetAllOrderProducts()
        {
            return context.OrderProducts.ToList();
        }

        public OrderProduct GetOrderProductById(int id)
        {
            return context.OrderProducts.Find(id);
        }

        public string AddOrderProduct(OrderProduct orderProduct)
        {
            context.OrderProducts.Add(orderProduct);
            context.SaveChanges();
            return $"OrderProduct added successfully!";
        }
    }
}
