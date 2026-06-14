using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using NUnit.Framework;


namespace WebAddressBookTests 
{
    [TestFixture]
    public class ContactComparison : AuthTestBase
    {

        [Test]
        public void ComparisonContact()
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

            Console.WriteLine($"Проверяем контакт ID={id}: {contactFromTable}");

            app.Contact.EditContactById(id);
            string firstnameFromForm = app.Driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastnameFromForm = app.Driver.FindElement(By.Name("lastname")).GetAttribute("value");
            Assert.That(firstnameFromForm, Is.EqualTo(contactFromTable.Firstname));
            Assert.That(lastnameFromForm, Is.EqualTo(contactFromTable.Lastname));

        }
    }
}
