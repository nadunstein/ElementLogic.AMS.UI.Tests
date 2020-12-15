﻿using System;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Pages.Autostore.Refill
{
    public class RefillTaskgroupSelection
    {
        private const string PageHeader = "#ctl00_head_HeaderView_lblCurrentOperation";

        private const string TaskgroupSelectionGrid =
            "#ctl00_MonitorContentPlaceholder_taskGroupSelectionView_TaskGrid_ctl00 > tbody";

        private const string ExitButton = "#ctl00_MonitorContentPlaceholder_taskGroupSelectionView_exitButton";

        public static RefillTaskgroupSelection Instance => Singleton.Value;

        public bool IsPageLoaded()
        {
            return FluentElement.Instance
                .WaitForPageLoad()
                .WaitForElement(PageHeader)
                .Text()
                .Equals("Task group selection");
        }

        public bool IsPageDisplayed()
        {
            return FluentElement.Instance
                .IsVisible(TaskgroupSelectionGrid);
        }

        public bool ClickTaskgroupSelectButton(string trolleyName)
        {
            return FluentElement.Instance
                .SearchAndClickTableCellItem(TaskgroupSelectionGrid, 3, 
                    trolleyName, 1, ".as-button-md-green");
        }

        public bool ClickExitButton()
        {
            return FluentElement.Instance
                .WaitForElement(ExitButton)
                .Click();
        }

        private RefillTaskgroupSelection() { }

        private static readonly Lazy<RefillTaskgroupSelection> Singleton =
            new Lazy<RefillTaskgroupSelection>(() => new RefillTaskgroupSelection());
    }
}
