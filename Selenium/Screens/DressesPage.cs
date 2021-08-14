using System;
using OpenQA.Selenium;

namespace Selenium
{
    public class DressesPage : BaseScreen
    {
        public DressesPage(IWebDriver driver) : base(driver) { }

        internal void WaitForPageToSync()
        {
            var syncLocator = Driver.FindElement(By.XPath("//*[@id='center_column']/ul/li[3]/div/div[1]/div/a[1]/img"));
            WaitForPageToLoad(syncLocator);
        }

        internal void AddToCartPrintedDress()
        {
            var printedSummerDressCollection = Driver.FindElement(By.XPath("//*[@id='center_column']/ul/li[2]"));

            Hover(printedSummerDressCollection);

            var addToCartButton = Driver.FindElement(By.XPath("//*[@id='center_column']/ul/li[2]/div/div[2]/div[2]/a[1]"));

            Click(addToCartButton);
        }

        internal bool ProductAddedText()
        {
            var productAddedText = Driver.FindElements(By.XPath("//h2"));
            WaitForElementToBeVisible(productAddedText[0]);
            try
            {
                return productAddedText[0].Text.Trim().Contains("Product successfully added to your shopping cart");
            }
            catch
            {
                return false;
            }
        }

        internal void MoveRightSlider()
        {
            var leftSlider = Driver.FindElement(By.XPath("//*[@id='layered_price_slider']/a[1]"));
            var rightSlider = Driver.FindElement(By.XPath("//*[@id='layered_price_slider']/a[2]"));
            Click(rightSlider);
            _actions.DragAndDrop(rightSlider, leftSlider).Perform();
        }

        internal bool PriceRange()
        {
            try
            {
                return Driver.FindElement(By.Id("layered_price_range")).Text.Equals("$16.00 - $16.00");
            }
            catch
            {
                return false;
            }
        }

        internal void ClickCloseButton()
        {
            var closeButton = Driver.FindElement(By.XPath("//*[@title='Close window']"));
            Click(closeButton);
        }

    }
}