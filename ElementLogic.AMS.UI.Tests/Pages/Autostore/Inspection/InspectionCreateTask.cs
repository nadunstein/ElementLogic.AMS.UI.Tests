using System;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Pages.Autostore.Inspection
{
    public class InspectionCreateTask
    {
        private const string PageHeader = "#ctl00_head_HeaderView_lblCurrentOperation";

        private const string LocationField = "#ctl00_MonitorContentPlaceholder_InspectionTaskView_txtBinNo";

        private const string ConfirmButton = "#ctl00_MonitorContentPlaceholder_InspectionTaskView_btnConfirm";

        public static InspectionCreateTask Instance => Singleton.Value;

        public bool IsPageLoaded()
        {
            return PageObjectHelper.Instance.IsDisplayed(LocationField, true);
        }

        public string GetPageTitle()
        {
            return PageObjectHelper.Instance.GetTextValue(PageHeader, true);
        }

        public bool IncludeLocationValue(string location)
        {
            return PageObjectHelper.Instance.InsertField(LocationField, location);
        }

        public bool ClickConfirmButton()
        {
            return PageObjectHelper.Instance.Click(ConfirmButton);
        }

        private InspectionCreateTask() { }

        private static readonly Lazy<InspectionCreateTask> Singleton =
            new Lazy<InspectionCreateTask>(() => new InspectionCreateTask());
    }
}
