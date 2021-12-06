using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Kanema.Test.Controllers
{
    class UserManager
    {
        public static UserManager<TUser> TestUserManager<TUser>() where TUser : class
        {
            Mock<IUserPasswordStore<TUser>> userPasswordStore = new Mock<IUserPasswordStore<TUser>>();
            userPasswordStore.Setup(s => s.CreateAsync(It.IsAny<TUser>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(IdentityResult.Success));

            var options = new Mock<IOptions<IdentityOptions>>();
            var idOptions = new IdentityOptions();

            //this should be keep in sync with settings in ConfigureIdentity in WebApi -> Startup.cs
            idOptions.Lockout.AllowedForNewUsers = true;
            idOptions.Password.RequireDigit = false;
            idOptions.Password.RequireLowercase = false;
            idOptions.Password.RequireNonAlphanumeric = false;
            idOptions.Password.RequireUppercase = false;
            idOptions.Password.RequiredLength = 8;
            idOptions.Password.RequiredUniqueChars = 0;
            idOptions.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";

            idOptions.SignIn.RequireConfirmedEmail = false;

            // Lockout settings.
            idOptions.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            idOptions.Lockout.MaxFailedAccessAttempts = 5;
            idOptions.Lockout.AllowedForNewUsers = true;


            options.Setup(o => o.Value).Returns(idOptions);
            var userValidators = new List<IUserValidator<TUser>>();

            UserValidator<TUser> validator = new UserValidator<TUser>();

            userValidators.Add(validator);

            var passValidator = new PasswordValidator<TUser>();
            var pwdValidators = new List<IPasswordValidator<TUser>>();
            pwdValidators.Add(passValidator);
            var userManager = new UserManager<TUser>(userPasswordStore.Object, options.Object, new PasswordHasher<TUser>(),
                userValidators, pwdValidators, new UpperInvariantLookupNormalizer(),
                new IdentityErrorDescriber(), null,
                new Mock<ILogger<UserManager<TUser>>>().Object);
            return userManager;
        }

    }
}
