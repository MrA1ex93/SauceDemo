using OpenQA.Selenium;
using SauceDemo.Factories;

namespace SauceDemo.Pages
{
    internal class BasePage
    {
        protected static IWebDriver driver = Driver.GetDriver();

        public static void OpenPage()
        {
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            Driver.GetDriver().Manage().Window.Maximize();
        }
    }
}