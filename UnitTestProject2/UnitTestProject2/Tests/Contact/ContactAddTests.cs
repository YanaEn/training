using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactAddTest : AuthTestBase
    {
     

    [Test]
    public void ContactAddTests()
        {
            List<ContactData> oldContacts = app.Contact.GetContactList();
            ContactData contact1 = new ContactData("1112", "2223");
            app.Navigator.GoToAddNewContact();
            app.Contact.AddContact(contact1);
            app.Navigator.OpenHomePage();
            List<ContactData> newContacts = app.Contact.GetContactList();
            oldContacts.Add(contact1);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.That(oldContacts, Is.EquivalentTo(newContacts));

        }
    }
}
