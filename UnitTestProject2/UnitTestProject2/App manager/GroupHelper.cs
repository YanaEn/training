using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WebAddressBookTests
{
    public class GroupHelper : HelperBase

    {
        public GroupHelper(IWebDriver driver) : base(driver) 
        { 
        }
        
        public GroupHelper InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }
        public GroupHelper FillGroupForm(GroupData group)
        {
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
            return this;
        }

        public GroupHelper ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }

        public GroupHelper SabmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public GroupHelper SelectGroup()
        {
            driver.FindElement(By.Name("selected[]")).Click();
            return this;
        }
        public GroupHelper RedactorGroup()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }
        public GroupHelper UpdateGroup()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }
        public GroupHelper DeleteGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            return this;
        }
        public GroupHelper CreateGroup(GroupData group)
        {
            InitGroupCreation()
                .FillGroupForm(group)
                .SabmitGroupCreation()
                .ReturnToGroupsPage();
            return this;
        }
        public GroupHelper EditFirstGroup(GroupData group)
        {
            SelectGroup()
                .RedactorGroup()
                .FillGroupForm(group)
                .UpdateGroup()
                .ReturnToGroupsPage();
            return this;
        }
        public GroupHelper DeleteFirstGroup()
        {
            SelectGroup()
                .DeleteGroup()
                .ReturnToGroupsPage();
            return this;
        }
    }
}
