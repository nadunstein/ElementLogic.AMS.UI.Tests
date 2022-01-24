namespace SeleniumEssential.Interfaces
{
    public interface IFindRowElements
    {
        bool IsExists();

        IGetRowElement GetRowElement(int searchColumnIndex);
    }
}
