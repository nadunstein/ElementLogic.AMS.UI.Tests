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
            return FluentElement.Instance
                .WaitForElement(Popup)
                .IsVisible();
        }

        public string GetPopupMessage()
        {
            return FluentElement.Instance
                .WaitForElement(PopUpMessage)
                .GetText();
        }

        public bool ClickOkButton()
        {
            return FluentElement.Instance
                .WaitForElement(OkButton)
                .Click();
        }

        private ContainerValidationPopup() { }

        private static readonly Lazy<ContainerValidationPopup> Singleton =
            new Lazy<ContainerValidationPopup>(() => new ContainerValidationPopup());
    }
}
