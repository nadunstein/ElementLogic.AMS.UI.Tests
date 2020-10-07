using System;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Pages.AdminModule.Warehouse.Equipment
{
    public class AddEditEquipment
    {
        private const string PageHeader =
            "#ctl00_ContentPlaceHolderContent_AddEditEquipmentView1_lblHeader";

        private const string CodeField =
            "#ctl00_ContentPlaceHolderContent_AddEditEquipmentView1_txtCode_TextboxControl";

        private const string NameField =
           "#ctl00_ContentPlaceHolderContent_AddEditEquipmentView1_txtName_TextboxControl";

        private const string WarehouseZoneField =
            "#ctl00_ContentPlaceHolderContent_AddEditEquipmentView1_ddlWarehouseZone";

        private const string GroupField =
            "#ctl00_ContentPlaceHolderContent_AddEditEquipmentView1_cmbGroup_Input";

        private const string TypeField =
            "#ctl00_ContentPlaceHolderContent_AddEditEquipmentView1_ddlType";

        private const string DriverField =
            "#ctl00_ContentPlaceHolderContent_AddEditEquipmentView1_ddlDriver";

        private const string UsePickContainersCheckBox =
            "#ctl00_ContentPlaceHolderContent_AddEditEquipmentView1_usePickContainersCheckBox";

        private const string ActiveCheckBox =
            "#ctl00_ContentPlaceHolderContent_AddEditEquipmentView1_chkActive";

        private const string ManualCheckBox =
            "#ctl00_ContentPlaceHolderContent_AddEditEquipmentView1_chkManual";

        private const string WidthField =
            "#ctl00_ContentPlaceHolderContent_AddEditEquipmentView1_txtWidth_TextboxControl";

        private const string DepthField =
            "#ctl00_ContentPlaceHolderContent_AddEditEquipmentView1_txtDepth_TextboxControl";

        private const string HeightField =
            "#ctl00_ContentPlaceHolderContent_AddEditEquipmentView1_txtHeight_TextboxControl";

        private const string AutoAssignCheckBox =
            "#ctl00_ContentPlaceHolderContent_AddEditEquipmentView1_chkAutoAPL";

        private const string TaskTypeField =
            "#ctl00_ContentPlaceHolderContent_AddEditEquipmentView1_ddlTaskType";

        private const string SaveButton =
            "#ctl00_ContentPlaceHolderContent_AddEditEquipmentView1_rtbTopBar li:nth-child(1) .rtbText";

        private const string CancelButton =
            "#ctl00_ContentPlaceHolderContent_AddEditEquipmentView1_rtbTopBar li:nth-child(4) .rtbText";

        private const string ShelfGeneratorButton =
            "#ctl00_ContentPlaceHolderContent_AddEditEquipmentView1_rtbTopBar .rtbUL li:nth-child(7) .rtbText";

        private const string ShelfEditButton =
            "#ctl00_ContentPlaceHolderContent_AddEditEquipmentView1_rdgShelves_ctl00_ctl04_gbccolumn";

        public static AddEditEquipment Instance => Singleton.Value;

        public string GetPageTitle()
        {
            return PageObjectHelper.Instance.GetTextValue(PageHeader, true);
        }

        public bool InsertCode(string value)
        {
            return PageObjectHelper.Instance.InsertField(CodeField, value);
        }

        public bool InsertName(string value)
        {
            return PageObjectHelper.Instance.InsertField(NameField, value);
        }

        public bool SelectWarehouseZone(string value)
        {
            return PageObjectHelper.Instance.SelectDropDown(WarehouseZoneField, value);
        }

        public bool SelectGroup(string value)
        {
            return PageObjectHelper.Instance.SelectDropDown(GroupField, value);
        }

        public bool SelectType(string value)
        {
            return PageObjectHelper.Instance.SelectDropDown(TypeField, value);
        }

        public bool SelectDriver(string value)
        {
            return PageObjectHelper.Instance.SelectDropDown(DriverField, value);
        }

        public bool SelectUsePickContainersCheckBox()
        {
            return PageObjectHelper.Instance.Click(UsePickContainersCheckBox);
        }

        public bool SelectActiveCheckBox()
        {
            return PageObjectHelper.Instance.Click(ActiveCheckBox);
        }

        public bool SelectManualCheckBox()
        {
            return PageObjectHelper.Instance.Click(ManualCheckBox);
        }

        public bool InsertWidth(string value)
        {
            return PageObjectHelper.Instance.InsertField(WidthField, value);
        }

        public bool InsertDepth(string value)
        {
            return PageObjectHelper.Instance.InsertField(DepthField, value);
        }

        public bool InsertHeight(string value)
        {
            return PageObjectHelper.Instance.InsertField(HeightField, value);
        }

        public bool SelectAutoAssignCheckBox()
        {
            return PageObjectHelper.Instance.Click(AutoAssignCheckBox);
        }

        public bool SelectTaskType(string value)
        {
            return PageObjectHelper.Instance.SelectDropDown(TaskTypeField, value);
        }

        public bool ClickSaveButton()
        {
            return PageObjectHelper.Instance.Click(SaveButton);
        }

        public bool ClickCancelButton()
        {
            return PageObjectHelper.Instance.Click(CancelButton);
        }

        public bool ClickShelfGeneratorButton()
        {
            return PageObjectHelper.Instance.Click(ShelfGeneratorButton);
        }

        public bool ClickShelfEditButton()
        {
            return PageObjectHelper.Instance.Click(ShelfEditButton);
        }

        private AddEditEquipment() { }

        private static readonly Lazy<AddEditEquipment> Singleton =
            new Lazy<AddEditEquipment>(() => new AddEditEquipment());
    }
}
