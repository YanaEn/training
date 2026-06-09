using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
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

            

            if (!app.Group.IsAnyGroupSelected())
            {
                app.Group.CreateGroup(group);
            }
            app.Navigator.GoToGroupsPage();
            List<GroupData> oldGroups = app.Group.GetGroupList();
            app.Group.EditFirstGroup(group2);

            List<GroupData> newGroups = app.Group.GetGroupList();
            oldGroups[0].Name = group2.Name;
            oldGroups.Sort();
            newGroups.Sort();

            Assert.That(oldGroups, Is.EquivalentTo(newGroups));

        }
    }
}

