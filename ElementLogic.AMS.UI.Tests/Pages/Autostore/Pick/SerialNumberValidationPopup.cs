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

        private SerialNumberValidationPopup() { }

        private static readonly Lazy<SerialNumberValidationPopup> Singleton =
            new Lazy<SerialNumberValidationPopup>(() => new SerialNumberValidationPopup());
    }
}
