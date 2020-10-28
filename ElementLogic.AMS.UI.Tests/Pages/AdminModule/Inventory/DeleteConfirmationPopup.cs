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
            return PageObjectHelper.Instance.IsDisplayed(Popup, true);
        }

        public bool ClickYesButton()
        {
            return PageObjectHelper.Instance.Click(YesButton);
        }

        private DeleteConfirmationPopup() { }

        private static readonly Lazy<DeleteConfirmationPopup> Singleton =
            new Lazy<DeleteConfirmationPopup>(() => new DeleteConfirmationPopup());
    }
}
