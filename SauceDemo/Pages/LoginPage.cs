using OpenQA.Selenium;
using SauceDemo.Factories;
using SeleniumExtras.WaitHelpers;

namespace SauceDemo.Pages
{
    internal class LoginPage : BasePage
    {
        private const string _userName = "standard_user";
        private const string _password = "secret_sauce";

        private static IWebElement userNameField => Driver.GetWait(10).Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='user-name']")));
        private static IWebElement passwordField => Driver.GetWait(10).Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='password']")));
        private static IWebElement loginButton => Driver.GetWait(10).Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='login-button']")));

        public static void Login()
        {
            try
            {
                userNameField.SendKeys(_userName);
                passwordField.SendKeys(_password);
                loginButton.Click();
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine("Не удалось найти элемент: " + ex.Message);
                throw;
            }
            catch (ElementClickInterceptedException ex)
            {
                Console.WriteLine("Не удалось кликнуть на кнопку входа: " + ex.Message);
                throw;
            }
        }
    }
}