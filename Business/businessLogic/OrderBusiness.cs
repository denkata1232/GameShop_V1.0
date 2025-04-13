using Data;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.businessLogic
{
    public class OrderBusiness
    {
        private GameShopContext context;

        public OrderBusiness(GameShopContext context)
        {
            this.context = context;
        }

        public List<Order> GetAllOrders()
        {
            return context.Orders.ToList();
        }

        public Order GetOrderById(int id)
        {
            return context.Orders.Find(id);
        }

        public string AddOrder(Order order)
        {
            context.Orders.Add(order);
            context.SaveChanges();
            return $"Order: {order.OrderId} added successfully!";
        }

        public string UpdateOrder(Order order)
        {
            Order orderToUpdate = context.Orders.Find(order.OrderId);
            if (orderToUpdate != null)
            {
                context.Entry(orderToUpdate).CurrentValues.SetValues(order);
                context.SaveChanges();
                return $"Order: {order.OrderId} updated successfully!";
            }
            return $"Order with ID: {order.OrderId} not found!";
        }

        public string DeleteOrder(Order order)
        {
            Order orderToDelete = context.Orders.Find(order.OrderId);
            if (orderToDelete != null)
            {
                context.Orders.Remove(orderToDelete);
                context.SaveChanges();
                return $"Order: {orderToDelete.OrderId} deleted successfully!";
            }
            return $"Order with ID: {order.OrderId} not found!";
        }

        public string AddProductToOrder(Order order, Product product, int quantity)
        {
            if(product == null || order == null)
            {
                return "Product or Order cannot be null!";
            }
            if(product.ProductId == null || order.OrderId == null)
            {
                return "Product ID or Order ID cannot be null!";
            }
            if(quantity <= 0 || quantity > product.Quantity)
            {
                return "Quantity is out of bound!";
            }
            OrderProduct orderProduct = new OrderProduct
            {
                OrderId = order.OrderId,
                ProductId = product.ProductId,
                Quantity = quantity
            };
            context.OrderProducts.Add(orderProduct);
            return $"Product: {product.Name} added to Order: {order.OrderId} successfully!";
        }

        public List<Order> GetOrdersByUserId(User user)
        {
            return context.Orders.Where(o => o.UserId == user.UserId).ToList();
        }

        public List<Order> GetOrdersByDate(DateTime date)
        {
            return context.Orders.Where(o => o.Date.Date == date.Date).ToList();
        }

        public List<Order> GetOrdersByDateRange(DateTime startDate, DateTime endDate)
        {
            return context.Orders.Where(o => o.Date.Date >= startDate.Date && o.Date.Date <= endDate.Date).ToList();
        }
    }
}
