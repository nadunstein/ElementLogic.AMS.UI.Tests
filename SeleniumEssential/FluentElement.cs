using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;

namespace SeleniumEssential
{
    public class FluentElement : WebDriverBase
    {
        private ReadOnlyCollection<IWebElement> _commonElementList;
        private string _commonElement;
        private IWebElement _commonIWebElement;
        private string _commonElementText;
        private bool _switchedToFrame;

        public FluentElement Navigate(string pageUrl)
        {
            Driver.Url = pageUrl;
            return this;
        }

        public FluentElement WaitForPageLoad()
        {
            var attempts = 0;
            while (attempts < 10000)
            {
                var pageState = Driver.ExecuteJavaScript<string>("return document.readyState");
                if (pageState == "complete")
                {
                    break;
                }

                ForcedWait(0.01);
                attempts++;
            }

            return this;
        }

        public FluentElement WaitUntilInvisible(string element)
        {
            ForcedWait(0.25);
            var attempts = 0;
            while (attempts < 100)
            {
                var elementDisplayed = IsElementDisplayed(element);
                if (!elementDisplayed)
                {
                    break;
                }

                ForcedWait(0.5);
                attempts++;
            }

            return this;
        }

        public FluentElement WaitForElement(string element)
        {
            WaitForElement(element, 20);
            _commonElement = element;
            return this;
        }

        public bool IsVisible()
        {
            if (_commonIWebElement == null)
            {
                return IsElementDisplayed(_commonElement);
            }

            var isVisible = IsElementDisplayed(_commonIWebElement);
            _commonIWebElement = null;
            return isVisible;
        }

        public bool IsVisible(string element)
        {
            return IsElementDisplayed(element);
        }

        public bool IsFocused()
        {
            var iWebElement = GetIWebElement(_commonElement);
            return iWebElement.Equals(Driver.SwitchTo().ActiveElement());
        }

        public bool IsEnable()
        {
            try
            {
                var iWebElement = GetIWebElement(_commonElement);
                return iWebElement.Enabled;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Insert(string insertValue)
        {
            return InsertField(_commonElement, insertValue);
        }

        public bool Click()
        {
            var click = _commonIWebElement == null
                ? Click(_commonElement)
                : Click(_commonIWebElement);
            if (_switchedToFrame)
            {
                SwitchToDefaultWebPage();
                _switchedToFrame = false;
            }

            _commonIWebElement = null;
            return click;
        }

        public void ClickEnterButton()
        {
            var attempts = 0;
            while (attempts < 20)
            {
                try
                {
                    var iWebElement = GetIWebElement(_commonElement);
                    iWebElement.SendKeys(Keys.Enter);
                    break;
                }
                catch (Exception)
                {
                    ForcedWait(0.5);
                }

                attempts++;
            }
        }

        public void ClickTabButton()
        {
            var attempts = 0;
            while (attempts < 20)
            {
                try
                {
                    var iWebElement = GetIWebElement(_commonElement);
                    iWebElement.SendKeys(Keys.Tab);
                    break;
                }
                catch (Exception)
                {
                    ForcedWait(0.5);
                }

                attempts++;
            }
        }

        public string GetText()
        {
            if (_commonIWebElement == null)
            {
                _commonElementText = GetTextValue(_commonElement);
                return _commonElementText;
            }

            var textValue = GetTextValue(_commonIWebElement);
            _commonIWebElement = null;
            return textValue;
        }

        public FluentElement Text()
        {
            _commonElementText = GetTextValue(_commonElement);
            return this;
        }

        public bool Equals(string expectedElementText)
        {
            var attempts = 0;
            while (attempts < 20)
            {
                if (_commonElementText == expectedElementText)
                {
                    return true;
                }

                attempts++;
                ForcedWait(0.5);
                Text();
            }

            return false;
        }

        public string GetAttribute(string attribute)
        {
            var attempts = 0;
            while (attempts < 20)
            {
                string value;
                try
                {
                    var iWebElement = GetIWebElement(_commonElement);
                    value = iWebElement.GetAttribute(attribute);
                }
                catch (Exception)
                {
                    value = null;
                }

                if (!string.IsNullOrEmpty(value))
                {
                    return value;
                }

                ForcedWait(0.5);
                attempts++;
            }

            return string.Empty;
        }

        public bool SelectDropDown(string selectOption)
        {
            var attempts = 0;
            var isDropDownValueSelected = false;
            while (attempts < 20)
            {
                try
                {
                    var iWebElement = GetIWebElement(_commonElement);
                    var select = new SelectElement(iWebElement);
                    select.SelectByText(selectOption, true);
                    isDropDownValueSelected = true;
                    break;
                }
                catch (Exception)
                {
                    ForcedWait(0.5);
                    attempts++;
                }
            }

            return isDropDownValueSelected;
        }

        public bool SelectDropDown(string dropdownList, string dropdownOptionsIdentifier, string selectOption)
        {
            Click(_commonElement);
            WaitForElement(dropdownList, 20);
            ForcedWait(0.5);
            var attempts = 0;
            while (attempts < 20)
            {
                try
                {
                    var options = GetList(dropdownList, dropdownOptionsIdentifier);
                    foreach (var option in options)
                    {
                        if (!option.Text.Contains(selectOption))
                        {
                            continue;
                        }

                        option.Click();
                        return true;
                    }
                }
                catch (Exception)
                {
                    // ignored
                }

                ForcedWait(0.5);
                attempts++;
            }

            return false;
        }

        public bool SelectSearchDropDown(string searchDropdownList, string dropdownOptionsIdentifier, string searchOption)
        {
            InsertField(_commonElement, searchOption);
            WaitForElement(searchDropdownList, 20);
            var attempts = 0;
            while (attempts < 20)
            {
                try
                {
                    var options = GetList(searchDropdownList, dropdownOptionsIdentifier);
                    if (options.Count.Equals(1) && options[0].Text.Contains(searchOption))
                    {
                        options[0].Click();
                        return true;
                    }
                }
                catch (Exception)
                {
                    //Ignore
                }

                attempts++;
                ForcedWait(0.5);
            }

            return false;
        }

        public FluentElement SwitchToIframe(string iframe)
        {
            if (_switchedToFrame)
            {
                return this;
            }

            var webElementIframe = GetIWebElement(iframe);
            WaitForElement(iframe, 20);
            try
            {
                Driver.SwitchTo().Frame(webElementIframe);
            }
            catch (Exception)
            {
                //ignore
            }

            _switchedToFrame = true;
            return this;
        }

        public FluentElement ScrollToTheElement()
        {
            try
            {
                var iWebElement = GetIWebElement(_commonElement);
                var js = Driver as IJavaScriptExecutor;
                js?.ExecuteScript("arguments[0].scrollIntoView(true);", iWebElement);
            }
            catch (Exception)
            {
                //ignore
            }

            return this;
        }

        public FluentElement RefreshWebPage()
        {
            Driver.Navigate().Refresh();
            return this;
        }

        public FluentElement Wait(double timeoutInSeconds)
        {
            ForcedWait(timeoutInSeconds);
            return this;
        }

        public FluentElement FindElements(string elementListFinder)
        {
            _commonElementList = GetList(_commonElement, elementListFinder);
            return this;
        }

        public int GetCount()
        {
            return _commonElementList.Count;
        }

        public FluentElement SearchElementByText(string elementText)
        {
            foreach (var element in _commonElementList)
            {
                if (!element.Text.Contains(elementText))
                {
                    continue;
                }

                _commonIWebElement = element;
                break;
            }

            return this;
        }

        public FluentElement SearchElementByIndex(int elementIndex)
        {
            _commonIWebElement = _commonElementList[elementIndex - 1];
            return this;
        }

        public FluentElement FindElement(string element)
        {
            var elementBy = By.CssSelector(element);
            try
            {
                _commonIWebElement = _commonIWebElement.FindElement(elementBy);
            }
            catch (Exception)
            {
                _commonIWebElement = null;
            }
            
            return this;
        }

        public bool SearchAndClickTableCellItem(string table, int searchColumnIndex, string expectedSearchValue,
            int clickColumnIndex, string clickElementFinder)
        {
            var result = false;
            var attempts = 0;
            while (attempts < 100)
            {
                try
                {
                    var tableRows = GetList(table,"tr");
                    foreach (var tableRow in tableRows)
                    {
                        var tableData = GetList(tableRow,"td");

                        if (!tableData[searchColumnIndex - 1].Text.Contains(expectedSearchValue))
                        {
                            continue;
                        }

                        var selectButton = tableData[clickColumnIndex - 1].FindElement(By.CssSelector(clickElementFinder));
                        selectButton?.Click();
                        result = true;
                        break;
                    }
                }
                catch (Exception)
                {
                    // ignored
                }

                if (result)
                {
                    break;
                }

                ForcedWait(0.1);
                attempts++;
            }

            return result;
        }

        public IList<string> GetTableColumnDataSet(string table, int columnIndex)
        {
            var attempts = 0;
            while (attempts < 100)
            {
                try
                {
                    var tableRecords = GetList(table,"tr");
                    return tableRecords.Select(tableRecord => GetList(tableRecord,"td"))
                        .Select(tableData => tableData[columnIndex - 1].Text).ToList();
                }

                catch (Exception)
                {
                    ForcedWait(0.1);
                    attempts++;
                }
            }

            return null;
        }

        public void DeleteBrowserCookies()
        {
            Driver.Manage().Cookies.DeleteAllCookies();
        }

        public static FluentElement Instance => Singleton.Value;


        #region Private Methods

        private static IWebElement GetIWebElement(string element)
        {
            try
            {
                var elementBy = By.CssSelector(element);
                return Driver.FindElement(elementBy);
            }
            catch (Exception)
            {
                return null;
            }
        }

        private static bool IsElementDisplayed(string element)
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
            try
            {
                var elementBy = By.CssSelector(element);
                return Driver.FindElement(elementBy).Displayed;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private static bool IsElementDisplayed(IWebElement element)
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);

            try
            {
                return element.Displayed;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private static void WaitForElement(string element, int timeoutInSeconds)
        {
            var attempts = 0;
            var count = timeoutInSeconds * 100;
            while (attempts < count)
            {
                if (IsElementDisplayed(element))
                {
                    break;
                }

                ForcedWait(0.01);
                attempts++;
            }
        }

        private static bool Click(string element)
        {
            var attempts = 0;
            var isElementClicked = false;
            while (attempts < 20)
            {
                try
                {
                    GetIWebElement(element).Click();
                    isElementClicked = true;
                    break;
                }
                catch (Exception)
                {
                    ForcedWait(0.5);
                    attempts++;
                }
            }

            return isElementClicked;
        }

        private static bool Click(IWebElement element)
        {
            var attempts = 0;
            var isElementClicked = false;
            while (attempts < 20)
            {
                try
                {
                    element.Click();
                    isElementClicked = true;
                    break;
                }
                catch (Exception)
                {
                    ForcedWait(0.5);
                    attempts++;
                }
            }

            return isElementClicked;
        }

        private static string GetTextValue(string element)
        {
            var attempts = 0;
            while (attempts < 20)
            {
                string value;
                try
                {
                    var iWebElement = GetIWebElement(element);
                    value = iWebElement.Text;
                }
                catch (Exception)
                {
                    value = null;
                }

                if (!string.IsNullOrEmpty(value))
                {
                    return value;
                }

                ForcedWait(0.5);
                attempts++;
            }

            return string.Empty;
        }

        private static string GetTextValue(IWebElement element)
        {
            var attempts = 0;
            while (attempts < 20)
            {
                string value;
                try
                {
                    value = element.Text;
                }
                catch (Exception)
                {
                    value = null;
                }

                if (!string.IsNullOrEmpty(value))
                {
                    return value;
                }

                ForcedWait(0.5);
                attempts++;
            }

            return string.Empty;
        }

        private static bool InsertField(string element, string insertValue)
        {
            var attempts = 0;
            var isInserted = false;
            while (attempts < 20)
            {
                try
                {
                    var iWebElement = GetIWebElement(element);
                    iWebElement.Clear();
                    iWebElement.Click();
                    iWebElement.SendKeys(insertValue);
                    if (iWebElement.GetAttribute("value") == insertValue)
                    {
                        isInserted = true;
                        break;
                    }
                }
                catch (Exception)
                {
                    // ignored
                }

                ForcedWait(0.5);
                attempts++;
            }

            return isInserted;
        }

        private static ReadOnlyCollection<IWebElement> GetList(string parentElement, string elementFinder)
        {
            var attempts = 0;
            while (attempts < 20)
            {
                try
                {
                    return parentElement == null
                        ? Driver.FindElements(By.CssSelector(elementFinder))
                        : GetIWebElement(parentElement).FindElements(By.CssSelector(elementFinder));
                }
                catch (Exception)
                {
                    ForcedWait(0.5);
                }

                attempts++;
            }

            return null;
        }

        private static ReadOnlyCollection<IWebElement> GetList(ISearchContext parentElement, string elementFinder)
        {
            var attempts = 0;
            while (attempts < 20)
            {
                try
                {
                    return parentElement.FindElements(By.CssSelector(elementFinder));
                }
                catch (Exception)
                {
                    ForcedWait(0.5);
                }

                attempts++;
            }

            return null;
        }

        private static void SwitchToDefaultWebPage()
        {
            try
            {
                Driver.SwitchTo().DefaultContent();
            }
            catch (Exception)
            {
                //ignore
            }
        }

        private static void ForcedWait(double timeoutInSeconds)
        {
            Thread.Sleep(TimeSpan.FromSeconds(timeoutInSeconds));
        }

        #endregion

        private FluentElement() { }

        private static readonly Lazy<FluentElement> Singleton =
            new Lazy<FluentElement>(() => new FluentElement());
    }
}
