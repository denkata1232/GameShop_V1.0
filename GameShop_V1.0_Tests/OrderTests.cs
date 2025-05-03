using Business.businessLogic;
using Data;
using Data.Models;
using Effort;
using Effort.Provider;
using NUnit.Framework.Legacy;

namespace GameShop_V1._0_Tests
{
    [TestFixture]
    public class OrderTests
    {
        private EffortConnection connection;
        private GameShopContext context;
        private OrderBusiness orderBusiness;

        /// <summary>
        /// Setup method to initialize the test environment
        /// </summary>

        [SetUp]
        public void Setup()
        {
            connection = DbConnectionFactory.CreateTransient();
            context = new GameShopContext(connection);
            orderBusiness = new OrderBusiness(context);
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
        /// Tests the GetAllOrders method
        /// </summary>

        [Test]
        public void OrderGetAllTest()
        {
            // Test getting all orders
            var orders = orderBusiness.GetAllOrders();
            ClassicAssert.AreEqual(2, orders.Count);
        }

        /// <summary>
        /// Tests the GetOrderById method
        /// </summary>

        [Test]
        public void OrderGetByIdTest()
        {
            // Test getting an order by ID
            var order = orderBusiness.GetOrderById(1);
            ClassicAssert.AreEqual(1, order.OrderId);
            ClassicAssert.AreEqual(1, order.UserId);
        }

        /// <summary>
        /// Tests the GetOrderById method when it should pass
        /// </summary>

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

        /// <summary>
        /// Tests the AddOrder method when it should fail
        /// </summary>

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

        /// <summary>
        /// Tests the AddProductToOrder method when it should pass
        /// </summary>

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

        /// <summary>
        /// Tests the AddProductToOrder method when it should fail by null
        /// </summary>

        [Test]
        public void OrderAddProductToOrderFailNullTest()
        {
            // Test adding a product to an order with invalid data
            string result = orderBusiness.AddProductToOrder(null, null, 2);
            ClassicAssert.AreEqual("Product or Order cannot be null!", result);
        }

        /// <summary>
        /// Tests the AddProductToOrder method when it should pass
        /// </summary>

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

        /// <summary>
        /// Tests the AddProductToOrder method when it should fail by invalid product
        /// </summary>

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

        /// <summary>
        /// Tests the AddProductToOrder method when it should fail by invalid quantity
        /// </summary>

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

        /// <summary>
        /// Tests the GetOrdersByUserId method
        /// </summary>

        [Test]
        public void OrderGetByUserIdTest()
        {
            // Test getting orders by user ID
            var user = context.Users.Find(1);
            var orders = orderBusiness.GetOrdersByUserId(user);
            ClassicAssert.AreEqual(1, orders.Count);
            ClassicAssert.AreEqual(1, orders[0].OrderId);
        }

        /// <summary>
        /// Tests the OrderUpdate method when it should pass
        /// </summary>

        [Test]
        public void OrderUpdatePassTest()
        {
            // Test updating an order
            var order = context.Orders.Find(1);
            order.UserId = 2;
            string result = orderBusiness.UpdateOrder(order);
            ClassicAssert.AreEqual($"Order: {order.OrderId} updated successfully!", result);
            ClassicAssert.AreEqual(2, context.Orders.Find(1).UserId);
        }

        /// <summary>
        /// Tests the OrderUpdate method when it should fail
        /// </summary>

        [Test]
        public void OrderUpdateFailTest()
        {
            // Test updating an order with invalid ID
            var order = new Order
            {
                OrderId = 5,
                UserId = 1,
                Date = DateTime.Now,
                OrderProducts = new List<OrderProduct>(),
                User = context.Users.Find(1)
            };
            string result = orderBusiness.UpdateOrder(order);
            ClassicAssert.AreEqual($"Order with ID: {order.OrderId} not found!", result);
        }

        /// <summary>
        /// Tests the OrderDelete method when it should pass
        /// </summary>

        [Test]
        public void OrderDeletePassTest()
        {
            // Test deleting an order
            int countBefore = orderBusiness.GetAllOrders().Count;
            var order = context.Orders.Find(1);
            string result = orderBusiness.DeleteOrder(order);
            ClassicAssert.AreEqual($"Order: {order.OrderId} deleted successfully!", result);
            ClassicAssert.AreEqual(null, context.Orders.Find(1));
            ClassicAssert.AreEqual(countBefore - 1, orderBusiness.GetAllOrders().Count);
        }

        /// <summary>
        /// Tests the OrderDelete method when it should fail
        /// </summary>

        [Test]
        public void OrderDeleteFailTest()
        {
            // Test deleting an order with invalid ID
            int countBefore = orderBusiness.GetAllOrders().Count;
            var order = new Order
            {
                OrderId = 5,
                UserId = 1,
                Date = DateTime.Now,
                OrderProducts = new List<OrderProduct>(),
                User = context.Users.Find(1)
            };
            string result = orderBusiness.DeleteOrder(order);
            ClassicAssert.AreEqual($"Order with ID: {order.OrderId} not found!", result);
            ClassicAssert.AreEqual(countBefore, orderBusiness.GetAllOrders().Count);
        }

        /// <summary>
        /// TearDown method to clean up the test environment
        /// </summary>

        [TearDown]
        public void Finish()
        {
            connection.Dispose();
            context.Dispose();
        }
    }
}
