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
            expectedContact.Address = "Line 1\nLine 2\nLine 3";
            expectedContact.HomePhone = "111";
            expectedContact.MobilePhone = "222";
            expectedContact.WorkPhone = "333";

            if (!app.Contact.IsAnyContactSelected())
            {
                app.Navigator.GoToAddNewContact();
                app.Contact.AddContact(expectedContact);
                app.Navigator.OpenHomePage();
            }

            var contacts = app.Contact.GetContactList();
            string id = contacts[0].Id;

            Console.WriteLine($"Проверяем контакт ID={id}");

            app.Contact.EditContactById(id);
            ContactData contactFromForm = app.Contact.GetContactInformationFromForm(id);

            string expectedViewString = app.Contact.GetContactFromViewPage(contactFromForm);

            app.Navigator.OpenHomePage();
            app.Contact.OpenViewPageById(id);

            var contentDiv = app.Driver.FindElement(By.Id("content"));
            string actualViewStringRaw = contentDiv.Text;

            string NormalizeToSingleSpaces(string input)
            {
                if (string.IsNullOrEmpty(input)) return input;

                input = input.Replace("\n", " ").Replace("\r", " ").Replace("\t", " ");

                while (input.Contains("  "))
                {
                    input = input.Replace("  ", " ");
                }

                return input.Trim();
            }

            string expectedNormalized = NormalizeToSingleSpaces(expectedViewString);
            string actualNormalized = NormalizeToSingleSpaces(actualViewStringRaw);

            Assert.That(actualNormalized, Is.EqualTo(expectedNormalized),
                $"Строки не совпадают после нормализации!\n\nОжидалось:\n{expectedNormalized}\n\nПолучено:\n{actualNormalized}");

        }
    }
}
