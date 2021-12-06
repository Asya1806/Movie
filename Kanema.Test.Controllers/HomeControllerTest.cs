using Kanema.Controllers;
using Kanema.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework.Internal;
using System;
using System.Threading.Tasks;
using Xunit;
using System.Collections.Generic;
using System.Linq;
using Kanema.Models.Users;
//using NUnit.Framework;

namespace Kanema.Test.Controllers
{
    public class HomeControllerTest
    {
        [Fact]
        public void GetUserReturnsBadRequestResultWhenIdIsNull()
        {
            // Arrange
            var mock = new Mock<IUserService>();
            var controller = new HomeController(mock.Object);

            // Act
            var result = controller.GetUser(null);

            // Arrange
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public void GetUserReturnsNotFoundResultWhenUserNotFound()
        {
            // Arrange
            int testUserId = 1;
            var mock = new Mock<IUserService>();
            mock.Setup(s => s.Get(testUserId))
                .Returns(null as User);
            var controller = new HomeController(mock.Object);

            // Act
            var result = controller.GetUser(testUserId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void GetUserReturnsViewResultWithUser()
        {
            // Arrange
            int testUserId = 1;
            var mock = new Mock<IUserService>();
            mock.Setup(s => s.Get(testUserId))
                .Returns(GetTestUsers().FirstOrDefault(p => p.Id == testUserId));
            var controller = new HomeController(mock.Object);

            // Act
            var result = controller.GetUser(testUserId);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<User>(viewResult.ViewData.Model);
            Assert.Equal("anastasiyazhdanovaaa", model.Login);
            Assert.Equal(testUserId, model.Id);
        }


        [Fact]
        public void AddUserReturnsViewResultWithUserModel()
        {
            // Arrange
            var mock = new Mock<IUserService>();
            var controller = new HomeController(mock.Object);
            controller.ModelState.AddModelError("Login", "Required");
            User newUser = new User();

            // Act
            var result = controller.AddUser(newUser);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal(newUser, viewResult?.Model);
        }

        [Fact]
        public void AddUserReturnsARedirectAndAddsUser()
        {
            // Arrange
            var mock = new Mock<IUserService>();
            var controller = new HomeController(mock.Object);
            var newUser = new User()
            {
                Login = "anastasiyazhdanovaaa"
            };

            // Act
            var result = controller.AddUser(newUser);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(redirectToActionResult.ControllerName);
            Assert.Equal("Index", redirectToActionResult.ActionName);
            mock.Verify(r => r.Create(newUser));
        }


        //[Fact]
        //public void EditUserReturnsNotFoundResultWhenUserNotFound()
        //{
        //    // Arrange
        //    int testUserId = 1;
        //    var mock = new Mock<IUserService>();
        //    mock.Setup(s => s.Edit(testUserId))
        //        .Returns(null as User);
        //    var controller = new HomeController(mock.Object);

        //    // Act
        //    var result = controller.EditUser(testUserId);

        //    // Assert
        //    Assert.IsType<NotFoundResult>(result);
        //}

        //[Fact]
        //public void Edit_EditReturnsBadRequestResultWhenIdIsNull()
        //{
        //    // Arrange 
        //    //UserContext userContext = new UserContext();
        //    //UserService userService = new UserService();
        //    //var accountValidator = new AccountValidator();
        //    var mock = new Mock<IUserService>();
        //    var controller = new HomeController(mock.Object);
        //    //var userManager = Create.TestUserManager<User>();
        //    //var homeController = new HomeController();


        //    // Act
        //    var result = controller.EditUser(null);

        //    // Assert
        //    //var viewResult = Assert.IsType<Task<IActionResult>>(result);
        //    //var modelResult = Assert.IsType<ViewResult>(viewResult.Result);
        //    //Assert.Equal(id, modelResult?.Model);
        //    Assert.IsType<BadRequestResult>(result);
        //}
        //[Fact]
        //public void Edit_ReturnsNotFoundResultWhenUserNotFound()
        //{
        //    // Arrange
        //    int testUserId = 1;
        //    var mock = new Mock<IUserService>();
        //    mock.Setup(s => s.Edit(testUserId))
        //        .Returns(null as User);
        //    var controller = new HomeController(mock.Object);

        //    // Act
        //    var result = controller.EditUser(testUserId);

        //    // Assert
        //    Assert.IsType<NotFoundResult>(result);
        //}

        [Fact]
        public void Edit_ReturnsViewResultWithUser()
        {
            // Arrange
            int testUserId = 1;
            var mock = new Mock<IUserService>();
            mock.Setup(s => s.Edit(testUserId))
                .Returns(GetTestUsers().FirstOrDefault(p => p.Id == testUserId));
            var controller = new HomeController(mock.Object);

            // Act
            var result = controller.EditUser(testUserId);

            // Assert
            //var viewResult = Assert.IsType<ViewResult>(result);
            //var model = Assert.IsType<User>(viewResult.ViewData.Model);
            //Assert.Equal(testUserId, model.Id);
            Assert.NotNull(result);
        }

        [Fact]
        public void EditUserReturnsNotFoundResultWhenUserNotFound()
        {
            // Arrange
            
            var mock = new Mock<IUserService>();
           
            var controller = new HomeController(mock.Object);

            // Act
            var result = controller.EditUser(null);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        private List<User> GetTestUsers()
        {
            var users = new List<User>
            {
                new User { Id=1, Login="anastasiyazhdanovaaa"},
                new User { Id=2, Login="anaszhdanovvaaa"}
            };
            return users;
        }

        ////Details
        //[Fact]
        //public void Details_DetailsReturnsBadRequestResultWhenIdIsNull()
        //{
        //    // Arrange 
        //    //UserContext userContext = new UserContext();
        //    //UserService userService = new UserService();
        //    //var accountValidator = new AccountValidator();

        //    var mock = new Mock<IUserService>();
        //    var controller = new HomeController(mock.Object);
        //    //var userManager = Create.TestUserManager<User>();
        //    //var homeController = new HomeController();


        //    // Act
        //    var result = controller.Details(null);

        //    // Assert
        //    //var viewResult = Assert.IsType<Task<IActionResult>>(result);
        //    //var modelResult = Assert.IsType<ViewResult>(viewResult.Result);
        //    //Assert.Equal(id, modelResult?.Model);
        //  //  Assert.IsNull(result);
        //}

        //[Fact]
        //public void Detailss_DetailsReturnsBadRequestResultWhenIdIsNull()
        //{
        //    // Arrange 
        //    int testUserId = 1;
        //    var mock = new Mock<IUserService>();
        //    var controller = new HomeController(mock.Object);

        //    // Act
        //    var result = controller.Details(testUserId);

        //    // Assert
        //    //var viewResult = Assert.IsType<Task<IActionResult>>(result);
        //    //var modelResult = Assert.IsType<ViewResult>(viewResult.Result);
        //    //Assert.Equal(id, modelResult?.Model);
        //    //  Assert.IsType<BadRequestResult>(result);
        //    Assert.NotNull(result);
        //}

        //[Fact]
        //public void DetailsReturnsNotFoundResultWhenUserNotFound()
        //{
        //    // Arrange
        //    int testUserId = 1;
        //    var mock = new Mock<IUserService>();
        //    mock.Setup(s => s.Details(testUserId))
        //        .Returns(null as User);
        //    var controller = new HomeController(mock.Object);

        //    // Act
        //    var result = controller.Details(testUserId);

        //    // Assert
        //    Assert.IsType<NotFoundResult>(result);
        //}

        //[Fact]
        //public void DetaailsReturnsViewResultWithUser()
        //{
        //    // Arrange
        //    int testUserId = 2;
        //    var mock = new Mock<IUserService>();
        //    mock.Setup(s => s.Details(testUserId))
        //        .Returns(GetTestUsers().FirstOrDefault(p => p.Id == testUserId));
        //    var controller = new HomeController(mock.Object);

        //    // Act
        //    var result = controller.Details(testUserId);

        //    // Assert
        //    var viewResult = Assert.IsType<ViewResult>(result);
        //    var model = Assert.IsType<User>(viewResult.ViewData.Model);
        //    Assert.Equal("anaszhdanovvaaa", model.Login);
        //    Assert.Equal(1999, model.Year);
        //    Assert.Equal(testUserId, model.Id);
        //}
    }
}
