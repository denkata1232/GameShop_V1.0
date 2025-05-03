using Data;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.businessLogic
{
    public class UserBusiness
    {
        private GameShopContext context;

        /// <summary>
        /// Constructor for UserBusiness
        /// </summary>
        /// <param name="context"></param>

        public UserBusiness(GameShopContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Returns all users from the database
        /// </summary>

        public List<User> GetAllUsers()
        {
            return context.Users.ToList();
        }

        /// <summary>
        /// Returns a user by its ID
        /// </summary>
        /// <param name="id"></param>

        public User GetUserById(int id)
        {
            return context.Users.Find(id);
        }

        /// <summary>
        /// Returns a user by its username and password
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>

        public User GetUserByUsernameAndPassword(string username, string password)
        {
            return context.Users.FirstOrDefault(x => x.UserName == username && x.Password == password);
        }

        /// <summary>
        /// Returns a user by its username
        /// </summary>
        /// <param name="username"></param>

        public User GetUserByUsername(string username)
        {
            return context.Users.FirstOrDefault(x => x.UserName == username);
        }

        /// <summary>
        /// Adds a user to the database
        /// </summary>
        /// <param name="user"></param>

        public string AddUser(User user)
        {
            if (context.Users.Any(x => x.UserName == user.UserName || x.Email == user.Email))
            {
                return $"User: {user.UserName} already exists!";
            }
            context.Users.Add(user);
            context.SaveChanges();
            return $"User: {user.UserName} added successfully!";
        }

        /// <summary>
        /// Updates a user in the database
        /// </summary>
        /// <param name="user"></param>

        public string UpdateUser(User user)
        {
            User userToUpdate = context.Users.Find(user.UserId);
            if (userToUpdate != null)
            {
                context.Entry(userToUpdate).CurrentValues.SetValues(user);
                context.SaveChanges();
                return $"User: {user.UserName} updated successfully!";
            }
            return $"User with Name: {user.UserName} not found!";
        }

        /// <summary>
        /// Deletes a user from the database
        /// </summary>
        /// <param name="user"></param>

        public string DeleteUser(User user)
        {
            User userToDelete = context.Users.Find(user.UserId);
            if (userToDelete != null)
            {
                context.Users.Remove(userToDelete);
                context.SaveChanges();
                return $"User: {userToDelete.UserName} deleted successfully!";
            }
            return $"User with Name: {user.UserName} not found!";
        }

        /// <summary>
        /// Returns all users who have a specific game in their orders
        /// </summary>
        /// <param name="product"></param>

        public List<User> GetAllUsersWithAGameOfChoice(Product product)
        {
            return context.Orders.Where(o => o.OrderProducts.Any(op => op.ProductId == product.ProductId))
                .Select(o => o.User)
                .Distinct()
                .ToList();
        }
    }
}
