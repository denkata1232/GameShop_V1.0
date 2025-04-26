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

        public string UpdateOrderProduct(OrderProduct orderProduct)
        {
            OrderProduct orderProductToUpdate = context.OrderProducts.Find(orderProduct.OrderId);
            if (orderProductToUpdate != null)
            {
                context.Entry(orderProductToUpdate).CurrentValues.SetValues(orderProduct);
                context.SaveChanges();
                return $"OrderProduct updated successfully!";
            }
            return $"OrderProduct not found!";
        }

        public string DeleteOrderProduct(OrderProduct orderProduct)
        {
            OrderProduct orderProductToDelete = context.OrderProducts.Find(orderProduct.OrderId);
            if (orderProductToDelete != null)
            {
                context.OrderProducts.Remove(orderProductToDelete);
                context.SaveChanges();
                return $"OrderProduct deleted successfully!";
            }
            return $"OrderProduct not found!";
        }
    }
}
