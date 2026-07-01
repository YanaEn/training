using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WebAddressBookTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(IWebDriver driver) : base(driver)
        {
        }

        public ContactHelper SaveContact()
        {
            driver.FindElement(By.Name("theform")).Click();
            driver.FindElement(By.XPath("//div[@id='content']/form/input[19]")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper Contact(ContactData contact)
        {
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("lastname"), contact.Lastname);
            return this;
        }
        public ContactHelper SelectContact(string id)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]' and @value='" + id + "'])")).Click();
            return this;
        }
        public ContactHelper OpenEditPage()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(35))
       .Until(d => d.FindElement(By.XPath("//img[@alt='Edit']"))).Click();
            return this;
        }

        public ContactHelper UpdateContact()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[20]")).Click();
            contactCache = null;
            return this;
        }
        public ContactHelper DeleteContact()
        {
            driver.FindElement(By.Name("delete")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper Remove(ContactData contact)
        {
            SelectContact(contact.Id)
               .OpenEditPageSpecific(contact.Id)
                .DeleteContact();
            return this;
        }

        private ContactHelper OpenEditPageSpecific(string id)
        {
            string xpath = $"//tr[contains(@name, 'entry') and .//input[@value='{id}']]//img[@alt='Edit']";
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => d.FindElement(By.XPath(xpath))).Click();

            return this;
        }
        public ContactHelper EditFirstContact(ContactData contact)
        {
            OpenEditPage()
            .Contact(contact)
            .UpdateContact();
            return this;
        }

        public ContactHelper EditContact(ContactData contact)
        {
            SelectContact(contact.Id)
            .OpenEditPageSpecific(contact.Id)
            .Contact(contact)
            .UpdateContact();
            return this;
        }
        public ContactHelper AddContact(ContactData contact)
        {
            Contact(contact)
                .SaveContact();
            return this;
        }
        public ContactHelper DeleteFirstContact()
        {
            OpenEditPage()
                .DeleteContact();
            return this;
        }



        public bool IsAnyContactSelected()
        {
            return driver.FindElements(By.XPath("//img[@alt='Edit']")).Count > 0;
        }

        private List<ContactData> contactCache = null;
        public List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                List<ContactData> contacts = new List<ContactData>();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("tr[name='entry']"));
                foreach (IWebElement element in elements)
                {
                    var cells = element.FindElements(By.TagName("td"));
                    contactCache.Add(new ContactData(cells[2].Text.Trim(), cells[1].Text.Trim())
                    {
                        Id = cells[0].FindElement(By.TagName("input")).GetAttribute("value")
                    });
                }
            }
            return new List<ContactData>(contactCache);

        }

        public int GetContactCount()
        {
            return driver.FindElements(By.CssSelector("tr[name='entry']")).Count;
        }

        public ContactHelper EditContactById(string id)
        {
            var row = driver.FindElement(By.XPath($"//tr[contains(@name, 'entry') and .//input[@value='{id}']]"));
            row.FindElement(By.XPath(".//img[@alt='Edit']")).Click();
            return this;
        }
        public ContactHelper OpenViewPageById(string id)
        {
            var link = driver.FindElement(By.XPath($"//a[contains(@href, 'view.php?id={id}')]"));
            link.Click();
            return this;
        }
        public string GetContactFromViewPage(ContactData contact)
        {
            var lines = new List<string>();

            string fullName = $"{contact.Firstname} {contact.Lastname}".Trim();
            if (!string.IsNullOrEmpty(fullName))
                lines.Add(fullName);

            if (!string.IsNullOrEmpty(contact.Address))
            {
                var addressLines = contact.Address.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var line in addressLines)
                {
                    string trimmed = line.Trim();
                    if (!string.IsNullOrEmpty(trimmed))
                        lines.Add(trimmed);
                }
            }

            if (!string.IsNullOrEmpty(contact.HomePhone))
                lines.Add($"H: {contact.HomePhone}");
            if (!string.IsNullOrEmpty(contact.MobilePhone))
                lines.Add($"M: {contact.MobilePhone}");
            if (!string.IsNullOrEmpty(contact.WorkPhone))
                lines.Add($"W: {contact.WorkPhone}");

            return string.Join("\n", lines);
        }


        public ContactData GetContactInformationFromForm(string id)
        {
            string firstname = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastname = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");

            return new ContactData(firstname, lastname)
            {
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone
            };
        }
       
    }
    }
