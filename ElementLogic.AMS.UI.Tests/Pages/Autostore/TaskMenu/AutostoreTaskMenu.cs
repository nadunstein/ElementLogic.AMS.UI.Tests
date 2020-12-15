using System;
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
            return FluentElement.Instance
                .WaitForPageLoad()
                .WaitUntilInvisible(LoadingPanel)
                .WaitForElement(PageHeader)
                .Text()
                .Equals("AutoStore task menu");
        }

        public bool IsPageDisplayed()
        {
            return FluentElement.Instance
                .WaitForPageLoad()
                .WaitUntilInvisible(LoadingPanel)
                .IsVisible(PutawayTaskMenu);
        }

        public bool ClickPutawayTaskType(string taskName)
        {
            return FluentElement.Instance
                .WaitForElement(PutawayTaskMenu)
                .FindElements("a h3")
                .SearchElementByText(taskName)
                .Click();
        }

        public bool ClickPickTaskType(string taskName)
        {
            return FluentElement.Instance
                .WaitForElement(PickTaskMenu)
                .FindElements("a h3")
                .SearchElementByText(taskName)
                .Click();
        }

        public bool ClickInventoryTaskType(string taskName)
        {
            return FluentElement.Instance
                .WaitForElement(InventoryTaskMenu)
                .Wait(1)
                .FindElements("a h3")
                .SearchElementByText(taskName)
                .Click();
        }

        public bool IsPreparedPickTaskgroupCountDisplayed(string taskName)
        {
            return FluentElement.Instance
                .WaitForElement(PickTaskMenu)
                .FindElements("a")
                .SearchElementByText(taskName)
                .FindElement(PreparedTaskgroupCountLabel)
                .IsVisible();
        }

        public string GetPreparedPickTaskgroupCount(string taskName)
        {
            return FluentElement.Instance
                .WaitForElement(PickTaskMenu)
                .FindElements("a")
                .SearchElementByText(taskName)
                .FindElement(PreparedTaskgroupCountLabel)
                .GetText();
        }

        public bool ClickLogout()
        {
            return FluentElement.Instance
                .WaitForElement(LogoutButton)
                .Click();
        }

        private AutostoreTaskMenu() { }

        private static readonly Lazy<AutostoreTaskMenu> Singleton =
            new Lazy<AutostoreTaskMenu>(() => new AutostoreTaskMenu());
    }
}
