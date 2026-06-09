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
    public class ContactDeleteTest : AuthTestBase
    {


        [Test]
        public void ContactDeleteTests()
        {
            ContactData contact1 = new ContactData("1112", "2223");
            if (!app.Contact.IsAnyContactSelected())
            {
                app.Navigator.GoToAddNewContact();
                app.Contact.AddContact(contact1);
                app.Navigator.OpenHomePage();
            }
            List<ContactData> oldContacts = app.Contact.GetContactList();
            app.Contact.DeleteFirstContact();
            app.Navigator.OpenHomePage();
            List<ContactData> newContacts = app.Contact.GetContactList();
            oldContacts.RemoveAt(0);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.That(oldContacts, Is.EquivalentTo(newContacts));

        }
    }
}
