using NUnit.Framework;
using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using System.Xml.Serialization;
using System.Xml;
using Newtonsoft.Json;
using System.Linq;

namespace WebAddressBookTests
{
    [TestFixture]
    public class GroupCreationTests : GroupTestBase
    {
        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i=0; i<5;i++)
            {
                groups.Add(new GroupData(GenerateRandomString(30))
                {
                    Header = GenerateRandomString(100),
                    Footer = GenerateRandomString(100),
                });
            }
            return groups;
        }

        public static IEnumerable<GroupData> GroupDataFromCsvFile()
        {
            List<GroupData> groups = new List<GroupData>();
            string[] lines = File.ReadAllLines(@"groups.csv");
            foreach (string l in lines)
            {
                string[] parts=l.Split(',');
                groups.Add(new GroupData(parts[0])
                {
                    Header = parts[1],
                    Footer = parts[2]
                });
            }
            return groups;
        }
        public static IEnumerable<GroupData> GroupDataFromXmlFile()
        {
            List<GroupData> groups = new List<GroupData>();
            //  string[] lines = File.ReadAllLines(@"groups.xml");
            return (List<GroupData>) 
                new XmlSerializer(typeof(List<GroupData>))
                .Deserialize(new StreamReader(@"groups.xml"));
        }

        public static IEnumerable<GroupData> GroupDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<GroupData>>(
                File.ReadAllText(@"groups.json"));
        }



        [Test, TestCaseSource("GroupDataFromJsonFile")]
        public void GroupCreationTest(GroupData group)
        {
            app.Navigator.GoToGroupsPage();
            List<GroupData> oldGroups = GroupData.GetAll();
            //  GroupData group2 = new GroupData("name1");
            //group.Header = "header1";
            //group.Footer = "footer1";
            app.Group.CreateGroup(group);
            Assert.That(app.Group.GetGroupCount(), Is.EqualTo(oldGroups.Count + 1));
            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            //Assert.That(newGroups.Count, Is.EqualTo(oldGroups.Count));
            Assert.That(oldGroups, Is.EquivalentTo(newGroups));
        }
        [Test]
        public void TestDBConnectivity()
        {
            List<GroupData> fromUI = app.Group.GetGroupList();
            List<GroupData> fromDb = GroupData.GetAll();

        }
    }
}

