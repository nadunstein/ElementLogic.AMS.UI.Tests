using System;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Pages.AdminModule.Warehouse.Equipment
{
    public class ShelfInfoPopUp
    {
        private const string PopUp = ".rwTable";

        private const string YesButton = ".popup-btn-container .col-md-8 span span";

        public static ShelfInfoPopUp Instance => Singleton.Value;

        public bool IsPopupDisplayed()
        {
            return FluentElement.Instance
                .WaitForElement(PopUp)
                .IsVisible();
        }

        public bool ClickYesButton()
        {
            return FluentElement.Instance
                .WaitForElement(YesButton)
                .Click();
        }

        private ShelfInfoPopUp() { }

        private static readonly Lazy<ShelfInfoPopUp> Singleton =
            new Lazy<ShelfInfoPopUp>(() => new ShelfInfoPopUp());
    }
}
