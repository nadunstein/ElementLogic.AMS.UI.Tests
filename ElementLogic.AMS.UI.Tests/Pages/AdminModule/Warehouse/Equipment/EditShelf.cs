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
            return PageObjectHelper.Instance.IsPageLoaded(PageHeader, "Shelf");
        }

        public bool InsertShelfNumber(int value)
        {
            return PageObjectHelper.Instance.InsertField(ShelfNumberField, value.ToString());
        }

        public bool ClickSaveButton()
        {
            return PageObjectHelper.Instance.Click(SaveButton);
        }

        public bool ClickCancelButton()
        {
            return PageObjectHelper.Instance.Click(CancelButton);
        }

        private EditShelf() { }

        private static readonly Lazy<EditShelf> Singleton = new Lazy<EditShelf>(() => new EditShelf());
    }
}
