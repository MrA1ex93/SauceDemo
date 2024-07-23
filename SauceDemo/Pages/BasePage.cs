using OpenQA.Selenium;
using SauceDemo.Factories;

namespace SauceDemo.Pages
{
    internal class BasePage
    {
        public static void OpenPage()
        {
            IWebDriver driver = Driver.GetDriver();
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            driver.Manage().Window.Maximize();
        }
    }
}