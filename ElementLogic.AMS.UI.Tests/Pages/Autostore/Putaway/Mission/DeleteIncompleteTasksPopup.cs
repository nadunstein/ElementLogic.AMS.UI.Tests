using System;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Pages.Autostore.Putaway.Mission
{
    public class DeleteIncompleteTasksPopup
    {
        private const string Popup = ".rwTable";

        private const string YesButton = "#asMasterRadConfirmYesButton";

        public static DeleteIncompleteTasksPopup Instance => Singleton.Value;

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

        private DeleteIncompleteTasksPopup() { }

        private static readonly Lazy<DeleteIncompleteTasksPopup> Singleton =
            new Lazy<DeleteIncompleteTasksPopup>(() => new DeleteIncompleteTasksPopup());
    }
}
