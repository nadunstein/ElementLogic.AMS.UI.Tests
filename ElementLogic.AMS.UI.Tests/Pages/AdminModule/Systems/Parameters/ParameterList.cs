using System;
using ElementLogic.AMS.UI.Tests.Integration;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Pages.AdminModule.Systems.Parameters
{
    public class ParameterList
    {
        private const string PageHeader =
            "#ctl00_ContentPlaceHolderContent_SearchParamView1_RadPanelBar1 .rpText";

        private const string Code =
            "#ctl00_ContentPlaceHolderContent_SearchParamView1_RadPanelBar1_i0_txtCode";

        private const string SearchButton =
            "#ctl00_ContentPlaceHolderContent_SearchParamView1_RadPanelBar1_i0_btnSearch";

        private const string FirstResultRow =
            ".rgMasterTable >tbody #ctl00_ContentPlaceHolderContent_SearchParamView1_grdParams_ctl00__0";

        private const string EditButton =
            "#ctl00_ContentPlaceHolderContent_SearchParamView1_grdParams_ctl00_ctl04_Image1";

        public static ParameterList Instance => Singleton.Value;

        public void Navigate()
        {
            const string parameterListUrl = "/pages/system/searchparameter.aspx";
            string baseUrl = JsonFileReader.Instance.GetJsonKeyValue("Configuration/Environment.json", "Application:Url");
            PageObjectHelper.Instance.Navigate(baseUrl, parameterListUrl);
        }

        public bool IsPageLoaded()
        {
            return PageObjectHelper.Instance.IsPageLoaded(PageHeader, "Parameter list");
        }

        public bool InsertParameterCode(string code)
        {
            return PageObjectHelper.Instance.InsertField(Code, code);
        }

        public bool ClickSearchButton()
        {
            return PageObjectHelper.Instance.Click(SearchButton);
        }

        public bool IsFirstResultRowDisplayed()
        {
            return PageObjectHelper.Instance.IsDisplayed(FirstResultRow, true);
        }

        public bool ClickEditButton()
        {
            return PageObjectHelper.Instance.Click(EditButton);
        }

        private ParameterList() { }

        private static readonly Lazy<ParameterList> Singleton = new Lazy<ParameterList>(() => new ParameterList());
    }
}
