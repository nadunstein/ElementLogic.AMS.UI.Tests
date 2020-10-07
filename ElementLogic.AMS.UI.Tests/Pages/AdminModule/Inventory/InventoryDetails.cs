using System;
using AutoStoreManagementSystem.UITests.Types.Enums;
using ElementLogic.AMS.UI.Tests.Data.DatabaseQueries;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Pages.AdminModule.Inventory
{
    public class InventoryDetails
    {
        private const string PageHeader =
            "#ctl00_ContentPlaceHolderContent_AddEditInventoryView1_RadPanelBar1 .rpText";

        private const string FromProductDropdown =
            "#ctl00_ContentPlaceHolderContent_AddEditInventoryView1_fromProductDropdown_Input";

        private const string FromProductDropdownSlide =
            "#ctl00_ContentPlaceHolderContent_AddEditInventoryView1_fromProductDropdown_DropDown .rcbList";

        private const string FromLocationDropdown =
            "#ctl00_ContentPlaceHolderContent_AddEditInventoryView1_fromLocationDropDownList_Input";

        private const string FromLocationDropdownSlide =
            "#ctl00_ContentPlaceHolderContent_AddEditInventoryView1_fromLocationDropDownList_DropDown .rcbList";

        private const string RemoveButton =
            "#ctl00_ContentPlaceHolderContent_AddEditInventoryView1_rtbTopBar > div > div > div > ul > li:nth-child(2) > a > span > span > span > span";

        private const string AddButton =
            "#ctl00_ContentPlaceHolderContent_AddEditInventoryView1_AddButton";

        private const string MaximumLinesPerTaskgroupField =
            "#ctl00_ContentPlaceHolderContent_AddEditInventoryView1_RadPanelBar1_i0_flbMaxLines_TextboxControl";

        private const string TaskgroupListGrid =
            "#ctl00_ContentPlaceHolderContent_AddEditInventoryView1_taskGroupCountGrid_ctl00 > tbody";

        private const string TaskgroupExpander =
            "#ctl00_ContentPlaceHolderContent_AddEditInventoryView1_taskGroupCountGrid_ctl00_ctl04_GECBtnExpandColumn";

        private const string InventoryMissionListGrid =
            "#ctl00_ContentPlaceHolderContent_AddEditInventoryView1_taskGroupCountGrid_ctl00_ctl06_missionGrid_ctl00 > tbody";

        private const string FirstInventoryRecordRow =
            "#ctl00_ContentPlaceHolderContent_AddEditInventoryView1_taskGroupCountGrid_ctl00__0";

        private const string ActionMenuGearIcon =
            "#ctl00_ContentPlaceHolderContent_AddEditInventoryView1_taskGroupCountGrid_ctl00_ctl04_ctl01";

        private const string ActionMenuSlide =
            "#ctl00_ContentPlaceHolderContent_AddEditInventoryView1_taskGroupCountGrid_ctl00_ctl04_ctl01 .rmSlide";

        public static InventoryDetails Instance => Singleton.Value;

        public string GetPageTitle()
        {
            return PageObjectHelper.Instance.GetTextValue(PageHeader, true);
        }

        public bool ClickRemoveButton()
        {
            return PageObjectHelper.Instance.Click(RemoveButton);
        }

        public bool ClickAddButton()
        {
            return PageObjectHelper.Instance.Click(AddButton);
        }

        public bool InsertProduct(string productId)
        {
            return PageObjectHelper.Instance.SelectSearchDropDown(FromProductDropdown, 
                FromProductDropdownSlide, "li",productId);
        }

        public bool InsertLocation(string locationId)
        {
            return PageObjectHelper.Instance.SelectSearchDropDown(FromLocationDropdown, 
                FromLocationDropdownSlide, "li", locationId);
        }

        public bool IsFirstInventoryRecordRowDisplayed()
        {
            return PageObjectHelper.Instance.IsDisplayed(FirstInventoryRecordRow, true);
        }

        public int GetTaskgroupCount()
        {
            var taskGroups = PageObjectHelper.Instance.Finds("li", 
                TaskgroupListGrid);
            return taskGroups.Count;
        }

        public bool IsInventoryMissionListGridDisplayed()
        {
            return PageObjectHelper.Instance.IsDisplayed(InventoryMissionListGrid, true);
        }

        public int GetFirstTaskGroupMissionCount()
        {
            var taskgroupMissions = PageObjectHelper.Instance.Finds("tr",
                InventoryMissionListGrid);
            return taskgroupMissions.Count;
        }

        public string GetTaskGroupId()
        {
            var inventoryDetails = PageObjectHelper.Instance.Finds("td",
                FirstInventoryRecordRow);
            var taskgroupId = inventoryDetails[3].Text;
            return taskgroupId;
        }

        public string GetMaximumLinesPerFieldValue()
        {
            return PageObjectHelper.Instance.GetAttributeValue(MaximumLinesPerTaskgroupField, "Value");
        }

        public bool SelectActionMenuOption(string option)
        {
            return PageObjectHelper.Instance.SelectDropDown(ActionMenuGearIcon, ActionMenuSlide, 
                "li", option);
        }

        public bool ClickTaskgroupExpander()
        {
            return PageObjectHelper.Instance.Click(TaskgroupExpander);
        }

        public bool IsInventoryTaskActivated(string taskgroupId)
        {
            var timeOut = 0;
            string inventoryOrderStatusId;
            var statusToWait = LineStatus.Prepared.ToString("d");

            do
            {
                inventoryOrderStatusId = Mission.Instance.GetMissionStatusFromTaskgroupId(taskgroupId);
                PageObjectHelper.Instance.Wait(1);
                timeOut++;
            } while (!statusToWait.Contains(inventoryOrderStatusId) && timeOut < 100);

            return !timeOut.Equals(50);
        }

        private InventoryDetails() { }

        private static readonly Lazy<InventoryDetails> Singleton =
            new Lazy<InventoryDetails>(() => new InventoryDetails());
    }
}
