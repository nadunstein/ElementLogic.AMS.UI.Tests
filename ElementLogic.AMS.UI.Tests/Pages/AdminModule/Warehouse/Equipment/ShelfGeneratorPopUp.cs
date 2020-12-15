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
            return FluentElement.Instance
                .WaitForElement(Iframe)
                .IsVisible();
        }

        public bool InsertShelves(string value)
        {
            return FluentElement.Instance
                .SwitchToIframe(Iframe)
                .WaitForElement(ShelvesField)
                .Insert(value);
        }

        public bool SelectType(string value)
        {
            return FluentElement.Instance
                .SwitchToIframe(Iframe)
                .WaitForElement(TypeField)
                .SelectDropDown(value);
        }

        public bool SelectLocationSize(string value)
        {
            return FluentElement.Instance
                .SwitchToIframe(Iframe)
                .WaitForElement(LocationSizeField)
                .SelectDropDown(value);
        }

        public bool InsertPositions(string value)
        {
            return FluentElement.Instance
                .SwitchToIframe(Iframe)
                .WaitForElement(PositionsField)
                .Insert(value);
        }

        public bool InsertDepths(string value)
        {
            return FluentElement.Instance
                .SwitchToIframe(Iframe)
                .WaitForElement(DepthsField)
                .Insert(value);
        }

        public bool ClickMakeShelvesButton()
        {
            return FluentElement.Instance
                .SwitchToIframe(Iframe)
                .WaitForElement(MakeShelvesButton)
                .Click();
        }

        private ShelfGeneratorPopUp() { }

        private static readonly Lazy<ShelfGeneratorPopUp> Singleton =
            new Lazy<ShelfGeneratorPopUp>(() => new ShelfGeneratorPopUp());
    }
}
