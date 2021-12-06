using Kanema.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanema.Test.Controllers
{
    [TestFixture]
    class ValidateTest
    {
        [TestCase("asdfg12345", true)]
        [TestCase("R", false)]
        [TestCase("12345", true)]
        [TestCase("ф", false)]
        [TestCase("   ", false)]
        [TestCase("", false)]
        [TestCase("admin_123", true)]
        [TestCase("admin", true)]
        [TestCase("админ", false)]
        [TestCase("admin_admin", true)]
        [TestCase("adminadminadminadminadminadmin", false)]
        public void VarifyLoginTest(string login, bool expected)
        {
            AccountValidator accountValidator = new AccountValidator();
            var actual = accountValidator.VerifyLogin(login);
            Assert.AreEqual(actual, expected);
        }
    }
}
