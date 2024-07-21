using NUnit.Allure.Core;
using SauceDemo.Pages;

namespace SauceDemo.Tests
{

    [AllureNUnit]
    internal class CheckOutTest : BaseTest
    {
        [Test]
        [Description("Check that elements are added to the CheckOut")]
        public void Should_Add_Items_To_CheckOut()
        {
            LoginPage.Login();

            MainPage.AddItemToCart(3);
            MainPage.AddItemToCart(4);
            MainPage.NavigateToCart();
            CartPage.ClickCheckOutButton();

            CheckOutPage1.EnterValueFirstName("Test_User");
            CheckOutPage1.EnterValueLastName("Test_Last_Name");
            CheckOutPage1.EnterValueZip("12341234");
            CheckOutPage1.ClickContinueButton();

            Assert.That(CheckOutPage2.CheckThatItemsInCheckOut(3), Is.True, "Item 3 should be in CheckOut page.");
            Assert.That(CheckOutPage2.CheckThatItemsInCheckOut(4), Is.True, "Item 4 should be in CheckOut page.");
        }
    }
}