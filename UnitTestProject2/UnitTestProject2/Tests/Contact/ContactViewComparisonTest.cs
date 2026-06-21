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

            app.Navigator.OpenHomePage();
            ContactData expectedContact = new ContactData("1112", "2223");
            expectedContact.Address = "Address";
            expectedContact.HomePhone = "111";
            expectedContact.MobilePhone = "222";
            expectedContact.WorkPhone = "333";
            if (!app.Contact.IsAnyContactSelected())
            {
                app.Navigator.GoToAddNewContact();
                app.Contact.AddContact(expectedContact);
                app.Navigator.OpenHomePage();
            }

            
            List<ContactData> contacts = app.Contact.GetContactList();
            ContactData contactFromTable = contacts[0];
            string id = contactFromTable.Id;
            Console.WriteLine($"Проверяем контакт ID={id}: {contactFromTable}");


            app.Contact.EditContactById(id);
            ContactData contactFromFormPage = app.Contact.GetContactInformationFromForm(id);

            app.Navigator.OpenHomePage();
            app.Contact.OpenViewPageById(id);
            ContactData contactFromViewPage = app.Contact.GetContactFromViewPage();
            string viewDataString = contactFromViewPage.GetConcatenatedData();
            string formDataString = contactFromFormPage.GetConcatenatedData();
            Assert.That(viewDataString, Is.EqualTo(formDataString));


        }
    }
}
