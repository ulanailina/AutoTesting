using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutoTestPrivate.Page
{
    public class NDSeleniumDropdownPage : BasePage
    {
        private const string PageAddress = "https://demo.seleniumeasy.com/basic-select-dropdown-demo.html";
        private const string ResultText = "Day selected :- ";

        private SelectElement dropDown => new SelectElement(Driver.FindElement(By.Id("select-demo")));

        private IWebElement ResultTextElement => Driver.FindElement(By.CssSelector(".selected-value"));
        private SelectElement multiDropdown => new SelectElement(Driver.FindElement(By.Id("multi-select")));
        private IWebElement buttonFirstSelected => Driver.FindElement(By.Id("printMe"));
        private IWebElement buttonGetAllSelected => Driver.FindElement(By.Id("printAll"));

        public NDSeleniumDropdownPage (IWebDriver webdriver) : base(webdriver)
        {
            Driver.Url = PageAddress;
        }

        public NDSeleniumDropdownPage SelectFromMultiDropdownTwoStatesByValue(string firstValue, string secondValue)
        {
            Actions action = new Actions(Driver);
            multiDropdown.SelectByValue(firstValue);
            action.KeyDown(Keys.Control);
            multiDropdown.SelectByValue(secondValue);
            action.KeyUp(Keys.Control);
            action.Build().Perform();
            return this;
        }

        public NDSeleniumDropdownPage ClickButtonFirstSelected()
        {
            buttonFirstSelected.Click();
            return this;
        }

        public NDSeleniumDropdownPage VerifyIfFirstSelected(string selectedDay)
        {
            Assert.IsTrue(ResultTextElement.Text.Equals(ResultText + selectedDay), $"Result is wrong, not {selectedDay}");
            return this;
        }

        public NDSeleniumDropdownPage SelectFromMultiDropdownThreeStatesByValue(string firstValue, string secondValue, string thirdValue)
        {
            Actions action = new Actions(Driver);
            multiDropdown.SelectByValue(firstValue);
            action.KeyDown(Keys.Control);
            multiDropdown.SelectByValue(secondValue);
            multiDropdown.SelectByValue(thirdValue);
            action.KeyUp(Keys.Control);
            action.Build().Perform();
            return this;
        }

        public NDSeleniumDropdownPage ClickButtonGetAllSelected()
        {
            Thread.Sleep(3000);
            buttonGetAllSelected.Click();
            return this;
        }

        public NDSeleniumDropdownPage VerifyIfAllSelectedOfTwoValues(string firstValue, string secondValue)
        {
            
            Assert.IsTrue(ResultTextElement.Text.Contains(firstValue + secondValue));
            return this;
        }

        public NDSeleniumDropdownPage SelectFromMultiDropdownFourStatesByValue(string firstValue, string secondValue, string thirdValue, string fourthValue)
        {
            Actions action = new Actions(Driver);
            multiDropdown.SelectByValue(firstValue);
            action.KeyDown(Keys.Control);
            multiDropdown.SelectByValue(secondValue);
            multiDropdown.SelectByValue(thirdValue);
            multiDropdown.SelectByValue(fourthValue);
            action.KeyUp(Keys.Control);
            action.Build().Perform();
            return this;
        }
        public NDSeleniumDropdownPage VerifyIfAllSelectedOfFourValues(string firstValue, string secondValue, string thirdValue, string fourthValue)
        {

            Assert.IsTrue(ResultTextElement.Text.Contains(firstValue + secondValue + thirdValue + fourthValue));
            return this;
        }

    }
}
