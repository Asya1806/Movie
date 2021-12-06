//using Kanema.Controllers;
//using Kanema.Models;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Moq;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Xunit;

//namespace Kanema.Test.Controllers
//{
//    public class HandlerYearTest
//    {
//        [Fact]
//        public void Details_DetailsReturnsBadRequestResultWhenIdIsNull()
//        {
//            // Arrange 
//            var year = 2006;
//            var mock = new Mock<IAuthorizationRequirement>();
//            var controller = new AuthorizationHandler<AgeRequirement>;
//            //var userManager = Create.TestUserManager<User>();
//            //var homeController = new HomeController();


//            // Act
//            var result = controller.Details(null);

//            // Assert
//            //var viewResult = Assert.IsType<Task<IActionResult>>(result);
//            //var modelResult = Assert.IsType<ViewResult>(viewResult.Result);
//            //Assert.Equal(id, modelResult?.Model);
//            Assert.IsType<BadRequestResult>(result);
//        }
//    }
//}
