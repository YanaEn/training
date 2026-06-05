using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace WebAddressBookTests
{
    [TestFixture]
    public class GroupDeleteTests : AuthTestBase
    {


        [Test]
        public void GroupDeleteTest()
        {
            app.Navigator.GoToGroupsPage();
            GroupData group = new GroupData("name1");
            group.Header = "header1";
            group.Footer = "footer1";
            if (!app.Group.IsElementPresent(By.Name("selected[]")))
            {
                app.Group.CreateGroup(group);
            }
            app.Navigator.GoToGroupsPage();
            app.Group.DeleteFirstGroup();
        }
    }
}

