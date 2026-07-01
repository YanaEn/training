using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml.Serialization;

namespace WebAddressBookTests
{

    [TestFixture]
    public class ContactAddTest : ContactTestBase
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

        public static IEnumerable<ContactData> ContactDataFromXmlFile()
        {
            List<ContactData> contacts = new List<ContactData>();
            return (List<ContactData>)
                new XmlSerializer(typeof(List<ContactData>))
                .Deserialize(new StreamReader(@"contacts.xml"));
        }

        public static IEnumerable<ContactData> ContactDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<ContactData>>(
                File.ReadAllText(@"contacts.json"));
        }

        [Test, TestCaseSource("ContactDataFromJsonFile")]
    public void ContactAddTests(ContactData contact)
        {
            List<ContactData> oldContacts = ContactData.GetAll();
            //  ContactData contact1 = new ContactData("1112", "2223");
            app.Navigator.GoToAddNewContact();
            app.Contact.AddContact(contact);
            app.Navigator.OpenHomePage();
            Assert.That(app.Contact.GetContactCount(), Is.EqualTo(oldContacts.Count + 1));
            List<ContactData> newContacts = ContactData.GetAll();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.That(oldContacts, Is.EquivalentTo(newContacts));

        }
    }
}
