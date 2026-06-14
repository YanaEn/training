using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAddressBookTests;


namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactViewComparisonTest : AuthTestBase
    {
        [Test]
        public void CompareContactDataOnViewPage()
        {
            ContactData contact1 = new ContactData("1112", "2223");
            if (!app.Contact.IsAnyContactSelected())
            {
                app.Navigator.GoToAddNewContact();
                app.Contact.AddContact(contact1);
                app.Navigator.OpenHomePage();
            }

            app.Navigator.OpenHomePage();
            List<ContactData> contacts = app.Contact.GetContactList();
            ContactData contactFromTable = contacts[0];
            string id = contactFromTable.Id;
            app.Navigator.OpenHomePage();
            app.Contact.OpenViewPageById(id);
            ContactData contactFromViewPage = app.Contact.GetContactFromViewPage();
            Assert.That(contactFromViewPage.Firstname, Is.EqualTo(contactFromTable.Firstname));
            Assert.That(contactFromViewPage.Lastname, Is.EqualTo(contactFromTable.Lastname));
        }
    }
}
