using System;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Pages.AdminModule.Warehouse.Equipment
{
    public class EditShelf
    {
        private const string PageHeader =
            "#ctl00_ContentPlaceHolderContent_AddEditShelfView1_lblHeader";

        private const string ShelfNumberField =
            "#ctl00_ContentPlaceHolderContent_AddEditShelfView1_txtShelfNo_TextboxControl";

        private const string SaveButton =
            "#ctl00_ContentPlaceHolderContent_AddEditShelfView1_rtbTopBar .rtbUL li:nth-child(1) .rtbText";
       
        private const string CancelButton =
            "#ctl00_ContentPlaceHolderContent_AddEditShelfView1_rtbTopBar .rtbUL li:nth-child(3) .rtbText";

        public static EditShelf Instance => Singleton.Value;

        public bool IsPageLoaded()
        {
            return FluentElement.Instance
                .WaitForPageLoad()
                .WaitForElement(PageHeader)
                .Text()
                .Equals("Shelf");
        }

        public bool InsertShelfNumber(int value)
        {
            var valueString = value.ToString();
            return FluentElement.Instance
                .WaitForElement(ShelfNumberField)
                .Insert(valueString);
        }

        public bool ClickSaveButton()
        {
            return FluentElement.Instance
                .WaitForElement(SaveButton)
                .Click();
        }

        public bool ClickCancelButton()
        {
            return FluentElement.Instance
                .WaitForElement(CancelButton)
                .Click();
        }

        private EditShelf() { }

        private static readonly Lazy<EditShelf> Singleton = new Lazy<EditShelf>(() => new EditShelf());
    }
}
