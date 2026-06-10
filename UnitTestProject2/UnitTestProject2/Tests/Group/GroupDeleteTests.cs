using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
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
            if (!app.Group.IsAnyGroupSelected())
            {
                app.Group.CreateGroup(group);
                
            }
            app.Navigator.GoToGroupsPage();
            List<GroupData> oldGroups = app.Group.GetGroupList();
            app.Group.DeleteFirstGroup();
            Assert.That(app.Group.GetGroupCount(), Is.EqualTo(oldGroups.Count - 1));

            List<GroupData> newGroups = app.Group.GetGroupList();
            oldGroups.RemoveAt(0);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.That(oldGroups, Is.EquivalentTo(newGroups));
        }
    }
}

