namespace SeleniumEssential.Interfaces
{
    public interface IGetRowElement
    {
        string GetText();

        bool SelectTableDropDown(string dropdownListIdentifier, string dropdownOptionsIdentifier, string selectOption);

        IFindElement FindElement(string element);
    }
}
