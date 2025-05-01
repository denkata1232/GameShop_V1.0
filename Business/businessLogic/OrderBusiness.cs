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
        private OrderProductBusiness orderProductBusiness;
        public OrderBusiness(GameShopContext context)
        {
            this.context = context;
            this.orderProductBusiness = new OrderProductBusiness(context);
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
            if(context.Orders.Any(o => o.OrderId == order.OrderId))
            {
                return $"Order with ID: {order.OrderId} already exists!";
            }
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
            if(context.Products.Find(product.ProductId)==null)
            {
                return "Product doesn't exist!";
            }
            if(quantity <= 0 || quantity > product.Quantity)
            {
                this.DeleteOrder(order);
                return "Quantity is out of bound!";
            }
            this.AddOrder(order);
            OrderProduct orderProduct = new OrderProduct
            {
                OrderId = order.OrderId,
                Order = order,
                ProductId = product.ProductId,
                Product = product,
                Quantity = quantity
            };
            orderProductBusiness.AddOrderProduct(orderProduct);
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

        public string OrderToString(Order order)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Order: {order.OrderId}{Environment.NewLine}" +
                $"User: {order.User.UserName}{Environment.NewLine}" +
                $"Date: {order.Date.ToString("dd.MM.yyyy")}");
                sb.AppendLine("---------------------------------------------");
            sb.AppendLine($"Products:");

            decimal total = 0;
            foreach (var product in order.OrderProducts)
            {
                decimal TotalForProduct = product.Product.Price * product.Quantity;
                sb.AppendLine($"Name: {product.Product.Name} Price: {product.Product.Price:f2}$ X {product.Quantity} - {TotalForProduct:f2}$");
                total += TotalForProduct;
            }
            sb.AppendLine("---------------------------------------------");
            sb.AppendLine($"Total Price paid: {total:f2}$");

            return sb.ToString();
        }
    }
}
