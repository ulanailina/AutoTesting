using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTestPrivate.Page
{
    public class SeleniumInputPage
    {
        private static IWebDriver _driver;

        private IWebElement _inputField => _driver.FindElement(By.Id("user-message"));
        private IWebElement _button => _driver.FindElement(By.CssSelector("#get-input > button"));
        private IWebElement _Resulttext => _driver.FindElement(By.Id("display"));
        private IWebElement _inputField1 => _driver.FindElement(By.Id("sum1"));
        private IWebElement _inputField2 => _driver.FindElement(By.Id("sum2"));
        private IWebElement _buttonSum => _driver.FindElement(By.CssSelector("#gettotal > button"));
        private IWebElement _resultOfSum => _driver.FindElement(By.Id("displayvalue"));

        public SeleniumInputPage(IWebDriver webdriver)
        {
            _driver = webdriver;
        }

        public void InsertText(string text)
        {
            _inputField.Clear();
            _inputField.SendKeys(text);
        }

        public void ClickShowMessageButton()
        {
            _button.Click();
        }

        public void CheckResult(string expectedResult)
        {
            Assert.AreEqual(expectedResult, _Resulttext.Text, "Tekstas neatsirado");
        }

        private void InputFirstField(string text)
        {
            _inputField1.Clear();
            _inputField1.SendKeys(text);
        }

        private void InputSecondField(string text)
        {
            _inputField2.Clear();
            _inputField2.SendKeys(text);
        }

        public void InputBothFields(string firstNumber, string secondNumber)
        {
            InputFirstField(firstNumber);
            InputSecondField(secondNumber);
        }

        public void ClickButtonSum()
        {
            _buttonSum.Click();
        }

        public void CheckResultValue(string expectedSumResult)
        {
            Assert.AreEqual(expectedSumResult, _resultOfSum.Text, "Atsakymas neteisingas");
        }
    }
}
