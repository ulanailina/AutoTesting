using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTestPrivate.Page
{
    public class SeleniumDropdownDemoPage : BasePage
    {

        private const string PageAddress = "https://demo.seleniumeasy.com/basic-select-dropdown-demo.html";
        private const string ResultText = "Day selected :- ";
       
        private SelectElement dropDown => new SelectElement(Driver.FindElement(By.Id("select-demo")));
        
        private IWebElement ResultTextElement => Driver.FindElement(By.CssSelector(".selected-value"));
        private SelectElement multiDropdown => new SelectElement(Driver.FindElement(By.Id("multi-select")));
        private IWebElement buttonFirstSelected => Driver.FindElement(By.Id("printMe"));
        private IWebElement buttonGetAllSelected => Driver.FindElement(By.Id("printAll"));


        public SeleniumDropdownDemoPage(IWebDriver webdriver) : base(webdriver)
        {
            Driver.Url = PageAddress;
        }

        public SeleniumDropdownDemoPage SelectFromDropdownByValue(string text)
        {
            dropDown.SelectByValue(text);
            return this;
        }

        public SeleniumDropdownDemoPage SelectFromDropdownByIndex(int indeks)
        {
            dropDown.SelectByIndex(indeks);
            return this;
        }
        public SeleniumDropdownDemoPage SelectFromDropdownByText(string text)
        {
            dropDown.SelectByText(text);
            return this;
        }

        public SeleniumDropdownDemoPage VerifyResult(string selectedDay)
        {
            // cia galima daryti su Assert Contains

            Assert.IsTrue(ResultTextElement.Text.Equals(ResultText + selectedDay), $"Result is wrong, not {selectedDay}");
            return this;

            //Assert.AreEqual(ResultTextElement.Text, ResultText + selectedDay, $"Result is wrong, not {selectedDay}");
        }



        public SeleniumDropdownDemoPage SelectFromMultiDropdownByValue(string firstValue, string secondValue)
        {
            Actions action = new Actions(Driver);
            multiDropdown.SelectByValue(firstValue);
            action.KeyDown(Keys.Control);
            multiDropdown.SelectByValue(secondValue);
            action.KeyUp(Keys.Control);
            action.Build().Perform();
            return this;
        }

        public SeleniumDropdownDemoPage ClickFirstSelectedButton()
        {
            buttonFirstSelected.Click();
            return this;
        }

        public SeleniumDropdownDemoPage ClickAllSelectedButton()
        {
            buttonGetAllSelected.Click();
            return this;
        }

        //public SeleniumDropdownDemoPage SelectFromMultiDropdownByValue(List<string> listOfStates)
        //{
        //    multiDropdown.DeselectAll();
        //    Actions action = new Actions(Driver);
        //    action.KeyDown(Keys.LeftControl);
        //    foreach(string state in listOfStates)
        //    {
        //        foreach (IWebElement option in multiDropdown.Options)
        //        {
        //            if (state.Equals(option.GetAttribute("value")))
        //            {
        //                action.Click(option);
        //                break;
        //            }
        //        }
        //    }
        //    action.KeyUp(Keys.LeftControl);
        //    action.Build().Perform();
        //    action.Click(buttonFirstSelected);
        //    action.Click().Perform();
        //    return this;
        //}



        public SeleniumDropdownDemoPage SelectFromMuiltipleDropdownByValue1(List<string> listOfStates)
        {
            multiDropdown.DeselectAll();
            Actions action = new Actions(Driver);
            action.KeyDown(Keys.LeftControl);
                foreach (IWebElement option in multiDropdown.Options)
                {
                    if (listOfStates.Contains(option.GetAttribute("value")))
                    {
                        action.Click(option);
                        break;
                    }
                }
            action.KeyUp(Keys.LeftControl);
            action.Build().Perform();
            action.Click(buttonFirstSelected);
            action.Click().Perform();
            return this;
        }

        //public SeleniumDropdownDemoPage PabandymasWithCases(string firstCity, string secondCity, bool oneSelected, bool secondSelected)
        //{
        //    multiDropdown.DeselectAll();
        //    Actions action = new Actions(Driver);
        //    action.KeyDown(Keys.LeftControl);
        //    foreach (IWebElement option in multiDropdown.Options)
        //    {
        //        if (listOfStates.Contains(option.GetAttribute("value")))
        //        {
        //            action.Click(option);
        //            break;
        //        }
        //    }
        //    action.KeyUp(Keys.LeftControl);
        //    action.Build().Perform();
        //    action.Click(buttonFirstSelected);
        //    action.Click().Perform();


        //    if (oneSelected != true)
        //        buttonFirstSelected.Click();

        //    if (secondSelected != true)
        //        buttonGetAllSelected.Click();

        //    return this;
        //}

    }
}

