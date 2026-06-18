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
        public void ContactEditTests(ContactData contact)
        {
          //  ContactData contact1 = new ContactData("1112", "2223");
          //  ContactData contact2 = new ContactData("111", "222");
            if (!app.Contact.IsAnyContactSelected())
            {
                app.Navigator.GoToAddNewContact();
                app.Contact.AddContact(contact);
                app.Navigator.OpenHomePage();
            }
            ContactData contact2 = new ContactData(GenerateRandomString(20), GenerateRandomString(20));
            
            List<ContactData> oldContacts = app.Contact.GetContactList();
            app.Contact.EditFirstContact(contact2);
            app.Navigator.OpenHomePage();

            Assert.That(app.Contact.GetContactCount(), Is.EqualTo(oldContacts.Count));
            List<ContactData> newContacts = app.Contact.GetContactList();
            oldContacts[0].Firstname = contact2.Firstname;
            oldContacts[0].Lastname = contact2.Lastname;
            oldContacts.Sort();
            newContacts.Sort();

            Assert.That(oldContacts, Is.EquivalentTo(newContacts));

        }
    }
}
