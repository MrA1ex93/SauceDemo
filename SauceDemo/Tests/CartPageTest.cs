using NUnit.Allure.Core;
using SauceDemo.Pages;

namespace SauceDemo.Tests
{
    [AllureNUnit]
    internal class CartPageTest : BaseTest
    {

        [Test]
        [Description("Add item to Cart test")]
        public void CartPageTest1()
        {
            LoginPage.Login();

            MainPage.AddItemToCart(1);
            MainPage.AddItemToCart(6);

            MainPage.NavigateToCart();

            var result1 = CartPage.CheckThatAdded(1);
            var result2 = CartPage.CheckThatAdded(6);

            Assert.That(result1, Is.True);
            Assert.That(result2, Is.True);
        }

        [Test]
        [Description("Remove item from Cart test")]
        public void CartPageTest2()
        {
            LoginPage.Login();

            MainPage.AddItemToCart(2);
            MainPage.AddItemToCart(4);

            MainPage.NavigateToCart();

            CartPage.ClickRemoveButton(2);
            CartPage.ClickRemoveButton(1);


            var result1 = false;
            var result2 = false;
            try
            {
                result1 = CartPage.CheckThatAdded(2);
            }
            catch (OpenQA.Selenium.WebDriverTimeoutException ex)
            {
                result1 = false;
            }
            try
            {
                result2 = CartPage.CheckThatAdded(4);
            }
            catch (OpenQA.Selenium.WebDriverTimeoutException ex)
            {
                result2 = false;
            }

            Assert.That(result1, Is.False);
            Assert.That(result2, Is.False);
        }
    }
}