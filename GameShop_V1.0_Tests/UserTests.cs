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
    public class UserTests
    {
        private EffortConnection connection;
        private GameShopContext context;
        private UserBusiness userBusiness;

        /// <summary>
        /// Setup method to initialize the test environment
        /// </summary>

        [SetUp]
        public void Setup()
        {
            connection = DbConnectionFactory.CreateTransient();
            context = new GameShopContext(connection);
            userBusiness = new UserBusiness(context);
            TestDataFill();
            context.SaveChanges();
        }

        /// <summary>
        /// Fills the database with test data
        /// </summary>

        private void TestDataFill()
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

        /// <summary>
        /// Tests the AddUser method when it should pass
        /// </summary>

        [Test]
        public void UserAddPassTest()
        {
            // Test creating a new user
            int initialCount = userBusiness.GetAllUsers().Count;
            var user = new User
            {
                UserId = 4,
                UserName = "NewUser",
                Password = "NewPassword",
                Email = "NewEmail@test"
            };
            userBusiness.AddUser(user);
            context.SaveChanges();

            var createdUser = userBusiness.GetUserById(4);
            ClassicAssert.IsNotNull(createdUser);
            ClassicAssert.AreEqual("NewUser", createdUser.UserName);
            ClassicAssert.AreEqual(initialCount+1, context.Users.Count());
        }

        /// <summary>
        /// Tests the AddUser method when it should fail
        /// </summary>

        [Test]
        public void UserAddFailTest()
        {
            // Test creating a user with existing username
            var user = new User
            {
                UserId = 5,
                UserName = "TestUser",
                Password = "NewPassword",
                Email = "NewEmail@test"
            };
            string message = userBusiness.AddUser(user);
            context.SaveChanges();

            ClassicAssert.AreEqual($"User: {user.UserName} already exists!", message);
        }

        /// <summary>
        /// Tests the GetUserById method
        /// </summary>

        [Test]
        public void GetUserByIdTest()
        {
            // Test getting a user by ID
            var user = userBusiness.GetUserById(1);
            ClassicAssert.IsNotNull(user);
            ClassicAssert.AreEqual("TestUser", user.UserName);
        }

        /// <summary>
        /// Tests the GetUserByUsernameAndPassword method
        /// </summary>

        [Test]
        public void GetUserByNameAndPasswordTest()
        {
            User user = userBusiness.GetUserByUsernameAndPassword("TestUser", "TestPassword");
            ClassicAssert.IsNotNull(user);
            ClassicAssert.AreEqual("TestUser", user.UserName);
        }

        /// <summary>
        /// Tests the GetAllUsers method
        /// </summary>

        [Test]
        public void GetAllUsersTest()
        {
            // Test getting all users
            var users = userBusiness.GetAllUsers();
            ClassicAssert.IsNotNull(users);
            ClassicAssert.AreEqual(3, users.Count());
            ClassicAssert.AreEqual("TestUser", users[0].UserName);
        }

        /// <summary>
        /// Tests the UpdateUser method when it should pass
        /// </summary>

        [Test]
        public void UpdateUserPassTest()
        {
            // Test updating a user
            var user = userBusiness.GetUserById(1);
            user.UserName = "UpdatedUser";
            string message = userBusiness.UpdateUser(user);
            context.SaveChanges();

            var updatedUser = userBusiness.GetUserById(1);
            ClassicAssert.IsNotNull(updatedUser);
            ClassicAssert.AreEqual("UpdatedUser", updatedUser.UserName);
            ClassicAssert.AreEqual($"User: {updatedUser.UserName} updated successfully!",message);
        }

        /// <summary>
        /// Tests the UpdateUser method when it should fail
        /// </summary>

        [Test]
        public void UpdateUserFailTest()
        {
            // Test updating a user with invalid id
            User testUser = new User
            {
                UserId = 5,
                UserName = "UpdatedUserFail",
                Password = "UpdatedPasswordFail",
                Email = "UpdatedEmail@testFail"
            };
            userBusiness.UpdateUser(testUser);
            context.SaveChanges();


        }

        /// <summary>
        /// Tests the DeleteUser method when it should pass
        /// </summary>

        [Test]
        public void DeleteUserPassTest()
        {
            // Test deleting a user
            var user = userBusiness.GetUserById(1);
            string message = userBusiness.DeleteUser(user);
            context.SaveChanges();

            var deletedUser = userBusiness.GetUserById(1);
            ClassicAssert.IsNull(deletedUser);
            ClassicAssert.AreEqual($"User: {user.UserName} deleted successfully!", message);
        }

        /// <summary>
        /// Tests the DeleteUser method when it should fail
        /// </summary>

        [Test]
        public void DeleteUserFailTest()
        {
            // Test deleting a user with invalid id
            User testUser = new User
            {
                UserId = 5,
                UserName = "DeletedUserFail",
                Password = "DeletedPasswordFail",
                Email = "DeletedEmail@testFail"
            };
            string message = userBusiness.DeleteUser(testUser);
            context.SaveChanges();

            ClassicAssert.AreEqual($"User with Name: {testUser.UserName} not found!", message);
        }

        /// <summary>
        /// Tests the GetUserByUsername method when it should pass
        /// </summary>

        [Test]
        public void GetAllUsersByUserNamePassTest()
        {
            // Test getting all users by username
            var user = userBusiness.GetUserByUsername("TestUser");
            ClassicAssert.IsNotNull(user);
            ClassicAssert.AreEqual("TestUser", user.UserName);
        }

        /// <summary>
        /// Tests the GetUserByUsername method when it should fail
        /// </summary>

        [Test]
        public void GetAllUsersByUserNameFailTest()
        {
            // Test getting all users by invalid username
            var user = userBusiness.GetUserByUsername("InvalidUser");
            ClassicAssert.IsNull(user);
        }

        [TearDown]
        public void Finish()
        {
            connection.Dispose();
            context.Dispose();
        }
    }
}
