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

        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                contacts.Add(new ContactData(GenerateRandomString(50), GenerateRandomString(50)));
            }
            return contacts;
        }
        [Test, TestCaseSource("RandomContactDataProvider")]
        public void ContactDeleteTests(ContactData contact)
        {
          //  ContactData contact1 = new ContactData("1112", "2223");
            if (!app.Contact.IsAnyContactSelected())
            {
                app.Navigator.GoToAddNewContact();
                app.Contact.AddContact(contact);
                app.Navigator.OpenHomePage();
            }
            List<ContactData> oldContacts = app.Contact.GetContactList();
            app.Contact.DeleteFirstContact();
            app.Navigator.OpenHomePage();
            Assert.That(app.Contact.GetContactCount(), Is.EqualTo(oldContacts.Count - 1));
            List<ContactData> newContacts = app.Contact.GetContactList();
            oldContacts.RemoveAt(0);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.That(oldContacts, Is.EquivalentTo(newContacts));

        }
    }
}
