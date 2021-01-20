using System;
using System.Collections.ObjectModel;
using System.Data;
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
        private DataTable _commonDataTable;
        private DataRow _commonDataRowList;
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

        public bool ClickEnterButton()
        {
            var attempts = 0;
            while (attempts < 20)
            {
                try
                {
                    var iWebElement = GetIWebElement(_commonElement);
                    iWebElement.SendKeys(Keys.Enter);
                    return true;
                }
                catch (Exception)
                {
                    ForcedWait(0.5);
                }

                attempts++;
            }

            return false;
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
            WaitForElement(dropdownList, 5);
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
            WaitForElement(searchDropdownList, 5);
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

        public bool SelectTableDropDown(string dropdownListIdentifier, string dropdownOptionsIdentifier, string selectOption)
        {
            var dropdownIWebElement = _commonIWebElement;
            _commonIWebElement = null;
            var clicked = Click(dropdownIWebElement);
            if (!clicked)
            {
                return false;
            }

            var attempts = 0;
            while (attempts < 5)
            {
                try
                {
                    var dropdownListElement = dropdownIWebElement.FindElement(By.CssSelector(dropdownListIdentifier));
                    var options = dropdownListElement.FindElements(By.CssSelector(dropdownOptionsIdentifier));
                    var result = (from option in options
                        where GetTextValue(option).Contains(selectOption)
                        select Click(option)).FirstOrDefault();

                    if (result)
                    {
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
            ReadOnlyCollection<IWebElement> elementList = null;
            var attempts = 0;
            while (attempts < 20)
            { 
                elementList = GetList(_commonElement, elementListFinder);
                if (elementList.Count == 0)
                {
                    Wait(0.5);
                    attempts++;
                    continue;
                }

                break;
            }

            _commonElementList = elementList;
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

        public FluentElement GetTableElements()
        {
            var elementTable = new DataTable();
            elementTable.Clear();
            var numberOfTableColumns = GetList(_commonElement, "tr:nth-child(1) td").Count;
            for (var columnNumber = 1; columnNumber <= numberOfTableColumns; columnNumber++)
            {
                elementTable.Columns.Add(columnNumber.ToString(), typeof(IWebElement));
            }

            try
            {
                var tableRows = GetList(_commonElement, "tr");
                foreach (var tableRow in tableRows)
                {
                    var tableColumns = GetList(tableRow, "td");
                    var dataRow = elementTable.NewRow();
                    var count = 0;
                    foreach (var tableColumn in tableColumns)
                    {
                        dataRow[count] = tableColumn;
                        count++;
                    }

                    elementTable.Rows.Add(dataRow);
                }
            }
            catch (Exception)
            {
                //ignore
            }

            _commonDataTable = elementTable;
            return this;
        }

        public int GetRowCount()
        {
            return _commonDataTable.Rows.Count;
        }

        public bool IsExists()
        {
            return _commonDataRowList != null;
        }

        public FluentElement FindRowElements(int searchColumnIndex, string expectedSearchValue)
        {
            var attempts = 0;
            while (attempts < 20)
            {
                DataTable datRowTable = null;
                try
                {
                    datRowTable = _commonDataTable.AsEnumerable()
                        .Where(r => r.Field<IWebElement>(searchColumnIndex - 1).Text
                            .Contains(expectedSearchValue)).CopyToDataTable();
                }
                catch (Exception)
                {
                    //ignore
                }

                if (datRowTable == null || datRowTable.Rows[0].Table.Rows.Count == 0)
                {
                    Wait(0.5);
                    GetTableElements();
                    attempts++;
                    continue;
                }

                _commonDataRowList = datRowTable.Rows[0];
                break;
            }

            return this;
        }

        public FluentElement GetRowElement(int searchColumnIndex)
        {
            _commonIWebElement = (IWebElement)_commonDataRowList.ItemArray[searchColumnIndex - 1];
            return this;
        }

        public ReadOnlyCollection<IWebElement> Finds(string elementFinder, string parentElementString = null)
        {
            var attempts = 0;
            while (attempts < 20)
            {
                try
                {
                    return string.IsNullOrEmpty(parentElementString)
                        ? Driver.FindElements(By.CssSelector(elementFinder))
                        : GetIWebElement(parentElementString).FindElements(By.CssSelector(elementFinder));
                }
                catch (Exception)
                {
                    ForcedWait(0.5);
                }

                attempts++;
            }

            return null;
        }

        public ReadOnlyCollection<IWebElement> Finds(string elementFinder, object parentElement)
        {
            var iWebElementObject = (IWebElement)parentElement;
            var attempts = 0;
            while (attempts < 20)
            {
                try
                {
                    return iWebElementObject.FindElements(By.CssSelector(elementFinder));
                }
                catch (Exception)
                {
                    ForcedWait(0.5);
                }

                attempts++;
            }

            return null;
        }

        public void DeleteBrowserCookies()
        {
            Driver.Manage().Cookies.DeleteAllCookies();
        }

        public bool OpenNewBrowserTab()
        {
            var currentOpenedTabs = Driver.WindowHandles.Count;
            var js = (IJavaScriptExecutor)Driver;
            js.ExecuteScript("window.open();");
            var numberOfOpenedTabs = Driver.WindowHandles.Count - currentOpenedTabs;
            return numberOfOpenedTabs == 1;
        }

        public bool SwitchToBrowserTab(int tabIndexToBeSwitched)
        {
            try
            {
                var tabToBeSwitched = Driver.WindowHandles[tabIndexToBeSwitched - 1];
                Driver.SwitchTo().Window(tabToBeSwitched);
                return true;
            }
            catch (Exception)
            {
                // ignored
            }

            return false;
        }

        public int GetOpenedBrowserTabCount()
        {
            return Driver.WindowHandles.Count;
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
