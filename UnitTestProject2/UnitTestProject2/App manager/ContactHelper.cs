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
            return this;
        }

        public ContactHelper Contact(ContactData contact)
        {
            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(contact.Firstname);
            driver.FindElement(By.Name("lastname")).Click();
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(contact.Lastname);
            return this;
        }

        public ContactHelper SelectContact(string contactId)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(35))
       .Until(d => d.FindElement(By.Id(contactId))).Click();
            return this;
        }
        public ContactHelper OpenEditPage()
        {
            driver.FindElement(By.XPath("//img[@alt='Edit']")).Click();
            return this;
        }

        public ContactHelper UpdateContact()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[20]")).Click();
            return this;
        }
        public ContactHelper DeleteContact()
        {
            driver.FindElement(By.Name("delete")).Click();
            return this;
        }
    }
}
