using System;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Pages.Autostore.Pick
{
    public class ContainerValidationPopup
    {
        private const string Notification = ".noty_body";

        public static ContainerValidationPopup Instance => Singleton.Value;

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

        private ContainerValidationPopup() { }

        private static readonly Lazy<ContainerValidationPopup> Singleton =
            new Lazy<ContainerValidationPopup>(() => new ContainerValidationPopup());
    }
}
