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

        public bool IsPageLoaded()
        {
            return FluentElement.Instance
                .WaitForPageLoad()
                .WaitForElement(PageHeader)
                .Text()
                .Equals("Inventory details");
        }

        public bool ClickRemoveButton()
        {
            return FluentElement.Instance
                .WaitForElement(RemoveButton)
                .Click();
        }

        public bool ClickAddButton()
        {
            return FluentElement.Instance
                .WaitForElement(AddButton)
                .Click();
        }

        public bool InsertProduct(string productId)
        {
            return FluentElement.Instance
                .WaitForElement(FromProductDropdown)
                .SelectSearchDropDown(FromProductDropdownSlide, "li",productId);
        }

        public bool InsertLocation(string locationId)
        {
            return FluentElement.Instance
                .WaitForElement(FromLocationDropdown)
                .SelectSearchDropDown(FromLocationDropdownSlide, "li", locationId);
        }

        public bool IsFirstInventoryRecordRowDisplayed()
        {
            return FluentElement.Instance
                .WaitForElement(FirstInventoryRecordRow)
                .IsVisible();
        }

        public int GetTaskgroupCount()
        {
            return FluentElement.Instance
                .WaitForElement(TaskgroupListGrid)
                .FindElements("li")
                .GetCount();
        }

        public bool IsInventoryMissionListGridDisplayed()
        {
            return FluentElement.Instance
                .WaitForElement(InventoryMissionListGrid)
                .IsVisible();
        }

        public int GetFirstTaskGroupMissionCount()
        {
            return FluentElement.Instance
                .WaitForElement(InventoryMissionListGrid)
                .FindElements( "tr")
                .GetCount();
        }

        public string GetTaskGroupId()
        {
            return FluentElement.Instance
                .WaitForElement(FirstInventoryRecordRow)
                .FindElements("td")
                .SearchElementByIndex(4)
                .GetText();
        }

        public string GetMaximumLinesPerFieldValue()
        {
            return FluentElement.Instance
                .WaitForElement(MaximumLinesPerTaskgroupField)
                .GetAttribute("value");
        }

        public bool SelectActionMenuOption(string option)
        {
            return FluentElement.Instance
                .WaitForElement(ActionMenuGearIcon)
                .SelectDropDown(ActionMenuSlide, 
                "li", option);
        }

        public bool ClickTaskgroupExpander()
        {
            return FluentElement.Instance
                .WaitForElement(TaskgroupExpander)
                .Click();
        }

        public bool IsInventoryTaskActivated(string taskgroupId)
        {
            var timeOut = 0;
            string inventoryOrderStatusId;
            var statusToWait = LineStatus.Prepared.ToString("d");

            do
            {
                inventoryOrderStatusId = Mission.Instance.GetMissionStatusFromTaskgroupId(taskgroupId);
                FluentElement.Instance.Wait(1);
                timeOut++;
            } while (!statusToWait.Contains(inventoryOrderStatusId) && timeOut < 100);

            return !timeOut.Equals(50);
        }

        private InventoryDetails() { }

        private static readonly Lazy<InventoryDetails> Singleton =
            new Lazy<InventoryDetails>(() => new InventoryDetails());
    }
}
