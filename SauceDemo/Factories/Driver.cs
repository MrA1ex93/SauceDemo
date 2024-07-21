using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SauceDemo.Factories
{
    internal class Driver
    {
        private static IWebDriver? _driver;
        private static WebDriverWait? _wait;

        public static WebDriverWait GetWait(int v) => _wait ??= new(_driver, TimeSpan.FromSeconds(v));
        public static IWebDriver GetDriver() => _driver ??= SetupDriver();
        public static void QuitDriver()
        {
            _driver?.Quit();
            _driver = null;
        }

        private static IWebDriver SetupDriver() => new ChromeDriver(GetOptions());

        private static ChromeOptions GetOptions()
        {
            var options = new ChromeOptions();
            options.AddArgument("start-maximized");
            return options;
        }
    }
}