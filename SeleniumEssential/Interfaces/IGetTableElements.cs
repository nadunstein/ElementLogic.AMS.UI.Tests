namespace SeleniumEssential.Interfaces
{
    public interface IGetTableElements
    {
        int GetRowCount();

        IFindRowElements FindRowElements(int searchColumnIndex, string expectedSearchValue);
    }
}
