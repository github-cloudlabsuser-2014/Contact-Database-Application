using CRUD_application_2.Controllers;
using CRUD_application_2.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Web.Mvc;
//a
namespace CRUD_application_2.Tests.Controllers
{
    [TestClass]
    public class UserControllerTest
    {
        private UserController _controller;

        [TestInitialize]
        public void Setup()
        {
            var users = new List<User>
            {
                new User { Id = 1, Name = "User1", Email = "user1@example.com" },
                new User { Id = 2, Name = "User2", Email = "user2@example.com" },
                new User { Id = 3, Name = "User3", Email = "user3@example.com" },
            };

            _controller = new UserController(users);
        }

        [TestMethod]
        public void Index_ReturnsCorrectView_WithAllUsers()
        {
            var result = _controller.Index() as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(UserController.userlist, result.Model);
        }


        [TestMethod]
        public void Create_AddsUser_AndRedirectsToIndex()
        {
            var newUser = new User { Id = 4, Name = "User4", Email = "user4@example.com" };

            var result = _controller.Create(newUser) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.AreEqual(1, UserController.userlist.Count);
            Assert.AreEqual(newUser, UserController.userlist[0]);
        }

        // Add tests for Edit and Delete actions
    }
}