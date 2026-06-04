using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactDeleteTest : AuthTestBase
    {


        [Test]
        public void ContactDeleteTests()
        {
            app.Contact
              .OpenEditPage()
                .DeleteContact();
            app.Navigator.OpenHomePage();
          //  app.Auth.Logout();

        }
    }
}
