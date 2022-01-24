using System;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Pages.Autostore.Inspection
{
    public class InspectionCreateTask
    {
        private const string PageHeader = "#ctl00_head_HeaderView_lblCurrentOperation";

        private const string LocationField = "#ctl00_MonitorContentPlaceholder_InspectionTaskView_txtBinNo";

        private const string ProductDropDown = "#ctl00_MonitorContentPlaceholder_InspectionTaskView_cboProduct_Input";

        private const string BatchDropDown = "#ctl00_MonitorContentPlaceholder_InspectionTaskView_cboBatch_Input";

        private const string SelectLocationsButton = "#ctl00_MonitorContentPlaceholder_InspectionTaskView_btnSelect";

        private const string ConfirmButton = "#ctl00_MonitorContentPlaceholder_InspectionTaskView_btnConfirm";

        public static InspectionCreateTask Instance => Singleton.Value;

        public bool IsPageLoaded()
        {
            return FluentElement.Instance
                .WaitForPageLoad()
                .WaitForElement(PageHeader)
                .Text()
                .Equals("Inspection - Create task");
        }

        public bool IncludeLocationValue(string location)
        {
            return FluentElement.Instance
                .WaitForElement(LocationField)
                .Insert(location);
        }

        public bool SearchProductAndSelect(string productSearchText)
        {
            return FluentElement.Instance
                .WaitForElement(ProductDropDown)
                .SelectSearchDropDown(".rcbList", "li", productSearchText);
        }

        public bool SelectBatchId(string batchId)
        {
            return FluentElement.Instance
                .WaitForElement(BatchDropDown)
                .SelectDropDown(".rcbList", "li", batchId);
        }

        public bool ClickSelectLocationsButton()
        {
            return FluentElement.Instance
                .WaitForElement(SelectLocationsButton)
                .Click();
        }

        public bool ClickConfirmButton()
        {
            return FluentElement.Instance
                .WaitForElement(ConfirmButton)
                .Click();
        }

        private InspectionCreateTask() { }

        private static readonly Lazy<InspectionCreateTask> Singleton =
            new Lazy<InspectionCreateTask>(() => new InspectionCreateTask());
    }
}
