using OpenQA.Selenium;
using SauceDemo.Factories;
using SeleniumExtras.WaitHelpers;

namespace SauceDemo.Pages
{
    internal class CartPage : BasePage
    {

        private static IWebElement checkOut = Driver.GetWait(10).Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@class='btn btn_action btn_medium checkout_button ']")));
        private static bool itemOne() => Driver.GetWait(5).Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[contains(text(),'Backpack')]"))).Displayed;
        private static bool itemTwo() => Driver.GetWait(5).Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[contains(text(),'Bike Light')]"))).Displayed;
        private static bool itemThree() => Driver.GetWait(5).Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[contains(text(),'Bolt T-Shirt')]"))).Displayed;
        private static bool itemFour() => Driver.GetWait(5).Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[contains(text(),'Jacket')]"))).Displayed;
        private static bool itemFive() => Driver.GetWait(5).Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[contains(text(),'Onesie')]"))).Displayed;
        private static bool itemSix() => Driver.GetWait(5).Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[contains(text(),'Red')]"))).Displayed;

        private static void removeItemOne() => driver.FindElement(By.XPath("//*[@class='cart_list']//div[3]//button")).Click();
        private static void removeItemTwo() => driver.FindElement(By.XPath("//*[@class='cart_list']//div[4]//button")).Click();

        public static void ClickCheckOutButton() => checkOut.Click();

        public static void ClickRemoveButton(int n)
        {
            if (n == 1)
            {
                removeItemOne();
            }
            else if (n == 2)
            {
                removeItemTwo();
            }
        }

        public static bool CheckThatAdded(int n)
        {
            var result = false;

            if (n == 1)
            {
                return result = itemOne();
            }
            else if (n == 2)
            {
                return result = itemTwo();
            }
            else if (n == 3)
            {
                return result = itemThree();
            }
            else if (n == 4)
            {
                return result = itemFour();
            }
            else if (n == 5)
            {
                return result = itemFive();
            }
            else if (n == 6)
            {
                return result = itemSix();
            }
            else
                return false;
        }
    }
}