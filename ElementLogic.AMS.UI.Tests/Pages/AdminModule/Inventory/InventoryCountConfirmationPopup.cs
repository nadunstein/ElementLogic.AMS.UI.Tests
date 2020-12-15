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
            return FluentElement.Instance
                .WaitForElement(Popup)
                .IsVisible();
        }

        public string GetPopupMessage()
        {
            return FluentElement.Instance
                .WaitForElement(PopupMessage)
                .GetText();
        }

        public bool ClickYesButton()
        {
            return FluentElement.Instance
                .WaitForElement(YesButton)
                .Click();
        }

        private InventoryCountConfirmationPopup() { }

        private static readonly Lazy<InventoryCountConfirmationPopup> Singleton =
            new Lazy<InventoryCountConfirmationPopup>(() => new InventoryCountConfirmationPopup());
    }
}
