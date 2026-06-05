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
            ContactData contact1 = new ContactData("1112", "2223");
            app.Navigator.GoToAddNewContact();
            app.Contact.AddContact(contact1);
            app.Navigator.OpenHomePage();
         //   app.Auth.Logout(); 

        }
    }
}
