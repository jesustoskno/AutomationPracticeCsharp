using NUnit.Framework;

namespace Selenium
{
    [TestFixture]
    public class AutomationPractice : BaseTest
    {
        [SetUp]
        public void SetUp()
        {
            homePage = new HomePage(Driver);
            dressesPage = new DressesPage(Driver);
        }

        [Description("Go to Summer Dresses from HomePage and adds a specific dress to the cart")]
        [Property("Author", "Jesus Toscano")]
        [Test]
        public void AddSummerDressTest()
        {
            homePage.ClickSummerDresses();
            dressesPage.WaitForPageToSync();
            dressesPage.AddToCartPrintedDress();
            Assert.IsTrue(dressesPage.ProductAddedText(), "Product successfuly added message is visible");
            dressesPage.ClickCloseButton();
        }

        [Description("Go to Summer Dresses, move a slider and assert the price range")]
        [Property("Author", "Jesus Toscano")]
        [Test]
        public void MoveSlidersTest()
        {
            homePage.ClickSummerDresses();
            dressesPage.WaitForPageToSync();
            dressesPage.MoveRightSlider();
            Assert.True(dressesPage.PriceRange(), "The price range is: \"$16.00 - $16.00\"");
        }
    }
}