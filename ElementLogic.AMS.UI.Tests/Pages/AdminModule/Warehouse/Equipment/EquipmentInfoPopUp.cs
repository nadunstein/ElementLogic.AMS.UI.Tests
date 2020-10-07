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
            return PageObjectHelper.Instance.IsDisplayed(PopUp, true);
        }

        public bool ClickYesButton()
        {
            return PageObjectHelper.Instance.Click(YesButton);
        }

        private EquipmentInfoPopUp() { }

        private static readonly Lazy<EquipmentInfoPopUp> Singleton =
            new Lazy<EquipmentInfoPopUp>(() => new EquipmentInfoPopUp());
    }
}
