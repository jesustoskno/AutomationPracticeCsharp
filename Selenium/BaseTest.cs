using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Opera;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;


namespace Selenium
{
    [TestFixture]
    public abstract class BaseTest
    {
        protected IWebDriver Driver { get; set; }
        protected string _browserName = "Firefox";
        protected HomePage homePage;
        protected DressesPage dressesPage;

        [SetUp]
        public void Setup()
        {
            Driver = GetWebDriver(_browserName);
            Driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }

        public IWebDriver GetWebDriver(string browserName)
        {
            switch (browserName)
            {
                case "Chrome":
                    new DriverManager().SetUpDriver(new ChromeConfig());
                    return new ChromeDriver();

                case "Firefox":
                    new DriverManager().SetUpDriver(new FirefoxConfig());
                    return new FirefoxDriver();

                case "Opera":
                    new DriverManager().SetUpDriver(new OperaConfig());
                    return new OperaDriver();

                default:
                    new DriverManager().SetUpDriver(new ChromeConfig());
                    return new ChromeDriver();
            }

        }
    }
}