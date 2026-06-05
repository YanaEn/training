using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;

namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactEditTest : AuthTestBase
    {


        [Test]
        public void ContactEditTests()
        {
            ContactData contact1 = new ContactData("1112", "2223");
            ContactData contact2 = new ContactData("111", "222");
            if (!app.Contact.IsElementPresent(By.XPath("//img[@alt='Edit']")))
            {
                app.Navigator.GoToAddNewContact();
                app.Contact.AddContact(contact1);
                app.Navigator.OpenHomePage();
            }
            app.Contact.EditFirstContact(contact2);
            app.Navigator.OpenHomePage();

        }
    }
}
