using System;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Pages.Autostore.Pick
{
    public class SerialNumberValidationPopup
    {
        private const string Notification = ".noty_body";

        public static SerialNumberValidationPopup Instance => Singleton.Value;

        public bool IsPopupDisplayed()
        {
            return FluentElement.Instance
                .WaitForElement(Notification)
                .IsVisible();
        }

        public string GetPopupMessage()
        {
            return FluentElement.Instance
                .Wait(2)
                .WaitForElement(Notification)
                .GetText();
        }

        private SerialNumberValidationPopup() { }

        private static readonly Lazy<SerialNumberValidationPopup> Singleton =
            new Lazy<SerialNumberValidationPopup>(() => new SerialNumberValidationPopup());
    }
}
