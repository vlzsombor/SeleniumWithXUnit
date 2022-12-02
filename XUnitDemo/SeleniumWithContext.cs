using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace XUnitDemo
{
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


    }
}
