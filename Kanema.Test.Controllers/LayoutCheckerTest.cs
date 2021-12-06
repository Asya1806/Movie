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
    class LayoutCheckerTest
    {
        [TestCase(true, ExpectedResult ="_Authorize")]
        [TestCase(false, ExpectedResult = "_NonAuthorize")]
        public string GetLayoutTest(bool boolean) => LayoutChecker.GetLayout(boolean);
    }
}

    