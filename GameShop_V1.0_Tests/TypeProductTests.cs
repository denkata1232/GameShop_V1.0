using Business.businessLogic;
using Data;
using Effort.Provider;
using Effort;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models;
using NUnit.Framework.Legacy;

namespace GameShop_V1._0_Tests
{
    [TestFixture]
    public class TypeProductTests
    {
        private EffortConnection connection;
        private GameShopContext context;
        private TypeProductBusiness typeProductBusiness;

        /// <summary>
        /// Setup method to initialize the test environment
        /// </summary>

        [SetUp]
        public void Setup()
        {
            connection = DbConnectionFactory.CreateTransient();
            context = new GameShopContext(connection);
            typeProductBusiness = new TypeProductBusiness(context);
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
            context.TypeProducts.Add(new TypeProduct
            {
                TypeProductId = 3,
                Name = "Test Type 3"
            });
        }

        /// <summary>
        /// Tests the GetAllTypeProducts method
        /// </summary>

        [Test]
        public void TypeProductGetAllTest()
        {
            // Test getting all type products
            var typeProducts = typeProductBusiness.GetAllTypeProducts();
            ClassicAssert.AreEqual(3, typeProducts.Count);
        }

        /// <summary>
        /// Tests the GetTypeProductById method
        /// </summary>

        [Test]
        public void TypeProductGetByIdTest()
        {
            // Test getting a type product by ID
            var typeProduct = typeProductBusiness.GetTypeProductById(1);
            ClassicAssert.AreEqual("Test Type", typeProduct.Name);
        }

        /// <summary>
        /// Tests the AddTypeProduct method when it should pass
        /// </summary>

        [Test]
        public void TypeProductAddPassTest()
        {
            // Test adding a new type product
            var typeProduct = new TypeProduct
            {
                TypeProductId = 4,
                Name = "Test Type 4"
            };
            string result = typeProductBusiness.AddTypeProduct(typeProduct);
            ClassicAssert.AreEqual("TypeProduct: Test Type 4 added successfully", result);
            ClassicAssert.AreEqual(4, typeProductBusiness.GetAllTypeProducts().Count);
        }

        /// <summary>
        /// Tests the AddTypeProduct method when it should fail
        /// </summary>

        [Test]
        public void TypeProductAddFailTest()
        {
            // Test adding a type product with an existing name
            var typeProduct = new TypeProduct
            {
                TypeProductId = 5,
                Name = "Test Type"
            };
            string result = typeProductBusiness.AddTypeProduct(typeProduct);
            ClassicAssert.AreEqual("TypeProduct with Name: Test Type already exists", result);
            ClassicAssert.AreEqual(3, typeProductBusiness.GetAllTypeProducts().Count);
        }

        /// <summary>
        /// Tests the UpdateTypeProduct method when it should pass
        /// </summary>

        [Test]
        public void TypeProductUpdatePassTest()
        {
            // Test updating an existing type product
            var typeProduct = typeProductBusiness.GetTypeProductById(1);
            typeProduct.Name = "Updated Type";
            string result = typeProductBusiness.UpdateTypeProduct(typeProduct);

            ClassicAssert.AreEqual("TypeProduct: Updated Type updated successfully", result);
            ClassicAssert.AreEqual("Updated Type", typeProductBusiness.GetTypeProductById(1).Name);
        }

        /// <summary>
        /// Tests the UpdateTypeProduct method when it should fail
        /// </summary>

        [Test]
        public void TypeProductUpdateFailTest()
        {
            // Test updating a non-existing type product
            var typeProduct = new TypeProduct
            {
                TypeProductId = 5,
                Name = "Non-existing Type"
            };
            string result = typeProductBusiness.UpdateTypeProduct(typeProduct);
            ClassicAssert.AreEqual("TypeProduct with Name: Non-existing Type not found", result);
        }

        /// <summary>
        /// Tests the DeleteTypeProduct method when it should pass
        /// </summary>

        [Test]
        public void TypeProductDeletePassTest()
        {
            // Test deleting an existing type product
            int countBefore = typeProductBusiness.GetAllTypeProducts().Count;
            var typeProduct = typeProductBusiness.GetTypeProductById(1);
            string result = typeProductBusiness.DeleteTypeProduct(typeProduct);

            ClassicAssert.AreEqual("TypeProduct: Test Type deleted successfully", result);
            ClassicAssert.AreEqual(countBefore-1, typeProductBusiness.GetAllTypeProducts().Count);
        }

        /// <summary>
        /// Tests the DeleteTypeProduct method when it should fail
        /// </summary>

        [Test]
        public void TypeProductDeleteFailTest()
        {
            // Test deleting a non-existing type product
            int countBefore = typeProductBusiness.GetAllTypeProducts().Count;
            var typeProduct = new TypeProduct
            {
                TypeProductId = 5,
                Name = "Non-existing Type"
            };
            string result = typeProductBusiness.DeleteTypeProduct(typeProduct);
            ClassicAssert.AreEqual("TypeProduct with Name: Non-existing Type not found", result);
            ClassicAssert.AreEqual(countBefore, typeProductBusiness.GetAllTypeProducts().Count);
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
