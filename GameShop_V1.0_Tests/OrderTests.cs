using Business.businessLogic;
using Data;
using Data.Models;
using Effort;
using Effort.Provider;
using NUnit.Framework.Legacy;

namespace GameShop_V1._0_Tests
{
    [TestFixture]
    internal class OrderTests
    {
        private EffortConnection connection;
        private GameShopContext context;
        private OrderBusiness orderBusiness;
        [SetUp]
        public void Setup()
        {
            connection = DbConnectionFactory.CreateTransient();
            context = new GameShopContext(connection);
            orderBusiness = new OrderBusiness(context);
            TestDataFillUser();
            TestDataFillProduct();
            TestDataFillOrderProduct();
            TestDataFill();
            context.SaveChanges();
        }

        private void TestDataFill()
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
        [Test]
        public void OrderGetAllTest()
        {
            // Test getting all orders
            var orders = orderBusiness.GetAllOrders();
            ClassicAssert.AreEqual(2, orders.Count);
        }
        [Test]
        public void OrderGetByIdTest()
        {
            // Test getting an order by ID
            var order = orderBusiness.GetOrderById(1);
            ClassicAssert.AreEqual(1, order.OrderId);
            ClassicAssert.AreEqual(1, order.UserId);
        }
        [Test]
        public void OrderAddPassTest()
        {
            // Test adding a new order
            int countBefore = orderBusiness.GetAllOrders().Count;
            var order = new Order
            {
                UserId = 1,
                Date = DateTime.Now,
                OrderProducts = new List<OrderProduct>(),
                User = context.Users.Find(1)
            };
            string result = orderBusiness.AddOrder(order);
            ClassicAssert.AreEqual("Order: 3 added successfully!", result);
            ClassicAssert.AreEqual(countBefore + 1, orderBusiness.GetAllOrders().Count);
        }
        [Test]
        public void OrderAddFailTest()
        {
            // Test adding an order with an existing ID
            var order = new Order
            {
                OrderId = 1,
                UserId = 1,
                Date = DateTime.Now,
                OrderProducts = new List<OrderProduct>(),
                User = context.Users.Find(1)
            };
            string result = orderBusiness.AddOrder(order);
            ClassicAssert.AreEqual("Order with ID: 1 already exists!", result);
        }
        [Test]
        public void OrderAddProductToOrderPassTest()
        {
            // Test adding a product to an order
            var order = context.Orders.Find(1);
            var product = context.Products.Find(2);
            string result = orderBusiness.AddProductToOrder(order, product, 2);
            ClassicAssert.AreEqual($"Product: {product.Name} added to Order: {order.OrderId} successfully!", result);
            ClassicAssert.AreEqual(3, order.OrderProducts.Count);
        }
        [Test]
        public void OrderAddProductToOrderFailNullTest()
        {
            // Test adding a product to an order with invalid data
            var order = context.Orders.Find(1);
            var product = context.Products.Find(1);
            string result = orderBusiness.AddProductToOrder(null, null, 2);
            ClassicAssert.AreEqual("Product or Order cannot be null!", result);
        }
        [Test]
        public void OrderAddProductToOrderNewOrderPassTest()
        {
            // Test adding a product to an order with new order
            Order order = new Order
            {
                OrderProducts = new List<OrderProduct>(),
                UserId = 1,
                Date = DateTime.Now,
                User = context.Users.Find(1)
            };
            var product = context.Products.Find(1);
            string result = orderBusiness.AddProductToOrder(order, product, 2);
            ClassicAssert.AreEqual($"Product: {product.Name} added to Order: {order.OrderId} successfully!", result);
        }
        [Test]
        public void OrderAddProductToOrderFailInvalitProductTest()
        {
            // Test adding a product to an order with invalid data
            var order = context.Orders.Find(1);
            var product = new Product
            {
                Price = 9.99m,
                Name = "test"
            };

            string result = orderBusiness.AddProductToOrder(order, product, 1);
            ClassicAssert.AreEqual("Product doesn't exist!", result);
        }
        [Test]
        public void OrderAddProductToOrderFailInvalidQuantityTest()
        {
            // Test adding a product to an order with invalid quantity
            var order = context.Orders.Find(1);
            var product = context.Products.Find(1);
            string result = orderBusiness.AddProductToOrder(order, product, 20);
            ClassicAssert.AreEqual("Quantity is out of bound!", result);
            ClassicAssert.AreEqual(null, context.Orders.Find(1));
        }

        [TearDown]
        public void Finish()
        {
            connection.Dispose();
            context.Dispose();
        }
    }
}
