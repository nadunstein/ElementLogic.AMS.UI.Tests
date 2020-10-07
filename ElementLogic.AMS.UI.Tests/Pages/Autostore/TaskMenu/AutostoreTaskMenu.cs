using System;
using System.Linq;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Pages.Autostore.TaskMenu
{
    public class AutostoreTaskMenu
    {
        private const string PageHeader = "#ctl00_head_HeaderView_lblCurrentOperation";

        private const string LoadingPanel = "#ctl00_pnlDataHider .ModalLoadingPanel";

        private const string InspectionTile = "#ctl00_MonitorContentPlaceholder_TaskMenuView_btnInspection";

        private const string InventoryTile = "#ctl00_MonitorContentPlaceholder_TaskMenuView_btnInventory";

        private const string PutawayTaskMenu = ".as-task-menu-col-left";

        private const string PickTaskMenu = ".as-task-menu-col-center";

        private const string RefillTile = "#ctl00_MonitorContentPlaceholder_TaskMenuView_RefillButtonContainer";

        private const string LogoutButton = "#ctl00_MonitorContentPlaceholder_TaskMenuView_Button1";

        private const string PrepTaskgroupTaskTypePrepareCount =
            "#ctl00_MonitorContentPlaceholder_TaskMenuView_repeaterPickButtons_ctl04_ItemCountLabel";

        public static AutostoreTaskMenu Instance => Singleton.Value;

        public string GetPageTitle()
        {
            PageObjectHelper.Instance.WaitUntilInvisible(LoadingPanel);
            return PageObjectHelper.Instance.GetTextValue(PageHeader, true);
        }

        public bool IsPageDisplayed()
        {
            PageObjectHelper.Instance.WaitUntilInvisible(LoadingPanel);
            return PageObjectHelper.Instance.IsDisplayed(InspectionTile);
        }

        public bool ClickPutawayTaskType(string taskName)
        {
            var putawayTaskTypes = PageObjectHelper.Instance.Finds("a", PutawayTaskMenu);
            return (from putawayTaskType in putawayTaskTypes
                where putawayTaskType.Text.Contains(taskName.Trim())
                select PageObjectHelper.Instance.Click(putawayTaskType)).FirstOrDefault();
        }

        public bool ClickPickTaskType(string taskName)
        {
            var pickTaskTypes = PageObjectHelper.Instance.Finds("a", PickTaskMenu);
            return (from pickTaskType in pickTaskTypes
                where pickTaskType.Text.Contains(taskName.Trim())
                select PageObjectHelper.Instance.Click(pickTaskType)).FirstOrDefault();
        }

        public bool ClickInspectionTile()
        {
            return PageObjectHelper.Instance.Click(InspectionTile);
        }

        public bool ClickInventoryTile()
        {
            return PageObjectHelper.Instance.Click(InventoryTile);
        }

        public bool ClickRefillTile()
        {
            var isScrolledToElement = PageObjectHelper.Instance.ScrollToTheElement(RefillTile);
            var isClicked =  PageObjectHelper.Instance.Click(RefillTile);
            return isScrolledToElement && isClicked;
        }

        public bool ClickLogout()
        {
            return PageObjectHelper.Instance.Click(LogoutButton);
        }

        public string GetPreparedPickOrderCount()
        {
            return PageObjectHelper.Instance.GetTextValue(PrepTaskgroupTaskTypePrepareCount);
        }

        private AutostoreTaskMenu() { }

        private static readonly Lazy<AutostoreTaskMenu> Singleton =
            new Lazy<AutostoreTaskMenu>(() => new AutostoreTaskMenu());
    }
}
