using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactEditTest : TestBase
    {


        [Test]
        public void ContactEditTests()
        {
            app.Contact
                .SelectContact("7")
                .OpenEditPage() 
                .Contact(new ContactData("1112", "2223"))
                .UpdateContact();   
            app.Navigator.OpenHomePage();
            app.Auth.Logout();

        }
    }
}
