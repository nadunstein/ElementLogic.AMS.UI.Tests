using System;
using System.Linq;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Pages.Autostore.TaskMenu
{
    public class AutostoreTaskMenu
    {
        private const string PageHeader = "#ctl00_head_HeaderView_lblCurrentOperation";

        private const string LoadingPanel = "#ctl00_pnlDataHider .ModalLoadingPanel";

        private const string PutawayTaskMenu = "#as-task-menu .row > div:nth-child(1)";

        private const string PickTaskMenu = "#as-task-menu .row > div:nth-child(2)";

        private const string InventoryTaskMenu = "#as-task-menu .row > div:nth-child(3)";

        private const string LogoutButton = "#ctl00_MonitorContentPlaceholder_TaskMenuView_Button1";

        private const string PreparedTaskgroupCountLabel = ".ml-4 .badge";

        public static AutostoreTaskMenu Instance => Singleton.Value;

        public bool IsPageLoaded()
        {
            return PageObjectHelper.Instance.IsPageLoaded(PageHeader, "AutoStore task menu",
                LoadingPanel);
        }

        public bool IsPageDisplayed()
        {
            PageObjectHelper.Instance.WaitUntilInvisible(LoadingPanel);
            return PageObjectHelper.Instance.IsDisplayed(PutawayTaskMenu);
        }

        public bool ClickPutawayTaskType(string taskName)
        {
            var putawayTaskTypes = PageObjectHelper.Instance.Finds("a h3", PutawayTaskMenu);
            return (from putawayTaskType in putawayTaskTypes
                    where PageObjectHelper.Instance.GetTextValue(putawayTaskType).Contains(taskName)
                    select PageObjectHelper.Instance.Click(putawayTaskType)).FirstOrDefault();
        }

        public bool ClickPickTaskType(string taskName)
        {
            var pickTaskTypes = PageObjectHelper.Instance.Finds("a h3", PickTaskMenu);
            return (from pickTaskType in pickTaskTypes
                    where PageObjectHelper.Instance.GetTextValue(pickTaskType).Contains(taskName)
                    select PageObjectHelper.Instance.Click(pickTaskType)).FirstOrDefault();
        }

        public bool ClickInventoryTaskType(string taskName)
        {
            var inventoryTaskTypes = PageObjectHelper.Instance.Finds("a h3", InventoryTaskMenu);
            return (from inventoryTaskType in inventoryTaskTypes
                    where PageObjectHelper.Instance.GetTextValue(inventoryTaskType).Contains(taskName)
                    select PageObjectHelper.Instance.Click(inventoryTaskType)).FirstOrDefault();
        }

        public bool IsPreparedPickTaskgroupCountDisplayed(string taskName)
        {
            var pickTaskTypes = PageObjectHelper.Instance.Finds("a", PickTaskMenu);
            return (from pickTaskType in pickTaskTypes
                    where pickTaskType.Text.Contains(taskName)
                    select PageObjectHelper.Instance.Finds(PreparedTaskgroupCountLabel, pickTaskType)
                into elementsIdentified
                    select elementsIdentified.Count != 0).FirstOrDefault();
        }

        public string GetPreparedPickTaskgroupCount(string taskName)
        {
            var pickTaskTypes = PageObjectHelper.Instance.Finds("a", PickTaskMenu);
            return (from pickTaskType in pickTaskTypes
                    where pickTaskType.Text.Contains(taskName)
                    select PageObjectHelper.Instance.Finds(PreparedTaskgroupCountLabel, pickTaskType)
                into elementsIdentified
                    select elementsIdentified[0].Text).FirstOrDefault();
        }

        public bool ClickLogout()
        {
            return PageObjectHelper.Instance.Click(LogoutButton);
        }

        private AutostoreTaskMenu() { }

        private static readonly Lazy<AutostoreTaskMenu> Singleton =
            new Lazy<AutostoreTaskMenu>(() => new AutostoreTaskMenu());
    }
}
