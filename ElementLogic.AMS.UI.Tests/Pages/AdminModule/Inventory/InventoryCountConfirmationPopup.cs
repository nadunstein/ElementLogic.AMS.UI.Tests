using System;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Pages.AdminModule.Inventory
{
    public class InventoryCountConfirmationPopup
    {
        private const string Popup = ".rwTable";

        private const string PopupMessage = "#divMessage > P";

        private const string YesButton =
            ".rwTable > tbody > .rwContentRow > .rwWindowContent  > div > .row  .col-md-8 span span";

        public static InventoryCountConfirmationPopup Instance => Singleton.Value;

        public bool IsPopupDisplayed()
        {
            return PageObjectHelper.Instance.IsDisplayed(Popup, true);
        }

        public string GetPopupMessage()
        {
            return PageObjectHelper.Instance.GetTextValue(PopupMessage);
        }

        public bool ClickYesButton()
        {
            return PageObjectHelper.Instance.Click(YesButton);
        }

        private InventoryCountConfirmationPopup() { }

        private static readonly Lazy<InventoryCountConfirmationPopup> Singleton =
            new Lazy<InventoryCountConfirmationPopup>(() => new InventoryCountConfirmationPopup());
    }
}
