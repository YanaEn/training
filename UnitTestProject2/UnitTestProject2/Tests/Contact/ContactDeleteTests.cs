using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactDeleteTest : TestBase
    {


        [Test]
        public void ContactDeleteTests()
        {
            app.Contact
                .SelectContact("4")
                .DeleteContact();
            app.Navigator.OpenHomePage();
            app.Auth.Logout();

        }
    }
}
