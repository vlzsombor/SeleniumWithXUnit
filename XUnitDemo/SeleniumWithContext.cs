using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

using System.Collections.Generic;
using Xunit;

namespace XUnitDemo
{
    [Collection("Sequence")]
    public class SeleniumWithContext : IClassFixture<WebDriverFixture>
    {
        private readonly ITestOutputHelper testOutputHelper;

        public SeleniumWithContext(WebDriverFixture webDriverFixture,
            ITestOutputHelper testOutputHelper)
        {
            WebDriverFixture = webDriverFixture;
            this.testOutputHelper = testOutputHelper;
        }

        public WebDriverFixture WebDriverFixture { get; }

        [Fact]
        public void Test1()
        {
            WebDriverFixture.ChromeDriver
                .Navigate()
                .GoToUrl("http://info.cern.ch/");
        }


        [Theory]
        [InlineData("admin", "password")]
        [InlineData("admin2", "password2")]
        public void ClassFixtureTestFillData(string username, string password)
        {
            var driver = WebDriverFixture.ChromeDriver;

            driver
                .Navigate()
                .GoToUrl("http://eaapp.somee.com/");

            driver.FindElement(By.LinkText("Login")).Click();
            driver.FindElement(By.Id("UserName")).SendKeys(username);
            driver.FindElement(By.Id("Password")).SendKeys(password);
            driver.FindElement(By.CssSelector(".btn-default")).Click();
            testOutputHelper.WriteLine("Test completed");
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void TestRegisterUser(string username, string password, string cpassword, string email)
        {
            var driver = WebDriverFixture.ChromeDriver;
            driver
                .Navigate()
                .GoToUrl("http://eaapp.somee.com/");
            driver.FindElement(By.LinkText("Register")).Click();
            driver.FindElement(By.Id("UserName")).SendKeys(username);
            driver.FindElement(By.Id("Password")).SendKeys(password);
            driver.FindElement(By.Id("ConfirmPassword")).SendKeys(cpassword);
            driver.FindElement(By.Id("Email")).SendKeys(email);

            testOutputHelper.WriteLine("Test completed");
        }


        public static IEnumerable<object[]> Data => new List<object[]>()
        {
            new object[]
            {
                "kjaflkjdsakjfkads",
                "Aa123456!",
                "Aa123456!",
                "bafeket254@dmonies.com",
            }
        };


    }
}
