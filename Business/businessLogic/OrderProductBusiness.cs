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

        /// <summary>
        /// Constructor for OrderProductBusiness
        /// </summary>
        /// <param name="context"></param>

        public OrderProductBusiness(GameShopContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Returns all order products from the database
        /// </summary>

        public List<OrderProduct> GetAllOrderProducts()
        {
            return context.OrderProducts.ToList();
        }

        /// <summary>
        /// Returns an order product by its ID
        /// </summary>
        /// <param name="ProductId"></param>
        /// <param name="OrderId"></param>

        public OrderProduct GetOrderProductById(int ProductId, int OrderId)
        {
            return context.OrderProducts.Find(ProductId,OrderId);
        }

        /// <summary>
        /// Adds an order product to the database
        /// </summary>
        /// <param name="orderProduct"></param>

        public string AddOrderProduct(OrderProduct orderProduct)
        {
            if(context.OrderProducts.Any(op => op.OrderId == orderProduct.OrderId && op.ProductId == orderProduct.ProductId))
            {
                return $"OrderProduct with OrderId: {orderProduct.OrderId} and ProductId: {orderProduct.ProductId} already exists!";
            }
            context.OrderProducts.Add(orderProduct);
            context.SaveChanges();
            return $"OrderProduct added successfully!";
        }

        /// <summary>
        /// Updates an order product in the database
        /// </summary>
        /// <param name="orderProduct"></param>

        public string UpdateOrderProduct(OrderProduct orderProduct)
        {
            OrderProduct orderProductToUpdate = context.OrderProducts.Find(orderProduct.ProductId, orderProduct.OrderId);
            if (orderProductToUpdate != null)
            {
                context.Entry(orderProductToUpdate).CurrentValues.SetValues(orderProduct);
                context.SaveChanges();
                return $"OrderProduct updated successfully!";
            }
            return $"OrderProduct not found!";
        }

        /// <summary>
        /// Deletes an order product from the database
        /// </summary>
        /// <param name="orderProduct"></param>

        public string DeleteOrderProduct(OrderProduct orderProduct)
        {
            OrderProduct orderProductToDelete = context.OrderProducts.FirstOrDefault(x => x.ProductId == orderProduct.ProductId && x.OrderId == orderProduct.OrderId);
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
