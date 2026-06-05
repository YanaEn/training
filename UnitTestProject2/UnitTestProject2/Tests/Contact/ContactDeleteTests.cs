using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactDeleteTest : AuthTestBase
    {


        [Test]
        public void ContactDeleteTests()
        {
            ContactData contact1 = new ContactData("1112", "2223");
            if (!app.Contact.IsElementPresent(By.XPath("//img[@alt='Edit']")))
            {
                app.Navigator.GoToAddNewContact();
                app.Contact.AddContact(contact1);
                app.Navigator.OpenHomePage();
            }
            app.Contact.DeleteFirstContact();
            app.Navigator.OpenHomePage();

        }
    }
}
