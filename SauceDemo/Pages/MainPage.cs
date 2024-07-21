using OpenQA.Selenium;
using SauceDemo.Factories;
using SeleniumExtras.WaitHelpers;

namespace SauceDemo.Pages
{
    internal class MainPage : BasePage
    {
        private static List<string> clothesElementsNames = new List<string>();
        private static List<string> clothesElementsNames1 = new List<string>();

        private static List<string> clothesElementsPricesText = new List<string>();
        private static List<string> clothesElementsPricesText1 = new List<string>();
        private static List<double> clothesElementsPrices = new List<double>();
        private static List<double> clothesElementsPrices1 = new List<double>();

        private static List<IWebElement> clothesElements => driver.FindElements(By.XPath("//*[@class='inventory_item_name ']")).ToList();
        private static List<IWebElement> clothesPrices => driver.FindElements(By.XPath("//*[@class='inventory_item_price']")).ToList();

        private static IWebElement cartButton = Driver.GetWait(10).Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@class='shopping_cart_link']")));

        private static IWebElement buttonOne = Driver.GetWait(10).Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@class='inventory_list']/div[1]//button")));
        private static IWebElement buttonTwo = Driver.GetWait(10).Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@class='inventory_list']/div[2]//button")));
        private static IWebElement buttonThree = Driver.GetWait(10).Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@class='inventory_list']/div[3]//button")));
        private static IWebElement buttonFour = Driver.GetWait(10).Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@class='inventory_list']/div[4]//button")));
        private static IWebElement buttonFive = Driver.GetWait(10).Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@class='inventory_list']/div[5]//button")));
        private static IWebElement buttonSix = Driver.GetWait(10).Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@class='inventory_list']/div[6]//button")));

        private static IWebElement dropdown = Driver.GetWait(10).Until(ExpectedConditions.ElementIsVisible(By.ClassName("product_sort_container")));
        private static IWebElement dropdownOption1 = Driver.GetWait(10).Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@class='product_sort_container']/option[1]")));
        private static IWebElement dropdownOption3 = Driver.GetWait(10).Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@class='product_sort_container']/option[3]")));

        private static List<string> GetNames(List<string> list)
        {
            foreach (var a in clothesElements)
            {
                list.Add(a.Text);
            }
            return list;
        }

        private static List<string> GetPrices(List<string> list1)
        {
            foreach (var b in clothesPrices)
            {
                list1.Add(b.Text.Trim(new char[] { '$' }));
            }
            return list1;
        }

        private static List<double> PricesConverter(List<string> textList)
        {
            string ap = "";
            List<double> intList = new List<double>();

            for (double a = 0; a < textList.Count; a++)
            {
                for (int b = 0; b < a - 1; b++)
                {
                    try
                    {
                        ap = textList[b];
                    }
                    catch (System.ArgumentOutOfRangeException ex)
                    {
                        continue;
                    }
                    a = Double.Parse(ap, System.Globalization.CultureInfo.InvariantCulture);
                    intList.Add(a);
                    continue;
                }
            }
            return intList;
        }

        private static List<double> SortList(List<double> pricesList)
        {
            for (int a = 0; a < pricesList.Count; a++)
            {
                for (int b = a + 1; b < pricesList.Count; b++)
                {
                    if (pricesList[a] > pricesList[b])
                    {
                        double temp = 0;
                        temp = pricesList[a];
                        pricesList[a] = pricesList[b];
                        pricesList[b] = temp;
                    }
                }
            }
            return pricesList;
        }

        public static void NavigateToCart() => cartButton.Click();

        public static void AddItemToCart(int n)
        {

            if (n == 1)
            {
                buttonOne.Click();
            }
            else if (n == 2)
            {
                buttonTwo.Click();
            }
            else if (n == 3)
            {
                buttonThree.Click();
            }
            else if (n == 4)
            {
                buttonFour.Click();
            }
            else if (n == 5)
            {
                buttonFive.Click();
            }
            else if (n == 6)
            {
                buttonSix.Click();
            }
        }

        public static void ClickAndChooseDropdownOption(int n)
        {
            dropdown.Click();

            if (n == 1)
            {
                dropdownOption1.Click();
            }
            else if (n == 3)
            {
                dropdownOption3.Click();
            }
        }

        public static bool AreNamesSorted()
        {
            var notSortedNames = GetNames(clothesElementsNames);
            notSortedNames.Sort();
            bool decision = notSortedNames.SequenceEqual(GetNames(clothesElementsNames1));
            return decision;
        }

        public static bool ArePricesSorted()
        {
            GetPrices(clothesElementsPricesText);
            clothesElementsPrices = PricesConverter(clothesElementsPricesText);
            SortList(clothesElementsPrices);
            GetPrices(clothesElementsPricesText1);
            clothesElementsPrices1 = PricesConverter(clothesElementsPricesText1);
            bool decision = clothesElementsPrices.SequenceEqual(clothesElementsPrices1);
            return decision;
        }
    }
}