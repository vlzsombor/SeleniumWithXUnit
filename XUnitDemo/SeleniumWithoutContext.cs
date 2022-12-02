using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace XUnitDemo
{
    public class SeleniumWithoutContext
    {
        private readonly ChromeDriver chromeDriver;
        public SeleniumWithoutContext()
        {
            //webdriver manager
            var driver = new DriverManager()
                .SetUpDriver(new ChromeConfig());
            this.chromeDriver = new ChromeDriver();
        }       

        [Fact]
        public void Test1()
        {
            chromeDriver.Navigate().GoToUrl("http://info.cern.ch/");
        }

    }
}