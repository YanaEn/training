using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace WebAddressBookTests
{
    [TestFixture]
    public class GroupEditTests : GroupTestBase
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
        public void GroupEditTest(GroupData group)
        {
            app.Navigator.GoToGroupsPage();
          //  GroupData group2 = new GroupData("name2");
           // group2.Header = "header2";
            //group2.Footer = "footer2";
          //  GroupData group = new GroupData("name1");
          //  group.Header = "header1";
           // group.Footer = "footer1";

            if (!app.Group.IsAnyGroupSelected())
            {
                app.Group.CreateGroup(group);
            }
            GroupData group2 = new GroupData(GenerateRandomString(10))
            {
                Header = GenerateRandomString(20),
                Footer = GenerateRandomString(20)
            };
            app.Navigator.GoToGroupsPage();
            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData toBeEdited = oldGroups[0];
            group2.Id = toBeEdited.Id;
            app.Group.EditGroup(group2);
            
            Assert.That(app.Group.GetGroupCount(), Is.EqualTo(oldGroups.Count));

            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups[0].Name = group2.Name;
            oldGroups.Sort();
            newGroups.Sort();

            Assert.That(oldGroups, Is.EquivalentTo(newGroups));

        }

    }
}

