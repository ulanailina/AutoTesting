using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTestPrivate.Page
{
    public class baigiamasPVZPage
    {

        private static IWebDriver _driver;

        IWebElement _buttonLoginEntry => _driver.FindElement(By.CssSelector("#header-right > a"));
        IWebElement _loginInput => _driver.FindElement(By.Id("input-email"));
        IWebElement _passwordInput => _driver.FindElement(By.Id("input-password"));
        IWebElement _buttonLoginComfirm => _driver.FindElement(By.CssSelector(".btn.btn-primary"));

        IWebElement _buttonToChangeAddress => _driver.FindElement(By.CssSelector("#content > ul:nth-child(2) > li:nth-child(3) > a"));
        IWebElement _buttonToEditAddress => _driver.FindElement(By.CssSelector("#content > table > tbody > tr > td.text-right > a.btn.btn-info"));
        IWebElement _buttonToCelectCity => _driver.FindElement(By.Id("input-address-1"));
        IWebElement _buttonToContinueAfterChangingAddress => _driver.FindElement(By.CssSelector("#content > form > div > div.pull-right > input"));

        IWebElement _searchInput = _driver.FindElement(By.Id("search_query"));

        public baigiamasPVZPage (IWebDriver webDriver)
        {
            webDriver = _driver;
        }

    }

    //public void ButtonLoginEntry()
    //{
    //    _buttonLoginEntry.Click();
    //}



}
