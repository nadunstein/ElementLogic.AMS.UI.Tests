using System;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Pages.Autostore.Pick
{
    public class SerialNumberValidationPopup
    {
        private const string Popup = "#noty_layout__center";

        private const string PopUpMessage = "#noty_layout__center .noty_body";

        private const string OkButton = "#noty_layout__center #btnWarningOk";

        public static SerialNumberValidationPopup Instance => Singleton.Value;

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

        private SerialNumberValidationPopup() { }

        private static readonly Lazy<SerialNumberValidationPopup> Singleton =
            new Lazy<SerialNumberValidationPopup>(() => new SerialNumberValidationPopup());
    }
}
