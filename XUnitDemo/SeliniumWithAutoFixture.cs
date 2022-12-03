using AutoFixture;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace XUnitDemo
{
    public class SeliniumWithAutoFixture : IClassFixture<WebDriverFixture>
    {
        private readonly ITestOutputHelper testOutputHelper;

        public SeliniumWithAutoFixture(WebDriverFixture webDriverFixture,
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

        [Fact]
        public void TestRegisterUser()
        {
            var driver = WebDriverFixture.ChromeDriver;
            driver
                .Navigate()
                .GoToUrl("http://eaapp.somee.com/");

            var username = new Fixture().Create<string>();
            var email= new Fixture().Create<string>();
            var password= new Fixture().Create<string>();

            driver.FindElement(By.LinkText("Register")).Click();
            driver.FindElement(By.Id("UserName")).SendKeys(username);
            driver.FindElement(By.Id("Password")).SendKeys(password);
            driver.FindElement(By.Id("ConfirmPassword")).SendKeys(password);
            driver.FindElement(By.Id("Email")).SendKeys(email);

            testOutputHelper.WriteLine("Test completed");
        }

        [Fact]
        public void TestRegisterUserWithType()
        {
            var driver = WebDriverFixture.ChromeDriver;
            driver
                .Navigate()
                .GoToUrl("http://eaapp.somee.com/");


            var fixture = new Fixture();
            var model =
                fixture.Build<RegisterUserModel>()
                .With(x=>x.Email, "a@a.hu")
                .Create();

            var user = new Fixture().Create<RegisterUserModel>();

            driver.FindElement(By.LinkText("Register")).Click();
            driver.FindElement(By.Id("UserName")).SendKeys(user.Name);
            driver.FindElement(By.Id("Password")).SendKeys(user.Password);
            driver.FindElement(By.Id("ConfirmPassword")).SendKeys(user.Password);
            driver.FindElement(By.Id("Email")).SendKeys(user.Email);

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
