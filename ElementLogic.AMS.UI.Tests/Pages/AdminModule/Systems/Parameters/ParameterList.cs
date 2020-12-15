using System;
using ElementLogic.AMS.UI.Tests.Integration;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Pages.AdminModule.Systems.Parameters
{
    public class ParameterList
    {
        private const string PageHeader =
            "#ctl00_ContentPlaceHolderContent_SearchParamView1_RadPanelBar1 .rpText";

        private const string LoadingPanel = "#ctl00_LoadingPanelMenu";

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
            var baseUrl = JsonFileReader.Instance
                .GetJsonKeyValue("Configuration/Environment.json", "Application:Url");
            var pageUrl = baseUrl + parameterListUrl;
            FluentElement.Instance
                .Navigate(pageUrl);
        }

        public bool IsPageLoaded()
        {
            return FluentElement.Instance
                .WaitForPageLoad()
                .WaitForElement(PageHeader)
                .Text()
                .Equals("Parameter list");
        }

        public bool InsertParameterCode(string code)
        {
            return FluentElement.Instance
                .WaitForElement(Code)
                .Insert(code);
        }

        public bool ClickSearchButton()
        {
            return FluentElement.Instance
                .WaitForElement(SearchButton)
                .Click();
        }

        public bool IsFirstResultRowDisplayed()
        {
            return FluentElement.Instance
                .WaitUntilInvisible(LoadingPanel)
                .WaitForElement(FirstResultRow)
                .IsVisible();
        }

        public bool ClickEditButton()
        {
            return FluentElement.Instance
                .WaitForElement(EditButton)
                .Click();
        }

        private ParameterList() { }

        private static readonly Lazy<ParameterList> Singleton = new Lazy<ParameterList>(() => new ParameterList());
    }
}
