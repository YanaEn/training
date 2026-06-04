using NUnit.Framework;
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
            GroupData group = new GroupData("name2");
            group.Header = "header2";
            group.Footer = "footer2";
            app.Group
                .SelectGroup()  
                .RedactorGroup()    
                .FillGroupForm(group)
                .UpdateGroup()  
                .ReturnToGroupsPage();
         //   app.Auth.Logout();
        }
    }
}

