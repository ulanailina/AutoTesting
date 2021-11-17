using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTestPrivate.Page
{
    public class CheckBoxSeleniumPage : BasePage
    {
        private const string PageAddress = "https://demo.seleniumeasy.com/basic-checkbox-demo.html";
        private const string _textToCheck = "Success - Check box is checked";
        private IWebElement _firstCheckBox => Driver.FindElement(By.Id("isAgeSelected"));
        private IWebElement _textSuccessOrNot => Driver.FindElement(By.Id("txtAge"));
        private IReadOnlyCollection<IWebElement> multipleCheckboxList => Driver.FindElements(By.CssSelector(".cb1-element"));
        private IWebElement _button => Driver.FindElement(By.Id("check1"));

        public CheckBoxSeleniumPage(IWebDriver webdriver) : base(webdriver)
        {
            Driver.Url = PageAddress;
        }

        public CheckBoxSeleniumPage ClickOnCheckBox()
        {
            if (!_firstCheckBox.Selected)
                _firstCheckBox.Click();
            return this;
        }

        public CheckBoxSeleniumPage CheckIsCheckBoxChecked()
        {

            Assert.IsTrue(_textSuccessOrNot.Text.Equals(_textToCheck));
            return this;
        }

        public CheckBoxSeleniumPage ClickCheckBoxes()
        {
            if (_firstCheckBox.Selected)
                _firstCheckBox.Click();
            return this;
        }

        private void UncheckFirstCheckBox()
        {
            if (_firstCheckBox.Selected)
                _firstCheckBox.Click();
        }

        public CheckBoxSeleniumPage ClickAllCheckBoxes()
        {
            UncheckFirstCheckBox();
            foreach (IWebElement element in multipleCheckboxList)
            {
                if (!element.Selected)
                    element.Click();
            }
            return this;
        }

        public CheckBoxSeleniumPage CheckValueOfButton(string value)
        {
            // cia yra explicit wait. ivykiai, kuriu laikia, kad pasikeis pvz. Bet ant siu metu VS neveikia
            //WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5)); 
            //wait.Until(ExpectedConditions.TextToBePresentInElementsValue(_button, "Uncheck All"));
            Assert.IsTrue(_button.GetAttribute("value").Equals(value), "It is wrong");
            return this;
        }

        public CheckBoxSeleniumPage UncheckBoxes()
        {
            if (_button.GetAttribute("value") == "Uncheck All")
            {
                _button.Click();
            }
            return this;

            //_button.Click();
            //return this;
        }

        public CheckBoxSeleniumPage CheckIfAllBoxesAreUnchecked()
        {
            //IReadOnlyCollection<IWebElement> multipleCheckboxList = Driver.FindElements(By.ClassName("cb1-element"));
            //int counter = 0;
            //foreach (IWebElement element in multipleCheckboxList)
            //{
            //    if (element.Selected)
            //    {
            //        counter++;
            //    }
            //}
            //Assert.AreEqual(0, counter, "Some of the checkboxes are still checked");
            //return this;

            foreach (IWebElement element in multipleCheckboxList)
            {
                Assert.False(element.Selected, "CheckBoxSeleniumDemo is still checked");
                //Assert.IsTrue(!element.Selected, "CheckBoxSeleniumDemo is still checked");
                //Assert.That(element.Selected, "CheckBoxSeleniumDemo is still checked");
            }
            return this;


        }
    }
}
