namespace SeleniumEssential.Interfaces
{
    public interface IWaitForElement
    {
        IWaitForElement WaitForElement(string element);

        bool IsVisible();

        bool IsFocused();

        bool IsEnable();

        bool Insert(string insertValue);

        bool Click();

        bool ClickEnterButton();

        void ClickTabButton();

        string GetText();

        bool IsAttributePresent(string attribute);

        string GetAttribute(string attribute);

        bool SelectDropDown(string selectOption);

        bool SelectDropDown(string dropdownList, string dropdownOptionsIdentifier, string selectOption);

        bool SelectSearchDropDown(string searchDropdownList, string dropdownOptionsIdentifier, string searchOption);

        IText Text();

        IFindElements FindElements(string elementListFinder);

        IGetTableElements GetTableElements();

        IScrollToTheElement ScrollToTheElement();

        FluentElement Wait(double timeoutInSeconds);
    }
}
