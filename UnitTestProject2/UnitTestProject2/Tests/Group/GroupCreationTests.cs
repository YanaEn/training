using NUnit.Framework;
using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;

namespace WebAddressBookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
        

        [Test]
        public void GroupCreationTest()
        {
            app.Navigator.GoToGroupsPage();
            List<GroupData> oldGroups = app.Group.GetGroupList();
            GroupData group = new GroupData("name1");
            group.Header = "header1";
            group.Footer = "footer1";
            app.Group.CreateGroup(group);
            Assert.That(app.Group.GetGroupCount(), Is.EqualTo(oldGroups.Count + 1));
            List<GroupData> newGroups = app.Group.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            //Assert.That(newGroups.Count, Is.EqualTo(oldGroups.Count));
            Assert.That(oldGroups, Is.EquivalentTo(newGroups));
        }   
    }
}

