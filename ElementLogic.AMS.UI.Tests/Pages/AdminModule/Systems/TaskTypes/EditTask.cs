using System;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Pages.AdminModule.Systems.TaskTypes
{
    public class EditTask
    {
        private const string PageHeader =
            "#ctl00_ContentPlaceHolderContent_AddEditTaskTypeView1_lblHeader";
        
        private const string CodeField =
            "#ctl00_ContentPlaceHolderContent_AddEditTaskTypeView1_flbCode_InputTemplateItem_txtCode";
        
        private const string NameField =
            "#ctl00_ContentPlaceHolderContent_AddEditTaskTypeView1_flbName_InputTemplateItem_txtName";
        
        private const string PriorityField =
            "#ctl00_ContentPlaceHolderContent_AddEditTaskTypeView1_flbPriority_InputTemplateItem_rdnPriority";
        
        private const string MinQueueLengthField =
            "#ctl00_ContentPlaceHolderContent_AddEditTaskTypeView1_flbMinQueueLength_InputTemplateItem_rdnMinQueueLength";
        
        private const string MaxQueueLengthField =
            "#ctl00_ContentPlaceHolderContent_AddEditTaskTypeView1_flbMaxQueueLength_InputTemplateItem_rdnMaxQueueLength";
        
        private const string SqlField =
            "#ctl00_ContentPlaceHolderContent_AddEditTaskTypeView1_flbSQL_InputTemplateItem_txtSql";
        
        private const string SequenceField =
            "#ctl00_ContentPlaceHolderContent_AddEditTaskTypeView1_flbSequence_InputTemplateItem_rdnSequence";
        
        private const string ShipmentField =
            "#ctl00_ContentPlaceHolderContent_AddEditTaskTypeView1_flbShipment_InputTemplateItem_rdnShipment";
        
        private const string ActivityTypeDropDown =
            "#ctl00_ContentPlaceHolderContent_AddEditTaskTypeView1_flbActivitytype_InputTemplateItem_rcbActivitytype_Input";
        
        private const string ActivityTypeDropDownList =
            "#ctl00_ContentPlaceHolderContent_AddEditTaskTypeView1_flbActivitytype_InputTemplateItem_rcbActivitytype_DropDown";
        
        private const string SaveButton =
            "#ctl00_ContentPlaceHolderContent_AddEditTaskTypeView1_rtbTopBar .rtbText";

        public static EditTask Instance => Singleton.Value;

        public bool IsPageLoaded()
        {
            return PageObjectHelper.Instance.IsPageLoaded(PageHeader, "Edit task");
        }

        public bool InsertCode(string value)
        {
            return PageObjectHelper.Instance.InsertField(CodeField, value);
        }

        public bool InsertName(string value)
        {
            return PageObjectHelper.Instance.InsertField(NameField, value);
        }

        public bool InsertPriority(string value)
        {
            return PageObjectHelper.Instance.InsertField(PriorityField, value);
        }

        public bool InsertMinQueueLength(string value)
        {
            return PageObjectHelper.Instance.InsertField(MinQueueLengthField, value);
        }

        public bool InsertMaxQueueLength(string value)
        {
            return PageObjectHelper.Instance.InsertField(MaxQueueLengthField, value);
        }

        public bool InsertSql(string value)
        {
            return PageObjectHelper.Instance.InsertField(SqlField, value);
        }

        public bool InsertSequence(string value)
        {
            return PageObjectHelper.Instance.InsertField(SequenceField, value);
        }

        public bool InsertShipment(string value)
        {
            return PageObjectHelper.Instance.InsertField(ShipmentField, value);
        }

        public bool SelectActivityType(string value)
        {
            if (PageObjectHelper.Instance.GetAttributeValue(ActivityTypeDropDown, "value").Equals(value))
            {
                return true;
            }

            return PageObjectHelper.Instance.SelectDropDown(ActivityTypeDropDown, 
                ActivityTypeDropDownList, "li", value);
        }

        public bool ClickSaveButton()
        {
            return PageObjectHelper.Instance.Click(SaveButton);
        }

        private EditTask() { }

        private static readonly Lazy<EditTask> Singleton = new Lazy<EditTask>(() => new EditTask());
    }
}
