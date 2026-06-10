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
            // driver.FindElement(By.LinkText("group page")).Click();
            driver.FindElement(By.LinkText("groups")).Click();
            return this;
        }

        public GroupHelper SabmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            groupCache = null;
            return this;
        }

        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])["+index+"]")).Click();
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
            groupCache = null;
            return this;
        }
        public GroupHelper DeleteGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            groupCache = null;
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
            SelectGroup(1)
                .RedactorGroup()
                .FillGroupForm(group)
                .UpdateGroup()
                .ReturnToGroupsPage();
            return this;
        }
        public GroupHelper DeleteFirstGroup()
        {
            SelectGroup(1)
                .DeleteGroup()
                .ReturnToGroupsPage();
            return this;
        }

        private List<GroupData> groupCache = null;
        public List<GroupData> GetGroupList()
        {
            if (groupCache == null)
            {
                groupCache = new List<GroupData>();
                List<GroupData> groups = new List<GroupData>();
                //app.Navigator.GoToGroupsPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
                foreach (IWebElement element in elements)
                {
                    groupCache.Add(new GroupData(element.Text)
                    { Id = element.FindElement(By.TagName("input")).GetAttribute("value") });
                }
                // return groups;
            }
            return new List<GroupData>(groupCache);

        }
        public bool IsAnyGroupSelected()
        {
            return driver.FindElements(By.Name("selected[]")).Count > 0;
        }
        
        public int GetGroupCount()
        {
            return driver.FindElements(By.CssSelector("span.group")).Count;
        }
    }
}
