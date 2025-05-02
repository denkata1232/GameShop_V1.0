using Business.businessLogic;
using Data.Models;
using Data;
using Effort.Provider;
using Effort;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Legacy;

namespace GameShop_V1._0_Tests
{
    [TestFixture]
    public class OrderProductTests
    {
        private EffortConnection connection;
        private GameShopContext context;
        private OrderProductBusiness orderProductBusiness;
        [SetUp]
        public void Setup()
        {
            connection = DbConnectionFactory.CreateTransient();
            context = new GameShopContext(connection);
            orderProductBusiness = new OrderProductBusiness(context);
            TestDataFillUser();
            TestDataFillProduct();
            TestDataFill();
            TestDataFillOrder();
            context.SaveChanges();
        }

        private void TestDataFillOrder()
        {
            context.Orders.Add(new Order
            {
                OrderId = 1,
                UserId = 1,
                Date = DateTime.Now,
                OrderProducts = new List<OrderProduct>(),
                User = context.Users.Find(1)
            });
            context.Orders.Add(new Order
            {
                OrderId = 2,
                UserId = 2,
                Date = DateTime.Now,
                OrderProducts = new List<OrderProduct>(),
                User = context.Users.Find(2)
            });
        }
        private void TestDataFillProduct()
        {
            context.TypeProducts.Add(new TypeProduct
            {
                TypeProductId = 1,
                Name = "Test Type"
            });
            context.TypeProducts.Add(new TypeProduct
            {
                TypeProductId = 2,
                Name = "Test Type 2"
            });
            context.Products.Add(new Product
            {
                ProductId = 1,
                Name = "Test Product",
                Description = "Test Description",
                TypeProductId = 1,
                Price = 9.99m,
                Quantity = 10
            });
            context.Products.Add(new Product
            {
                ProductId = 2,
                Name = "Test Product 2",
                Description = "Test Description 2",
                TypeProductId = 1,
                Price = 19.99m,
                Quantity = 5
            });
            context.Products.Add(new Product
            {
                ProductId = 3,
                Name = "Test Product 3",
                Description = "Test Description 3",
                TypeProductId = 2,
                Price = 29.99m,
                Quantity = 15
            });
        }
        private void TestDataFillUser()
        {
            context.Users.Add(new User
            {
                UserId = 1,
                UserName = "TestUser",
                Password = "TestPassword",
                Email = "TestEmail@test"
            });
            context.Users.Add(new User
            {
                UserId = 2,
                UserName = "TestUser2",
                Password = "TestPassword2",
                Email = "TestEmail2@test",
                IsAdmin = true
            });
            context.Users.Add(new User
            {
                UserId = 3,
                UserName = "TestUser3",
                Password = "TestPassword3",
                Email = "TestEmail3@test"
            });
        }
        private void TestDataFill()
        {
            context.OrderProducts.Add(new OrderProduct
            {
                OrderId = 1,
                Order = context.Orders.Find(1),
                ProductId = 1,
                Product = context.Products.Find(1),
                Quantity = 2
            });
            context.OrderProducts.Add(new OrderProduct
            {
                OrderId = 2,
                Order = context.Orders.Find(2),
                ProductId = 1,
                Product = context.Products.Find(1),
                Quantity = 4
            });
            context.OrderProducts.Add(new OrderProduct
            {
                OrderId = 2,
                Order = context.Orders.Find(2),
                ProductId = 3,
                Product = context.Products.Find(3),
                Quantity = 1
            });
            context.OrderProducts.Add(new OrderProduct
            {
                OrderId = 1,
                Order = context.Orders.Find(1),
                ProductId = 3,
                Product = context.Products.Find(3),
                Quantity = 3
            });
        }

        [Test]
        public void GetOrderProductByIdTest()
        {
            var orderProduct = orderProductBusiness.GetOrderProductById(1,1);
            ClassicAssert.IsNotNull(orderProduct);
            ClassicAssert.AreEqual(1, orderProduct.OrderId);
            ClassicAssert.AreEqual(1, orderProduct.ProductId);
            ClassicAssert.AreEqual(2, orderProduct.Quantity);
        }
        [Test]
        public void GetAllOrderProductsTest()
        {
            var orderProducts = orderProductBusiness.GetAllOrderProducts();
            ClassicAssert.IsNotNull(orderProducts);
            ClassicAssert.AreEqual(4, orderProducts.Count);
        }
        [Test]
        public void AddOrderProductPassTest()
        {
            int countBefore = context.OrderProducts.Count();
            var orderProduct = new OrderProduct
            {
                OrderId = 1,
                ProductId = 2,
                Quantity = 5
            };
            var result = orderProductBusiness.AddOrderProduct(orderProduct);
            ClassicAssert.AreEqual("OrderProduct added successfully!", result);
            ClassicAssert.AreEqual(countBefore+1, context.OrderProducts.Count());
        }
        [Test]
        public void AddOrderProductFailTest()
        {
            int countBefore = context.OrderProducts.Count();
            var orderProduct = new OrderProduct
            {
                OrderId = 1,
                ProductId = 1,
                Quantity = 5
            };
            var result = orderProductBusiness.AddOrderProduct(orderProduct);
            ClassicAssert.AreEqual($"OrderProduct with OrderId: {orderProduct.OrderId} and ProductId: {orderProduct.ProductId} already exists!", result);
            ClassicAssert.AreEqual(countBefore, context.OrderProducts.Count());
        }
        [Test]
        public void UpdateOrderProductPassTest()
        {
            var orderProduct = new OrderProduct
            {
                OrderId = 1,
                ProductId = 1,
                Quantity = 5
            };
            var result = orderProductBusiness.UpdateOrderProduct(orderProduct);
            ClassicAssert.AreEqual("OrderProduct updated successfully!", result);
            ClassicAssert.AreEqual(5, orderProductBusiness.GetOrderProductById(1,1).Quantity);
        }
        [Test]
        public void UpdateOrderProductFailTest()
        {
            var orderProduct = new OrderProduct
            {
                OrderId = 1,
                ProductId = 5,
                Quantity = 5
            };
            var result = orderProductBusiness.UpdateOrderProduct(orderProduct);
            ClassicAssert.AreEqual("OrderProduct not found!", result);
        }
        [Test]
        public void DeleteOrderProductPassTest()
        {
            int countBefore = context.OrderProducts.Count();
            var orderProduct = new OrderProduct
            {
                OrderId = 1,
                ProductId = 1
            };
            var result = orderProductBusiness.DeleteOrderProduct(orderProduct);
            ClassicAssert.AreEqual("OrderProduct deleted successfully!", result);
            ClassicAssert.AreEqual(countBefore - 1, context.OrderProducts.Count());
        }
        [Test]
        public void DeleteOrderProductFailTest()
        {
            int countBefore = context.OrderProducts.Count();
            var orderProduct = new OrderProduct
            {
                OrderId = 1,
                ProductId = 5
            };
            var result = orderProductBusiness.DeleteOrderProduct(orderProduct);
            ClassicAssert.AreEqual("OrderProduct not found!", result);
            ClassicAssert.AreEqual(countBefore, context.OrderProducts.Count());
        }

        [TearDown]
        public void Finish()
        {
            connection.Dispose();
            context.Dispose();
        }
    }
}
