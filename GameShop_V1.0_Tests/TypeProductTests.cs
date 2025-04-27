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
    internal class TypeProductTests
    {
        private EffortConnection connection;
        private GameShopContext context;
        private TypeProductBusiness typeProductBusiness;
        [SetUp]
        public void Setup()
        {
            connection = DbConnectionFactory.CreateTransient();
            context = new GameShopContext(connection);
            typeProductBusiness = new TypeProductBusiness(context);
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
            context.TypeProducts.Add(new TypeProduct
            {
                TypeProductId = 3,
                Name = "Test Type 3"
            });
        }
        [Test]
        public void TypeProductGetAllTest()
        {
            // Test getting all type products
            var typeProducts = typeProductBusiness.GetAllTypeProducts();
            ClassicAssert.AreEqual(3, typeProducts.Count);
        }
        [Test]
        public void TypeProductGetByIdTest()
        {
            // Test getting a type product by ID
            var typeProduct = typeProductBusiness.GetTypeProductById(1);
            ClassicAssert.AreEqual("Test Type", typeProduct.Name);
        }
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

        [TearDown]
        public void Finish()
        {
            connection.Dispose();
            context.Dispose();
        }
    }
}
