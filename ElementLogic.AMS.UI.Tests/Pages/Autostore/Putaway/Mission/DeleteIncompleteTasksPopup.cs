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
            return PageObjectHelper.Instance.IsDisplayed(Popup, true);
        }

        public bool ClickYesButton()
        {
            return PageObjectHelper.Instance.Click(YesButton);
        }

        private DeleteIncompleteTasksPopup() { }

        private static readonly Lazy<DeleteIncompleteTasksPopup> Singleton =
            new Lazy<DeleteIncompleteTasksPopup>(() => new DeleteIncompleteTasksPopup());
    }
}
