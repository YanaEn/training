using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactAddTest : TestBase
    {
     

    [Test]
    public void ContactAddTests()
        {
            OpenHomePage(); //общий
            Login(new AccountData("admin", "secret"));
            GoToAddNewContact();
            Contact(new ContactData("111","222"));
            SaveContact();
            GoToHomePage(); 
            Logout(); 

        }
    }
}
