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

        private const string ContainerScanField = "#ctl00_MonitorContentPlaceholder_PickView_txtPlacingScanField";

        private const string PickConfirmButton = "#ctl00_MonitorContentPlaceholder_PickView_btnConfirm";

        private const string NewContainerButton = "#ctl00_MonitorContentPlaceholder_PickView_rtbNewContainer";

        private const string NewContainerListPanel = ".rtbSlide ul";

        private const string OptionsButton = "#ctl00_MonitorContentPlaceholder_PickView_rtbOptions";

        private const string OptionsListPanel = ".rtbSlide";

        private const string ExitButton = "#ctl00_MonitorContentPlaceholder_PickView_btnExit";

        private const string AddNewContainerNotificationText = ".noty_body";

        private const string DeliveryLocationLabel =
            "#ctl00_MonitorContentPlaceholder_PickView_flbDeliveryLocation_LableText";

        private const string DeliveryLocationValue =
            "#ctl00_MonitorContentPlaceholder_PickView_flbDeliveryLocation_InputTemplateItem_txbDeliveryLocation";

        public static PickMission Instance => Singleton.Value;

        public bool IsPageLoaded()
        {
            return FluentElement.Instance
                .WaitForPageLoad()
                .WaitUntilInvisible(LoadingPanel)
                .WaitForElement(PageHeader)
                .Text()
                .Equals("Picking");
        }

        public string GetTaskQueueValue()
        {
            return FluentElement.Instance
                .WaitUntilInvisible(LoadingPanel)
                .WaitForElement(TaskQueueLabel)
                .GetText();
        }

        public bool IsPossibleDelayLabelDisplayed()
        {
            return FluentElement.Instance
                .WaitForElement(PossibleDelayLabel)
                .IsVisible();
        }

        public string GetMissionIdValue()
        {
            return FluentElement.Instance
                .WaitForElement(MissionIdLabel)
                .GetAttribute("Value");
        }

        public string GetProductNumber()
        {
            return FluentElement.Instance
                .WaitUntilInvisible(LoadingPanel)
                .WaitForElement(ProductNumberLabel)
                .GetAttribute("Value");
        }

        public string GetPickLocation()
        {
            return FluentElement.Instance
                .WaitUntilInvisible(LoadingPanel)
                .WaitForElement(AutoStoreLocationLabel)
                .GetText();
        }

        public string GetDeliveryLocationValue()
        {
            return FluentElement.Instance
                .WaitForElement(DeliveryLocationValue)
                .GetAttribute("Value");
        }

        public string GetDeliveryLocationName()
        {
            return FluentElement.Instance
                .WaitForElement(DeliveryLocationLabel)
                .GetText();
        }

        public int GetPickQuantityFieldValue()
        {
            return int.Parse(FluentElement.Instance
                .WaitForElement(PickQuantityField)
                .GetAttribute("Value"));
        }

        public bool InsertQuantity(string quantity)
        {
            return FluentElement.Instance
                .WaitForElement(PickQuantityField)
                .Insert(quantity);
        }

        public bool IsConfirmQuantityFieldDisplayed()
        {
            return FluentElement.Instance
                .IsVisible(ConfirmQuantityField);
        }

        public bool IsConfirmQuantityFieldFocused()
        {
            return FluentElement.Instance
                .WaitForElement(ConfirmQuantityField)
                .IsFocused();
        }

        public bool InsertConfirmQuantity(string quantity)
        {
            return FluentElement.Instance
                .WaitForElement(ConfirmQuantityField)
                .Insert(quantity);
        }

        public bool InsertProductScanValue(string scanValue)
        {
            return FluentElement.Instance
                .WaitUntilInvisible(LoadingPanel)
                .WaitForElement(ProductScanField)
                .ScrollToTheElement()
                .Insert(scanValue);
        }

        public bool IsContainerScanFieldDisplayed()
        {
            return FluentElement.Instance
                .WaitForElement(ContainerScanField)
                .IsVisible();
        }

        public bool IsContainerScanFieldNotDisplayed()
        {
            return !FluentElement.Instance
                .IsVisible(ContainerScanField);
        }

        public bool InsertContainerScanValue(string scanValue)
        {
            return FluentElement.Instance
                .WaitForElement(ContainerScanField)
                .ScrollToTheElement()
                .Insert(scanValue);
        }

        public bool SelectContainer(string boxtype)
        {
            return FluentElement.Instance
                .WaitForElement(NewContainerButton)
                .SelectDropDown(NewContainerListPanel, 
                    "li", boxtype);
        }

        public bool IsAddNewContainerNotificationDisplayed()
        {
            return FluentElement.Instance
                .WaitForElement(AddNewContainerNotificationText)
                .IsVisible();
        }

        public string GetAddNewContainerNotificationTextValue()
        {
            return FluentElement.Instance
                .WaitForElement(AddNewContainerNotificationText)
                .GetText();
        }

        public bool SelectOption(string option)
        {
            return FluentElement.Instance
                .WaitForElement(OptionsButton)
                .SelectDropDown(OptionsListPanel, 
                    ".rtbItem", option);
        }

        public bool ClickConfirmButton()
        {
            return FluentElement.Instance
                .WaitForElement(PickConfirmButton)
                .Click();
        }

        public bool ClickExitButton()
        {
            return FluentElement.Instance
                .WaitForElement(ExitButton)
                .Click();
        }

        private PickMission() { }

        private static readonly Lazy<PickMission> Singleton = new Lazy<PickMission>(() => new PickMission());
    }
}
