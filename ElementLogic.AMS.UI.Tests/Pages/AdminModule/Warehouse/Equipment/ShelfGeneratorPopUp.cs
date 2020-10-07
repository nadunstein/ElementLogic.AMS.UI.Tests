using System;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Pages.AdminModule.Warehouse.Equipment
{
    public class ShelfGeneratorPopUp
    {
        private const string Iframe = "iframe";

        private const string ShelvesField = "#ShelfGeneratorView1_txtshelves_TextboxControl";

        private const string TypeField = "#ShelfGeneratorView1_ddlType";

        private const string LocationSizeField = "#ShelfGeneratorView1_ddlLocationSize";

        private const string PositionsField = "#ShelfGeneratorView1_txtPositions_TextboxControl";

        private const string DepthsField = "#ShelfGeneratorView1_txtDepths_TextboxControl";

        private const string MakeShelvesButton = "#ShelfGeneratorView1_btnMakeShelves";

        public static ShelfGeneratorPopUp Instance => Singleton.Value;

        public bool IsPopupDisplayed()
        {
            var popupDisplayed = PageObjectHelper.Instance.IsDisplayed(Iframe, true);
            PageObjectHelper.Instance.SwitchToIframeContent(Iframe);
            return popupDisplayed;
        }

        public bool InsertShelves(string value)
        {
            return PageObjectHelper.Instance.InsertField(ShelvesField, value);
        }

        public bool SelectType(string value)
        {
            return PageObjectHelper.Instance.SelectDropDown(TypeField, value);
        }

        public bool SelectLocationSize(string value)
        {
            return PageObjectHelper.Instance.SelectDropDown(LocationSizeField, value);
        }

        public bool InsertPositions(string value)
        {
            return PageObjectHelper.Instance.InsertField(PositionsField, value);
        }

        public bool InsertDepths(string value)
        {
            return PageObjectHelper.Instance.InsertField(DepthsField, value);
        }

        public bool ClickMakeShelvesButton()
        {
            var isMakeShelvesButtonClicked = PageObjectHelper.Instance.Click(MakeShelvesButton);
            PageObjectHelper.Instance.SwitchToDefaultWebPage();
            return isMakeShelvesButtonClicked;
        }

        private ShelfGeneratorPopUp() { }

        private static readonly Lazy<ShelfGeneratorPopUp> Singleton =
            new Lazy<ShelfGeneratorPopUp>(() => new ShelfGeneratorPopUp());
    }
}
