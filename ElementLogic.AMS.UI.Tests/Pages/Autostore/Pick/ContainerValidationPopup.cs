using System;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Pages.Autostore.Pick
{
    public class ContainerValidationPopup
    {
        private const string Popup = "#noty_layout__center";

        private const string PopUpMessage = "#noty_layout__center .noty_body";

        private const string OkButton = "#noty_layout__center #btnWarningOk";

        public static ContainerValidationPopup Instance => Singleton.Value;

        public bool IsPopupDisplayed()
        {
            return PageObjectHelper.Instance.IsDisplayed(Popup, true);
        }

        public string GetPopupMessage()
        {
            return PageObjectHelper.Instance.GetTextValue(PopUpMessage);
        }

        public bool ClickOkButton()
        {
            return PageObjectHelper.Instance.Click(OkButton);
        }

        private ContainerValidationPopup() { }

        private static readonly Lazy<ContainerValidationPopup> Singleton =
            new Lazy<ContainerValidationPopup>(() => new ContainerValidationPopup());
    }
}
