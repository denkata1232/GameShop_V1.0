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
        [SetUp]
        public void Setup()
        {
            connection = DbConnectionFactory.CreateTransient();
            context = new GameShopContext(connection);
            productBusiness = new ProductBusiness(context);
            TestDataFill();
            context.SaveChanges();
        }

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

        [Test]
        public void ProductAddTest()
        {
            int countBefore = context.Products.Count();
            context.Products.Add(new Product
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
        [TearDown]
        public void Finish()
        {
            connection.Dispose();
            context.Dispose();
        }
    }
}