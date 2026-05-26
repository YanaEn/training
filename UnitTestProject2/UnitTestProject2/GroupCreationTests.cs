using NUnit.Framework;
using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace WebAddressBookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
        

        [Test]
        public void GroupCreationTest()
        {
            OpenHomePage();
            Login(new AccountData("admin","secret"));
            GoToGroupsPage();
            InitGroupCreation();
            GroupData group = new GroupData("name1");
            group.Header = "header1";
            group.Footer = "footer1";
            FillGroupForm(group);
            SabmitGroupCreation();
            ReturnToGroupsPage();
            Logout();
        }   
    }
}

