using UserBackend.Controllers;
using UserBackend.Data;
using UserBackend.Modals;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xunit;
using System.Collections.Generic;
using System;

namespace UserUnitTesting
{
    public class UserControllerTest
    {
        private readonly UserDbContext _context;
        private readonly UsersController controller;
        private EncryptionHandler _encryptionHandler = new EncryptionHandler();
        private List<User> _users = new List<User>();

        public UserControllerTest()
        {
            var options = new DbContextOptionsBuilder<UserDbContext>()
                .UseInMemoryDatabase(databaseName: "Db")
                .Options;
            _context = new UserDbContext(options);
            _context.Database.EnsureDeleted();
            _context.Users.AddRange(seed());
            _context.SaveChanges();

            controller = new UsersController(_context);
        }

        private List<User> seed()
        {
            byte[] salt = _encryptionHandler.AddSalt();

            List<User> users = new List<User>
            {
                new User
                {
                    Id = 1,
                    IsAdmin = true,
                    FirstName = "Jeffrey",
                    LastName = "Nijkamp",
                    Email = "user@example.com",
                    Salt = Convert.ToBase64String(salt),
                    Password = _encryptionHandler.hash("admin",salt)
                },
                new User
                {
                    Id = 2,
                    IsAdmin = false,
                    FirstName = "Jeff",
                    LastName = "Jeffers",
                    Email = "user1@example.com",
                    Salt = Convert.ToBase64String(salt),
                    Password = _encryptionHandler.hash("user",salt)
                },
                new User
                {
                    Id = 3,
                    IsAdmin = false,
                    FirstName = "Cheff",
                    LastName = "Jeff",
                    Email = "cheffjeff@example.com",
                    Salt = Convert.ToBase64String(salt),
                    Password = _encryptionHandler.hash("Orien",salt)
                }
            };

            _users = users;
            return users;
        }

        [Fact]
        public async void GetAllUsers()
        {
            // Arrange

            // Act
            var response = await controller.GetAll();
            List<User>? users = (List<User>?)response;

            // Assert
            Assert.NotNull(users);
            Assert.Equal(_users, users);
        }

        [Fact]
        public async void GetUser_Return_User()
        {
            // Arrange

            // Act
            var response = await controller.GetUserOne(1);
            var result = (ObjectResult)response;
            User? user = (User?)result.Value;

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(user);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal(_users[0], user);
        }

        [Fact]
        public async void GetUser_Return_User_NotFount()
        {
            // Arrange

            // Act
            var response = await controller.GetUserOne(500);
            var result = (NotFoundResult)response;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(404, result.StatusCode);
        }

        [Fact]
        public async void Admin_login()
        {
            // Arrange
            AuthModel info = new AuthModel { Email = "user@example.com", Password = "admin" };

            // Act
            var response = await controller.GetAdmin(info);
            var result = (ObjectResult)response;
            User? user = (User?)result.Value;

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(user);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal(_users[0], user);
        }

        [Fact]
        public async void Admin_login_BadEmail()
        {
            // Arrange
            AuthModel info = new AuthModel { Email = "peter@example.com", Password = "admin" };

            // Act
            var response = await controller.GetAdmin(info);
            var result = (BadRequestObjectResult)response;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(400, result.StatusCode);
        }

        [Fact]
        public async void Admin_login_BadPassword()
        {
            // Arrange
            AuthModel info = new AuthModel { Email = "user@example.com", Password = "Jeffrey" };

            // Act
            var response = await controller.GetAdmin(info);
            var result = (BadRequestObjectResult)response;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(400, result.StatusCode);
        }

        [Fact]
        public async void Admin_login_NotAdmin()
        {
            // Arrange
            AuthModel info = new AuthModel { Email = "cheffjeff@example.com", Password = "Orien" };

            // Act
            var response = await controller.GetAdmin(info);
            var result = (BadRequestObjectResult)response;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(400, result.StatusCode);
        }

        [Fact]
        public async void User_login()
        {
            // Arrange
            AuthModel info = new AuthModel { Email = "user@example.com", Password = "admin" };

            // Act
            var response = await controller.GetUser(info);
            var result = (ObjectResult)response;
            User? user = (User?)result.Value;

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(user);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal(_users[0], user);
        }

        [Fact]
        public async void User_login_BadEmail()
        {
            // Arrange
            AuthModel info = new AuthModel { Email = "peter@example.com", Password = "admin" };

            // Act
            var response = await controller.GetUser(info);
            var result = (BadRequestObjectResult)response;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(400, result.StatusCode);
        }

        [Fact]
        public async void User_login_BadPassword()
        {
            // Arrange
            AuthModel info = new AuthModel { Email = "user@example.com", Password = "Jeffrey" };

            // Act
            var response = await controller.GetUser(info);
            var result = (BadRequestObjectResult)response;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(400, result.StatusCode);
        }

        [Fact]
        public async void SignUp()
        {
            // Arrange
            User newUser = new User { 
                Id = 100,
                FirstName = "Kira",
                LastName = "Kloks",
                Email = "kirakloks@mail.com",
                Password = "Kira"
            };

            // Act
            var response = await controller.SignUp(newUser);
            var result = (ObjectResult)response;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(201, result.StatusCode);
        }

        [Fact]
        public async void SignUp_Eamil_Inuse()
        {
            // Arrange
            User newUser = new User
            {
                Id = 100,
                FirstName = "Kira",
                LastName = "Kloks",
                Email = "user@example.com",
                Password = "Kira"
            };

            // Act
            var response = await controller.SignUp(newUser);
            var result = (BadRequestObjectResult)response;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(400, result.StatusCode);
        }

        [Fact]
        public async void Delete_User()
        {
            // Arrange

            // Act
            var response = await controller.DeleteUser(1);
            var result = (NoContentResult)response;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(204, result.StatusCode);
        }

        [Fact]
        public async void Delete_User_BadId()
        {
            // Arrange

            // Act
            var response = await controller.DeleteUser(150);
            var result = (BadRequestResult)response;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(400, result.StatusCode);
        }

        [Fact]
        public async void Update_User()
        {
            // Arrange
            
            var response = await controller.UpdateUser(44, new User
            {
                Id = 43,
                FirstName = "Kira",
                LastName = "Klokhuis",
                Email = "kiraklokhuis@mail.com",
                Password = "Kira"
            });
            var result = (BadRequestObjectResult)response;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(400, result.StatusCode);
        }
    }
}