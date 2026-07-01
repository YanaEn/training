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
    public class GroupDeleteTests : GroupTestBase
    {
        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < 5; i++)
            {
                groups.Add(new GroupData(GenerateRandomString(30))
                {
                    Header = GenerateRandomString(100),
                    Footer = GenerateRandomString(100),
                });
            }
            return groups;
        }

        [Test, TestCaseSource("RandomGroupDataProvider")]
        public void GroupDeleteTest(GroupData group)
        {
            app.Navigator.GoToGroupsPage();
         //   GroupData group = new GroupData("name1");
           // group.Header = "header1";
            //group.Footer = "footer1";
            if (!app.Group.IsAnyGroupSelected())
            {
                app.Group.CreateGroup(group);
                
            }
            app.Navigator.GoToGroupsPage();
            //  List<GroupData> oldGroups = app.Group.GetGroupList();
            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData toBeRemoved = oldGroups[0];
            // app.Group.DeleteFirstGroup();
            app.Group.Remove(toBeRemoved);
            Assert.That(app.Group.GetGroupCount(), Is.EqualTo(oldGroups.Count - 1));

            //List<GroupData> newGroups = app.Group.GetGroupList();
            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups.RemoveAt(0);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.That(oldGroups, Is.EquivalentTo(newGroups));

        }

    }
}

