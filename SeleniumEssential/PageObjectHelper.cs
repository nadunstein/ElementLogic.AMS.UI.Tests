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
    public class PageObjectHelper : WebDriverBase
    {
        public static PageObjectHelper Instance => Singleton.Value;

        public void Navigate(string baseUrl, string pageUrl = null)
        {
            Driver.Url = string.Concat(baseUrl, pageUrl); 
            WaitForPageLoad(100);
        }

        public void Wait(double timeoutInSeconds)
        {
            ForcedWait(timeoutInSeconds);
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
            var iWebElementObject = (IWebElement) parentElement;
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

        public bool IsDisplayed(string element, bool waitUntilElementIsLoaded = false, bool waitForPageLoad = false)
        {
            if (waitForPageLoad)
            {
                WaitForPageLoad(50);
            }

            var elementBy = By.CssSelector(element);
            return !waitUntilElementIsLoaded ? IsElementDisplayed(elementBy) : WaitForElement(elementBy, 20);
        }

        public bool IsDisplayed(IWebElement element, bool waitUntilElementIsLoaded = false)
        {
            return !waitUntilElementIsLoaded ? IsElementDisplayed(element) : WaitForElement(element, 20);
        }

        public bool IsPageLoaded(string pageHeaderElement, string expectedPageName, string loadingElementToBeWait = null)
        {
            var attempts = 10;
            while (attempts > 0)
            {
                WaitForPageLoad(50);
                if (loadingElementToBeWait != null)
                {
                    WaitUntilInvisible(loadingElementToBeWait);
                }

                var pageHeaderName = GetTextValue(pageHeaderElement);
                if (pageHeaderName == expectedPageName)
                {
                    return true;
                }
                attempts--;
                ForcedWait(0.5);
            }

            return false;
        }

        public bool IsEnabled(string element)
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            var elementBy = By.CssSelector(element);
            try
            {
                return Driver.FindElement(elementBy).Enabled;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool WaitUntilInvisible(string element)
        {
            Wait(0.25);
            var elementBy = By.CssSelector(element);
            var elementDisplayed = true;
            var timeoutInSeconds = 100;
            while (timeoutInSeconds > 0)
            {
                elementDisplayed = IsElementDisplayed(elementBy);
                if (!elementDisplayed)
                {
                    break;
                }

                ForcedWait(0.5);
                timeoutInSeconds--;
            }

            return !elementDisplayed;
        }

        public bool IsFocused(string element)
        {
            var elementBy = By.CssSelector(element);
            return Driver.FindElement(elementBy).Equals(Driver.SwitchTo().ActiveElement());
        }

        public bool Click(string element, bool waitForPageLoad = false)
        {
            if (waitForPageLoad)
            {
                WaitForPageLoad(50);
            }

            var attempts = 0;
            var isElementDisplayed = false;
            while (attempts < 20)
            {
                try
                {
                    GetIWebElement(element).Click();
                    isElementDisplayed = true;
                    break;
                }
                catch (Exception)
                {
                    ForcedWait(0.5);
                    attempts++;
                }
            }

            return isElementDisplayed;
        }

        public bool Click(object element)
        {
            var iWebElementObject = (IWebElement) element;
            var attempts = 0;
            var isElementDisplayed = false;
            while (attempts < 5)
            {
                try
                {
                    iWebElementObject.Click();
                    isElementDisplayed = true;
                    break;
                }
                catch (Exception)
                {
                    ForcedWait(0.5);
                    attempts++;
                }
            }

            return isElementDisplayed;
        }

        public void ClickEnterButton(string element)
        {
            var attempts = 0;
            while (attempts < 20)
            {
                try
                {
                    GetIWebElement(element).SendKeys(Keys.Enter);
                    break;
                }
                catch (Exception)
                {
                    ForcedWait(0.5);
                }

                attempts++;
            }
        }

        public void ClickTabButton(string element)
        {
            var attempts = 0;
            while (attempts < 20)
            {
                try
                {
                    GetIWebElement(element).SendKeys(Keys.Tab);
                    break;
                }
                catch (Exception)
                {
                    ForcedWait(0.5);
                }

                attempts++;
            }
        }

        public bool ClearField(string element)
        {
            var attempts = 0;
            var isElementDisplayed = false;
            while (attempts < 20)
            {
                try
                {
                    GetIWebElement(element).Clear();
                    isElementDisplayed = true;
                    break;
                }
                catch (Exception)
                {
                    ForcedWait(0.5);
                    attempts++;
                }
            }

            return isElementDisplayed;
        }

        public bool InsertField(string element, string insertValue)
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

        public bool SelectDropDown(string dropdown, string selectOption)
        {
            var attempts = 0;
            var isDropDownValueSelected = false;
            while (attempts < 20)
            {
                try
                {
                    var select = new SelectElement(GetIWebElement(dropdown));
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

        public bool SelectDropDown(string dropdown, string dropdownList, string dropdownOptionsIdentifier, string selectOption)
        {
            if (!string.IsNullOrEmpty(dropdown))
            {
                var clicked = Click(dropdown);
                if (!clicked)
                {
                    return false;
                }
            }

            var displayed = IsDisplayed(dropdownList, true);
            if (!displayed)
            {
                return false;
            }

            var attempts = 0;
            while (attempts < 5)
            {
                try
                {
                    var options = Finds(dropdownOptionsIdentifier, dropdownList);
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

        public bool SelectIWebElementDropDown(object dropdown, string dropdownListIdentifier, string dropdownOptionsIdentifier, string selectOption)
        {
            var iWebElementObject = (IWebElement) dropdown;
            var clicked = Click(iWebElementObject);
            if (!clicked)
            {
                return false;
            }

            var attempts = 0;
            while (attempts < 5)
            {
                try
                {
                    var dropdownListElement = Finds(dropdownListIdentifier, iWebElementObject);
                    var options = Finds(dropdownOptionsIdentifier, dropdownListElement[0]);
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

        public bool SelectSearchDropDown(string searchDropdown, string searchDropdownList, string dropdownOptionsIdentifier, string searchOption)
        {
            try
            {
                InsertField(searchDropdown, searchOption);
                IsDisplayed(searchDropdownList, true);

                var attempts = 0;
                while (attempts < 5)
                {
                    try
                    {
                        var options = Finds(dropdownOptionsIdentifier, searchDropdownList);
                        if (options.Count.Equals(1) && GetTextValue(options[0]).Contains(searchOption))
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

            }
            catch (Exception)
            {
                //Ignore
            }

            return false;
        }

        public string GetTextValue(string element, bool isPageTitle = false)
        {
            if (isPageTitle)
            {
                WaitForPageLoad(50);
            }

            var attempts = 0;
            while (attempts < 20)
            {
                string value;
                try
                {
                    value = GetIWebElement(element).Text;
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

        public string GetTextValue(object element)
        {
            var iWebElementObject = (IWebElement) element;
            var attempts = 0;
            while (attempts < 5)
            {
                string value;
                try
                {
                    value = iWebElementObject.Text;
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

        public string GetAttributeValue(string element, string attribute)
        {
            var attempts = 0;
            while (attempts < 20)
            {
                string value;
                try
                {
                    value = GetIWebElement(element).GetAttribute(attribute);
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

        public IList<string> GetTableColumnDataSet(string table, int columnIndex)
        {
            var attempts = 0;
            while (attempts < 20)
            {
                try
                {
                    var tableRecords = Finds("tr", table);
                    return tableRecords.Select(tableRecord => Finds("td", tableRecord))
                        .Select(tableData => tableData[columnIndex - 1].Text).ToList();
                }

                catch (Exception)
                {
                     Wait(0.5);
                     attempts++;
                }
            }

            return null;
        }

        public bool TableDataExists(string table, int searchColumnIndex, string expectedValue)
        {
            var result = false;
            var attempts = 0;
            while (attempts < 20)
            {
                try
                {
                    result = Finds("tr", table)
                        .Select(tableRow => Finds("td", tableRow)).Any(tableData =>
                            tableData[searchColumnIndex - 1].Text.Contains(expectedValue));
                }
                catch (Exception)
                {
                    // ignored
                }

                if (result)
                {
                    break;
                }

                Wait(0.5);
                attempts++;
            }

            return result;
        }

        public bool SearchAndClickTableCellItem(string table, int searchColumnIndex, string expectedSearchValue, 
            int clickColumnIndex, string clickElementFinder)
        {
            var result = false;
            var attempts = 0;
            while (attempts < 20)
            {
                try
                {
                    var tableRows = Finds("tr", table);
                    foreach (var tableRow in tableRows)
                    {
                        var tableData = Finds("td", tableRow);

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

                Wait(0.5);
                attempts++;
            }

            return result;
        }

        public void SwitchToIframeContent(string iframe) 
        {
            var webElementIframe = GetIWebElement(iframe);
            WaitForElement(webElementIframe, 20);
            Driver.SwitchTo().Frame(webElementIframe);
        }

        public void SwitchToDefaultWebPage()
        {
            Driver.SwitchTo().DefaultContent();
        }

        public bool ScrollToTheElement(string element)
        {
            var result = false;
            try
            {
                var elementBy = By.CssSelector(element);
                var webElement = Driver.FindElement(elementBy);
                var js = Driver as IJavaScriptExecutor;
                js?.ExecuteScript("arguments[0].scrollIntoView(true);", webElement);
                result = true;
            }
            catch (Exception)
            {
                //ignore
            }

            return result;
        }

        public void RefreshWebPage()
        {
            Driver.Navigate().Refresh();
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

        public void DeleteBrowserCookies()
        {
            Driver.Manage().Cookies.DeleteAllCookies();
        }

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

        private static void ForcedWait(double timeoutInSeconds)
        {
            var timeInMilliseconds = timeoutInSeconds * 1000;
            Thread.Sleep(TimeSpan.FromMilliseconds(timeInMilliseconds));
        }

        private static void WaitForPageLoad(int timeoutInSeconds)
        {
            timeoutInSeconds *= 100;
            for (var i = 0; i <= timeoutInSeconds; i++)
            {
                if (Driver.ExecuteJavaScript<string>("return document.readyState").Equals("complete"))
                {
                    break;
                }

                ForcedWait(0.01);
            }
        }

        private static bool WaitForElement(By element, int timeoutInSeconds)
        {
            timeoutInSeconds *= 100;
            var elementDisplayed = false;
            var count = 0;

            while (count < timeoutInSeconds && !elementDisplayed)
            {
                elementDisplayed = IsElementDisplayed(element);
                ForcedWait(0.01);
                count ++;
            }

            return elementDisplayed;
        }

        private static bool WaitForElement(IWebElement element, int timeoutInSeconds)
        {
            timeoutInSeconds *= 100;
            var elementDisplayed = false;
            var count = 0;

            while (count < timeoutInSeconds && !elementDisplayed)
            {
                elementDisplayed = IsElementDisplayed(element);
                ForcedWait(0.01);
                count++;
            }

            return elementDisplayed;
        }

        private static bool IsElementDisplayed(By element)
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);

            try
            {
                return Driver.FindElement(element).Displayed;
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

        private PageObjectHelper() { }

        private static readonly Lazy<PageObjectHelper> Singleton =
            new Lazy<PageObjectHelper>(() => new PageObjectHelper());
    }
}
