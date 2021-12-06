using Kanema.Controllers;
using Kanema.Models;
using Kanema.Models;
using Kanema.Models.Users;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Kanema.Test.Controllers
{
    public class AccountControllerTest
    {
        [Fact]
        public void Register_RegisterNewUser_Register()
        {
            // Arrange 
            //UserService userService = new UserService(userContext);
            var mock = new Mock<IUserService>();
            var accountValidator = new AccountValidator();
            var accountController = new AccountController(mock.Object, accountValidator);
            accountController.ModelState.AddModelError("", "Required");
            RegisterModel registerModel = new RegisterModel() { Login = "anastasiya_zhdanova_02@mail.ru", Password = "qwertyuiop", ConfirmPassword = "qwertyuiop", Year = 1995 };

            // Act
            var result = accountController.Register(registerModel);

            // Assert
            var viewResult = Assert.IsType<Task<IActionResult>>(result);
            var modelResult = Assert.IsType<ViewResult>(viewResult.Result);
            Assert.Equal(registerModel, modelResult?.Model);
        }

        [Fact]
        public void Register_RegisterNewUserWithoutLogin_RegisterViewMpdel()
        {
            // Arrange 
            var mock = new Mock<IUserService>();
            var accountValidator = new AccountValidator();
            var accountController = new AccountController(mock.Object, accountValidator);
            accountController.ModelState.AddModelError("", "Required");
            RegisterModel registerModel = new RegisterModel()
            { Password = "qwertyuiop", ConfirmPassword = "qwert", Year = 1995 };

            // Act
            var result = accountController.Register(registerModel);

            // Assert
            var viewResult = Assert.IsType<Task<IActionResult>>(result);
            var modelResult = Assert.IsType<ViewResult>(viewResult.Result);
            Assert.Equal(registerModel, modelResult?.Model);
        }

        [Fact]
        public void Register_RegisterNewUserWithUncorrectData_RegisterViewModel()
        {
            // Arrange 
            var mock = new Mock<IUserService>();
            //UserService userService = new UserService();
            var accountValidator = new AccountValidator();
            var accountController = new AccountController(mock.Object, accountValidator);
            RegisterModel registerModel = new RegisterModel()
            { Login = "anastasiya_zhdanova_02@mail.ru", Password = "qwertyuiop", ConfirmPassword = "qwert", Year = 1995 };

            // Act
            var result = accountController.Register(registerModel);

            // Assert
            var viewResult = Assert.IsType<Task<IActionResult>>(result);
            var modelResult = Assert.IsType<ViewResult>(viewResult.Result);
            Assert.Equal(registerModel, modelResult?.Model);
        }

        // Login

        [Fact]
        public void Login_LoginAuthorization_Login()
        {
            // Arrange 
            var mock = new Mock<IUserService>();
            var accountValidator = new AccountValidator();
            var accountController = new AccountController(mock.Object, accountValidator);
            LoginModel loginModel = new LoginModel() { Login = "anastasiya_zhdanova_02@mail.ru", Password = "qwertyuiop" };

            // Act
            var result = accountController.Login(loginModel, "Index");

            // Assert
            var viewResult = Assert.IsType<Task<IActionResult>>(result);
            var modelResult = Assert.IsType<ViewResult>(viewResult.Result);
            Assert.Equal(loginModel, modelResult?.Model);
        }

        [Fact]
        public void Login_LoginNewUserWithoutLogin_LoginViewMpdel()
        {
            // Arrange 
            var mock = new Mock<IUserService>();
            var accountValidator = new AccountValidator();
            var accountController = new AccountController(mock.Object, accountValidator);
            accountController.ModelState.AddModelError("", "Login claimed.");
            LoginModel loginModel = new LoginModel() { Password = "qwertyuiop" };

            // Act
            var result = accountController.Login(loginModel,"Index");

            // Assert
            var viewResult = Assert.IsType<Task<IActionResult>>(result);
            var modelResult = Assert.IsType<ViewResult>(viewResult.Result);
            Assert.Equal(loginModel, modelResult?.Model);
        }

        [Fact]
        public void Login_LoginUserWithUncorrectData_LoginViewModel()
        {
            // Arrange 
            var mock = new Mock<IUserService>();
            //UserService userService = new UserService();
            var accountValidator = new AccountValidator();
            var accountController = new AccountController(mock.Object, accountValidator);
            LoginModel loginModel = new LoginModel()
            { Login = "anastasiya_zhdanova_02@mail.ru", Password = "qwert" };

            // Act
            var result = accountController.Login(loginModel,"Index");

            // Assert
            var viewResult = Assert.IsType<Task<IActionResult>>(result);
            var modelResult = Assert.IsType<ViewResult>(viewResult.Result);
            Assert.Equal(loginModel, modelResult?.Model);


        }
    }
}
