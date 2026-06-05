using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace WebAddressBookTests
{
    [TestFixture]
    public class GroupEditTests : AuthTestBase
    {
        
        [Test]
        public void GroupEditTest()
        {
            app.Navigator.GoToGroupsPage();
            GroupData group2 = new GroupData("name2");
            group2.Header = "header2";
            group2.Footer = "footer2";
            GroupData group = new GroupData("name1");
            group.Header = "header1";
            group.Footer = "footer1";
            if (!app.Group.IsElementPresent(By.Name("selected[]")))
            {
                app.Group.CreateGroup(group);
            }
            app.Navigator.GoToGroupsPage();
            app.Group.EditFirstGroup(group2);

        }
    }
}

