using NUnit.Allure.Core;
using SauceDemo.Factories;
using SauceDemo.Pages;

namespace SauceDemo.Tests
{
    [AllureNUnit]
    internal class BaseTest
    {
        [SetUp]
        public void SetUp()
        {
            BasePage.OpenPage();
        }

        [TearDown]
        public void TearDown()
        {
            Driver.QuitDriver();
        }
    }
}