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
    public class QuariesTests
    {
        private EffortConnection connection;
        private GameShopContext context;
        private OrderProductBusiness orderProductBusiness;
        private UserBusiness userBusiness;
        private OrderBusiness orderBusiness;
        private ProductBusiness productBusiness;
        private TypeProductBusiness typeProductBusiness;

        /// <summary>
        /// Setup method to initialize the test environment
        /// </summary>

        [SetUp]
        public void Setup()
        {
            connection = DbConnectionFactory.CreateTransient();
            context = new GameShopContext(connection);
            orderProductBusiness = new OrderProductBusiness(context);
            userBusiness = new UserBusiness(context);
            orderBusiness = new OrderBusiness(context);
            productBusiness = new ProductBusiness(context);
            typeProductBusiness = new TypeProductBusiness(context);
            TestDataFill();
        }

        /// <summary>
        /// Fills the database with test data
        /// </summary>
        private void TestDataFill()
        {
            TestDataFillUser();
            TestDataFillProduct();
            TestDataFillOrderProduct();
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
        private void TestDataFillOrderProduct()
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

        /// <summary>
        /// Tests the GetOrdersByUserId method
        /// </summary>

        [Test]
        public void GetAllUsersWithAGameOfChoiceTest()
        {
            // Test getting all users with a specific game in their orders
            var product = context.Products.Find(1);
            var users = userBusiness.GetAllUsersWithAGameOfChoice(product);
            ClassicAssert.IsNotNull(users);
            ClassicAssert.AreEqual(2, users.Count);
        }

        /// <summary>
        /// Tests the GetOrdersByUser method
        /// </summary>

        [Test]
        public void GetOrdersByUserNameTest()
        {
            // Test getting all orders by a specific user
            var orders = orderBusiness.GetAllOrdersByUser("TestUser");
            ClassicAssert.IsNotNull(orders);
            ClassicAssert.AreEqual(1, orders.Count);
        }

        /// <summary>
        /// Tests GetAllOrdersContainingAGameOfChoice method
        /// </summary>

        [Test]
        public void GetAllOrdersContainingAGameOfChoiceTest()
        {
            // Test getting all orders containing a specific game
            var orders = orderBusiness.GetAllOrdersContainingAGameOfChoise("Test Product");
            ClassicAssert.IsNotNull(orders);
            ClassicAssert.AreEqual(2, orders.Count);
        }

        [TearDown]
        public void Finish()
        {
            connection.Dispose();
            context.Dispose();
        }
    }
}
