using OpenQA.Selenium;

namespace Selenium
{
    public class HomePage : BaseScreen
    {
        public HomePage(IWebDriver driver) : base(driver){}

        internal void ClickSummerDresses()
        {
            Driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
            var dressMainMenu = Driver.FindElement(By.XPath("//*[@id='block_top_menu']/ul/li[2]"));
            var summerDressSubMenu = Driver.FindElement(By.XPath("//*[@id='block_top_menu']/ul/li[2]/ul/li[3]"));
            Hover(dressMainMenu);
            Click(summerDressSubMenu);
        }
    }
}