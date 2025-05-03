using Data;
using Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Business.businessLogic
{
    public class ProductBusiness
    {
        private GameShopContext context;


        /// <summary>
        /// Constructor for ProductBusiness
        /// </summary>
        /// <param name="context"></param>
        public ProductBusiness(GameShopContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Returns all products from the database
        /// </summary>

        public List<Product> GetAllProducts()
        {
            return context.Products.ToList();
        }

        /// <summary>
        /// Returns a product by its ID
        /// </summary>
        /// <param name="id"></param>

        public Product GetProductById(int id)
        {
            return context.Products.Find(id);
        }

        /// <summary>
        /// Returns a product by its name
        /// </summary>
        /// <param name="name"></param>
        
        public Product GetProductByName(string name)
        {
            return context.Products
                .Include("TypeProduct")
                .FirstOrDefault(x => x.Name == name);
        }

        /// <summary>
        /// Adds a product to the database
        /// </summary>
        /// <param name="product"></param>

        public string AddProduct(Product product)
        {
            if(context.Products.Any(p => p.Name == product.Name))
            {
                return $"Product with Name: {product.Name} already exists";
            }
            context.Products.Add(product);
            context.SaveChanges();
            return $"Product: {product.Name} added successfully";
        }

        /// <summary>
        /// Updates a product in the database
        /// </summary>
        /// <param name="product"></param>

        public string UpdateProduct(Product product)
        {
            Product productToUpdate = context.Products.Find(product.ProductId);
            if (productToUpdate != null)
            {
                context.Entry(productToUpdate).CurrentValues.SetValues(product);
                context.SaveChanges();
                return $"Product: {product.Name} updated successfully";
            }
            return $"Product with Name: {product.Name} not found";
        }

        /// <summary>
        /// Deletes a product from the database
        /// </summary>
        /// <param name="product"></param>

        public string DeleteProduct(Product product)
        {
            Product productToDelete = context.Products.Find(product.ProductId);
            if (productToDelete != null)
            {
                context.Products.Remove(productToDelete);
                context.SaveChanges();
                return $"Product: {productToDelete.Name} deleted successfully";
            }
            return $"Product with Name: {product.Name} not found";
        }
    }
}
