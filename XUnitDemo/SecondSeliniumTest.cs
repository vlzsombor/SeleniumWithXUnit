using FluentAssertions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace XUnitDemo
{
    [Collection("Sequence")]
    public class SecondSeliniumTest : IClassFixture<WebDriverFixture>
    {
        private readonly ITestOutputHelper testOutputHelper;

        public SecondSeliniumTest(WebDriverFixture webDriverFixture,
            ITestOutputHelper testOutputHelper)
        {
            WebDriverFixture = webDriverFixture;
            this.testOutputHelper = testOutputHelper;
        }

        public WebDriverFixture WebDriverFixture { get; }

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

        [Theory]
        [MemberData(nameof(Data))]
        public void ThrowsException(string username, string password, string cpassword, string email)
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
            driver.FindElement(By.CssSelector(".btn-default")).Click();

            var exception = Assert.Throws<NoSuchElementException>(() =>
                driver.FindElement(By.Id("Emailasfdasdf")).SendKeys(email)
            );

            Assert.NotNull(exception);

            testOutputHelper.WriteLine("Test completed");
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void ThrowsException2(string username, string password, string cpassword, string email)
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
            driver.FindElement(By.CssSelector(".btn-default")).Click();

            var exception = Assert.Throws<NoSuchElementException>(() =>
                driver.FindElement(By.Id("Emailasfdasdf")).SendKeys(email)
            );

            exception.Message.Should().Contain("no such element");
            Assert.NotNull(exception);

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
