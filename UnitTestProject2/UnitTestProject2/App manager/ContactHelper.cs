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
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("lastname"), contact.Lastname);
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
            return this;
        }
        public ContactHelper DeleteContact()
        {
            driver.FindElement(By.Name("delete")).Click();
            return this;
        }
        public ContactHelper EditFirstContact(ContactData contact)
        {
                OpenEditPage()
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
    }
    
    }
