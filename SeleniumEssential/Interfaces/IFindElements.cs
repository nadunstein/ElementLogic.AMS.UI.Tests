namespace SeleniumEssential.Interfaces
{
    public interface IFindElements
    {
        int GetCount();

        ISearchElementByText SearchElementByText(string elementText);

        ISearchElementByIndex SearchElementByIndex(int elementIndex);

        IFindElement FindElement(string element);
    }
}
