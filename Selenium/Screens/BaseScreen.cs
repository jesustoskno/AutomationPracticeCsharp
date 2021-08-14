using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Selenium
{
    public abstract class BaseScreen
    {
        protected IWebDriver Driver { get; set; }
        private WebDriverWait _wait;

        public BaseScreen(IWebDriver driver)
        {
            Driver = driver;
        }

        protected Actions _actions
        {
            get
            {
                return _actions = new Actions(Driver);
            }
            set { }
        }

        public void Hover(IWebElement webElement)
        {
            WaitForElementToBeVisible(webElement);
            _actions = new Actions(Driver);
            _actions.MoveToElement(webElement).Build().Perform();
        }

        public void Click(IWebElement webElement)
        {
            WaitForElementToBeVisible(webElement);
            webElement.Click();
        }

        public void WaitForPageToLoad(IWebElement webElement)
        {
            WaitForElementToBeVisible(webElement);
        }

        public void WaitForElementToBeVisible(IWebElement webElement)
        {
            _wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            _wait.Until(condition =>
            {
                try
                {
                    return webElement.Displayed;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });
        }
    }
}
