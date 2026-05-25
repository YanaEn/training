using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressBookTests
{
    internal class Logout
    {
        private IWebDriver driver;

        public Logout(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void PerformLogout()
        {
            if (IsElementPresent(By.LinkText("Logout")))
            {
                driver.FindElement(By.LinkText("Logout")).Click();
            }
        }

        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}

