using System;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Pages.Autostore.Pick
{
    public class PickMission
    {
        private const string PageHeader = "#ctl00_head_HeaderView_lblCurrentOperation";

        private const string LoadingPanel = "#ctl00_pnlDataHider .ModalLoadingPanel";

        private const string TaskQueueLabel = "#ctl00_head_HeaderView_LblTaskQueue";

        private const string PossibleDelayLabel = "#ctl00_MonitorContentPlaceholder_PickView_lblDeviationLabel";

        private const string ProductNumberLabel =
            "#ctl00_MonitorContentPlaceholder_PickView_flbProduct_InputTemplateItem_txbProduct";

        private const string AutoStoreLocationLabel = "#ctl00_MonitorContentPlaceholder_PickView_txtBin";

        private const string MissionIdLabel =
            "#ctl00_MonitorContentPlaceholder_PickView_flbMissionId_InputTemplateItem_txtMissionId";

        private const string PickQuantityField = "#ctl00_MonitorContentPlaceholder_PickView_txtQuantity";

        private const string ConfirmQuantityField = "#ctl00_MonitorContentPlaceholder_PickView_txtQuantityConfirm";

        private const string ProductScanField = "#ctl00_MonitorContentPlaceholder_PickView_txtPickingScanField";

        private const string PickConfirmButton = "#ctl00_MonitorContentPlaceholder_PickView_btnConfirm";

        private const string NewContainerButton = "#ctl00_MonitorContentPlaceholder_PickView_rtbNewContainer";

        private const string NewContainerListPanel = ".rtbSlide";

        private const string OptionsButton = "#ctl00_MonitorContentPlaceholder_PickView_rtbOptions";

        private const string OptionsListPanel = ".rtbSlide";

        private const string ExitButton = "#ctl00_MonitorContentPlaceholder_PickView_btnExit";

        private const string AddNewContainerNotificationText = ".noty_body";

        private const string DeliveryLocationLabel =
            "#ctl00_MonitorContentPlaceholder_PickView_flbDeliveryLocation_LableText";

        private const string DeliveryLocationValue =
            "#ctl00_MonitorContentPlaceholder_PickView_flbDeliveryLocation_InputTemplateItem_txbDeliveryLocation";

        public static PickMission Instance => Singleton.Value;

        public string GetPageTitle()
        {
            return PageObjectHelper.Instance.GetTextValue(PageHeader, true);
        }

        public string GetTaskQueueLabelValue()
        {
            PageObjectHelper.Instance.WaitUntilInvisible(LoadingPanel);
            return PageObjectHelper.Instance.GetTextValue(TaskQueueLabel);
        }

        public bool IsPossibleDelayLabelDisplayed()
        {
            return PageObjectHelper.Instance.IsDisplayed(PossibleDelayLabel, true);
        }

        public string GetMissionIdLabelValue()
        {
            return PageObjectHelper.Instance.GetAttributeValue(MissionIdLabel, "Value");
        }

        public string GetProductNumberLabelValue()
        {
            return PageObjectHelper.Instance.GetAttributeValue(ProductNumberLabel, "Value");
        }

        public string GetPickLocation()
        {
            return PageObjectHelper.Instance.GetTextValue(AutoStoreLocationLabel);
        }

        public string GetDeliveryLocationValue()
        {
            return PageObjectHelper.Instance.GetAttributeValue(DeliveryLocationValue, "Value");
        }

        public string GetDeliveryLocationLabelName()
        {
            return PageObjectHelper.Instance.GetTextValue(DeliveryLocationLabel);
        }

        public int GetPickQuantityFieldValue()
        {
            return int.Parse(PageObjectHelper.Instance.GetAttributeValue(PickQuantityField, "Value"));
        }

        public bool InsertQuantity(string quantity)
        {
            return PageObjectHelper.Instance.InsertField(PickQuantityField, quantity);
        }

        public bool IsConfirmQuantityFieldDisplayed()
        {
            return PageObjectHelper.Instance.IsDisplayed(ConfirmQuantityField);
        }

        public bool IsConfirmQuantityFieldFocused()
        {
            return PageObjectHelper.Instance.IsFocused(ConfirmQuantityField);
        }

        public bool InsertConfirmQuantity(string quantity)
        {
            return PageObjectHelper.Instance.InsertField(ConfirmQuantityField, quantity);
        }

        public bool InsertProductScanValue(string scanValue)
        {
            PageObjectHelper.Instance.ScrollToTheElement(ProductScanField);
            return PageObjectHelper.Instance.InsertField(ProductScanField, scanValue);
        }

        public bool SelectContainer(string boxtype)
        {
            return PageObjectHelper.Instance.SelectDropDown(NewContainerButton, NewContainerListPanel,
                "li", boxtype);
        }

        public bool IsAddNewContainerNotificationDisplayed()
        {
            return PageObjectHelper.Instance.IsDisplayed(AddNewContainerNotificationText, true);
        }

        public string GetAddNewContainerNotificationTextValue()
        {
            return PageObjectHelper.Instance.GetTextValue(AddNewContainerNotificationText);
        }

        public bool SelectOption(string option)
        {
            return PageObjectHelper.Instance.SelectDropDown(OptionsButton, OptionsListPanel,
                "li", option);
        }

        public bool ClickConfirmButton()
        {
            return PageObjectHelper.Instance.Click(PickConfirmButton);
        }

        public bool ClickExitButton()
        {
            return PageObjectHelper.Instance.Click(ExitButton);
        }

        private PickMission() { }

        private static readonly Lazy<PickMission> Singleton = new Lazy<PickMission>(() => new PickMission());
    }
}
