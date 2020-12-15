using System;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Pages.AdminModule.Warehouse.Equipment
{
    public class EquipmentInfoPopUp
    {
        private const string PopUp = ".rwTable";

        private const string YesButton = ".popup-btn-container .col-md-8 span span";

        public static EquipmentInfoPopUp Instance => Singleton.Value;

        public bool IsPopUpDisplayed()
        {
            return FluentElement.Instance
                .WaitForElement(PopUp)
                .IsVisible();
        }

        public bool ClickYesButton()
        {
            return FluentElement.Instance
                .WaitForElement(YesButton)
                .Click();
        }

        private EquipmentInfoPopUp() { }

        private static readonly Lazy<EquipmentInfoPopUp> Singleton =
            new Lazy<EquipmentInfoPopUp>(() => new EquipmentInfoPopUp());
    }
}
