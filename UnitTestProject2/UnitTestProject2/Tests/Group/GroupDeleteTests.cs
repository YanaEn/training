using NUnit.Framework;
using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace WebAddressBookTests
{
    [TestFixture]
    public class GroupDeleteTests : TestBase
    {


        [Test]
        public void GroupDeleteTest()
        {
            app.Navigator.GoToGroupsPage();
            GroupData group = new GroupData("name2");
            group.Header = "header2";
            group.Footer = "footer2";
            app.Group
                .SelectGroup()  
                .DeleteGroup()    
                .ReturnToGroupsPage();
            app.Auth.Logout();
        }
    }
}

