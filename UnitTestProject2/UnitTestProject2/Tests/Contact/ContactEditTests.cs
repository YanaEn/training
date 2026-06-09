using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

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
            List<ContactData> oldContacts = app.Contact.GetContactList();
            app.Contact.EditFirstContact(contact2);
            app.Navigator.OpenHomePage();
            List<ContactData> newContacts = app.Contact.GetContactList();
            oldContacts[0] = contact2;
            oldContacts.Sort();
            newContacts.Sort();

            Assert.That(oldContacts, Is.EquivalentTo(newContacts));

        }
    }
}
