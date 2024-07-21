using OpenQA.Selenium;
using SauceDemo.Factories;
using SeleniumExtras.WaitHelpers;

namespace SauceDemo.Pages
{
    internal class CheckOutPage2 : BasePage
    {

        private const string _nameOfItemThree = "Sauce Labs Bolt T-Shirt";
        private const string _nameOfItemFour = "Sauce Labs Fleece Jacket";

        private static IWebElement continueButton = Driver.GetWait(10).Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='first-name']")));

        public static string itemThree() => Driver.GetWait(5).Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@class='cart_list']//div[3]//div[2]//a//div[1]"))).Text;
        public static string itemFour() => Driver.GetWait(5).Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@class='cart_list']//div[4]//div[2]//a//div[1]"))).Text;

        public static bool CheckThatItemsInCheckOut(int n)
        {
            var result = false;
            var a = "";

            if (n == 3)
            {
                if ((a = itemThree()) == _nameOfItemThree)
                {
                    return true;
                }
                else
                    return false;
            }
            else if (n == 4)
            {
                if ((a = itemFour()) == _nameOfItemFour)
                {
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }

    }
}