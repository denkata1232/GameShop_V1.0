using Data;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.businessLogic
{
    public class TypeProductBusiness
    {
        private GameShopContext context;

        /// <summary>
        /// Constructor for TypeProductBusiness
        /// </summary>
        /// <param name="context"></param>

        public TypeProductBusiness(GameShopContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Returns all types of a product from the database
        /// </summary>

        public List<TypeProduct> GetAllTypeProducts()
        {
            return context.TypeProducts.ToList();
        }

        /// <summary>
        /// Returns a type of product by its ID
        /// </summary>
        /// <param name="id"></param>

        public TypeProduct GetTypeProductById(int id)
        {
            return context.TypeProducts.Find(id);
        }

        /// <summary>
        /// Adds a type of product to the database
        /// </summary>
        /// <param name="typeProduct"></param>

        public string AddTypeProduct(TypeProduct typeProduct)
        {
            if(context.TypeProducts.Any(tp => tp.Name == typeProduct.Name))
            {
                return $"TypeProduct with Name: {typeProduct.Name} already exists";
            }
            context.TypeProducts.Add(typeProduct);
            context.SaveChanges();
            return $"TypeProduct: {typeProduct.Name} added successfully";
        }

        /// <summary>
        /// Updates a type of product in the database
        /// </summary>
        /// <param name="typeProduct"></param>

        public string UpdateTypeProduct(TypeProduct typeProduct)
        {
            TypeProduct typeProductToUpdate = context.TypeProducts.Find(typeProduct.TypeProductId);
            if (typeProductToUpdate != null)
            {
                context.Entry(typeProductToUpdate).CurrentValues.SetValues(typeProduct);
                context.SaveChanges();
                return $"TypeProduct: {typeProduct.Name} updated successfully";
            }
            return $"TypeProduct with Name: {typeProduct.Name} not found";
        }

        /// <summary>
        /// Deletes a type of product from the database
        /// </summary>
        /// <param name="typeProduct"></param>

        public string DeleteTypeProduct(TypeProduct typeProduct)
        {
            TypeProduct typeProductToDelete = context.TypeProducts.Find(typeProduct.TypeProductId);
            if (typeProductToDelete != null)
            {
                context.TypeProducts.Remove(typeProductToDelete);
                context.SaveChanges();
                return $"TypeProduct: {typeProductToDelete.Name} deleted successfully";
            }
            return $"TypeProduct with Name: {typeProduct.Name} not found";
        }
    }
}
