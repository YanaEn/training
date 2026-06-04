using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactAddTest : AuthTestBase
    {
     

    [Test]
    public void ContactAddTests()
        {
            app.Navigator.GoToAddNewContact();
            app.Contact
                .Contact(new ContactData("111","222"))
                .SaveContact();
            app.Navigator.OpenHomePage();
         //   app.Auth.Logout(); 

        }
    }
}
