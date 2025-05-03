using Business.businessLogic;
using Data;
using Data.Models;
using Effort;
using Effort.Provider;
using NUnit.Framework.Legacy;
using System.Data.Entity;
namespace GameShop_V1._0_Tests
{
    [TestFixture]
    public class ProductTests
    {
        private EffortConnection connection;
        private GameShopContext context;
        private ProductBusiness productBusiness;

        /// <summary>
        /// Setup method to initialize the test environment
        /// </summary>

        [SetUp]
        public void Setup()
        {
            connection = DbConnectionFactory.CreateTransient();
            context = new GameShopContext(connection);
            productBusiness = new ProductBusiness(context);
            TestDataFill();
            context.SaveChanges();
        }

        /// <summary>
        /// Fills the database with test data
        /// </summary>

        private void TestDataFill()
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

        /// <summary>
        /// Tests the AddProduct method when it should succeed
        /// </summary>

        [Test]
        public void ProductAddPassTest()
        {
            int countBefore = context.Products.Count();
            productBusiness.AddProduct(new Product
            {
                ProductId = 4,
                Name = "Test Product Add",
                Description = "Test Description",
                TypeProductId = 1,
                Price = 9.99m,
                Quantity = 10
            });
            context.SaveChanges();
            var products = productBusiness.GetAllProducts();
            
            ClassicAssert.AreEqual(countBefore+1, products.Count);
        }
        [Test]
        public void ProductAddFailTest()
        {
            int countBefore = context.Products.Count();
            productBusiness.AddProduct(new Product
            {
                ProductId = 5,
                Name = "Test Product",
                Description = "Test Description",
                TypeProductId = 1,
                Price = 9.99m,
                Quantity = 10
            });
            context.SaveChanges();
            var products = productBusiness.GetAllProducts();

            ClassicAssert.AreEqual(countBefore, products.Count);
        }
        [Test]
        public void ProductGetByIdTest()
        {
            var product = productBusiness.GetProductById(1);

            ClassicAssert.AreEqual("Test Product", product.Name);
        }
        [Test]
        public void ProductGetByNameTest()
        {
            var product = productBusiness.GetProductByName("Test Product");

            ClassicAssert.AreEqual(1, product.ProductId);
        }
        [Test]
        public void ProductUpdatePassTest()
        {
            var product = productBusiness.GetProductById(1);
            product.Name = "Updated Product";
            string message = productBusiness.UpdateProduct(product);
            context.SaveChanges();

            var updatedProduct = productBusiness.GetProductById(1);
            ClassicAssert.AreEqual("Updated Product", updatedProduct.Name);
            ClassicAssert.AreEqual($"Product: {product.Name} updated successfully", message);
        }
        [Test]
        public void ProductUpdateFailTest()
        {
            Product product = new Product()
            {
                ProductId = 5,
                Name = "Updated Product",
                Description = "Updated Description",
                TypeProductId = 1,
                Price = 19.99m,
                Quantity = 5
            };
            string message = productBusiness.UpdateProduct(product);
            context.SaveChanges();
            ClassicAssert.AreEqual($"Product with Name: {product.Name} not found", message);
        }
        [Test]
        public void ProductDeletePassTest()
        {
            int countBefore = productBusiness.GetAllProducts().Count();
            var product = productBusiness.GetProductById(1);
            string message = productBusiness.DeleteProduct(product);
            context.SaveChanges();

            var deletedProduct = productBusiness.GetProductById(1);
            ClassicAssert.AreEqual($"Product: {product.Name} deleted successfully", message);
            ClassicAssert.IsNull(deletedProduct);
            ClassicAssert.AreEqual(countBefore - 1, productBusiness.GetAllProducts().Count());
        }
        [Test]
        public void ProductDeleteFailTest()
        {
            int countBefore = productBusiness.GetAllProducts().Count();
            Product product = new Product()
            {
                ProductId = 5,
                Name = "Test Product",
                Description = "Test Description",
                TypeProductId = 1,
                Price = 9.99m,
                Quantity = 10
            };
            string message = productBusiness.DeleteProduct(product);
            context.SaveChanges();
            ClassicAssert.AreEqual($"Product with Name: {product.Name} not found", message);
            ClassicAssert.AreEqual(countBefore, productBusiness.GetAllProducts().Count());
        }
        [TearDown]
        public void Finish()
        {
            connection.Dispose();
            context.Dispose();
        }
    }
}