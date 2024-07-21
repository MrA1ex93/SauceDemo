using OpenQA.Selenium;
using SauceDemo.Factories;
using SeleniumExtras.WaitHelpers;

namespace SauceDemo.Pages
{
    internal class CheckOutPage1 : BasePage
    {
        private static IWebElement continueButton = Driver.GetWait(10).Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='continue']")));
        private static IWebElement firstNameEntryField = Driver.GetWait(10).Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='first-name']")));
        private static IWebElement lastNameEntryField = Driver.GetWait(10).Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='last-name']")));
        private static IWebElement zipCodeEntryField = Driver.GetWait(10).Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='postal-code']")));

        public static void ClickContinueButton() => continueButton.Click();
        public static void EnterValueFirstName(string n) => firstNameEntryField.SendKeys(n);
        public static void EnterValueLastName(string n) => lastNameEntryField.SendKeys(n);
        public static void EnterValueZip(string n) => zipCodeEntryField.SendKeys(n);
    }
}