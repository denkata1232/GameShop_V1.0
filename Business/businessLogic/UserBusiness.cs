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

        public UserBusiness(GameShopContext context)
        {
            this.context = context;
        }

        public List<User> GetAllUsers()
        {
            return context.Users.ToList();
        }

        public User GetUserById(int id)
        {
            return context.Users.Find(id);
        }

        public User GetUser(string username, string password)
        {
            return context.Users.FirstOrDefault(x => x.UserName == username && x.Password == password);
        }

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

        public List<User> GetAllUsersWithAGameOfChoice(Product product)
        {
            return context.Orders.Where(o => o.OrderProducts.Any(op => op.ProductId == product.ProductId))
                .Select(o => o.User)
                .Distinct()
                .ToList();
        }
    }
}
