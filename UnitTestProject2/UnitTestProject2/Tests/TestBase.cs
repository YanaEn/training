using NUnit.Framework;
using OpenQA.Selenium.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressBookTests
{
    [TestFixture]
    public class TestBase
    {

        protected ApplicationManager app;



        [SetUp]
        public void SetupApplicationManager()
        {

            app = ApplicationManager.GetInstance();



        }

        private static readonly Random rnd = new Random(42);
        public static string GenerateRandomString(int max)
        {
            int l = rnd.Next(1, max + 1); 

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            StringBuilder builder = new StringBuilder(l);
            for (int i = 0; i < l; i++) {
                builder.Append(chars[rnd.Next(chars.Length)]);
        }
        return builder.ToString();
    }
    }
}
