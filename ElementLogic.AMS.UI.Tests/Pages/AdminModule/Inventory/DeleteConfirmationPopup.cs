using System;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Pages.AdminModule.Inventory
{
    public class DeleteConfirmationPopup
    {
        private const string Popup = ".rwTable";

        private const string YesButton = ".rwTable .btn-confirm";

        public static DeleteConfirmationPopup Instance => Singleton.Value;

        public bool IsPopupDisplayed()
        {
            return FluentElement.Instance
                .WaitForElement(Popup)
                .IsVisible();
        }

        public bool ClickYesButton()
        {
            return FluentElement.Instance
                .WaitForElement(YesButton)
                .Click();
        }

        private DeleteConfirmationPopup() { }

        private static readonly Lazy<DeleteConfirmationPopup> Singleton =
            new Lazy<DeleteConfirmationPopup>(() => new DeleteConfirmationPopup());
    }
}
