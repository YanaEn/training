using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressBookTests
{
    [TestFixture]
    public class LoginTests : TestBase
    {
        [Test]
        public void LoginWithValidCredentials()
        {
            app.Auth.Logout();

            AccountData account = new AccountData("admin","secret");

            app.Auth.Login(account);

            ClassicAssert.IsTrue(app.Auth.IsLoggedIn(account));
        }
        [Test]
        public void LoginWithInValidCredentials()
        {
            app.Auth.Logout();

            AccountData account = new AccountData("admin", "12345");
            app.Auth.Login(account);
            ClassicAssert.IsFalse(app.Auth.IsLoggedIn(account));
        }
    }
}
