using System;
using ElementLogic.AMS.UI.Tests.Integration;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Pages.AdminModule.Automation.AutostoreEquipmentList.LiveFeedStatus
{
    public class LiveFeedStatus
    {
        private const string PageHeader = "#live-feed .container-fluid h3";
        
        private const string LiveFeedTable = "#live-feed table tbody";
        
        private const string ShowHideResponsesButton = "#live-feed .btn-primary";
        
        private const string ActionDropDownIcon = "#actions";
        
        private const string ActionDropDownMenu = ".dropdown-menu";

        public static LiveFeedStatus Instance => Singleton.Value;

        public void Navigate()
        {
            const string liveFeedStatusPageUrl =
                "/Pages/Controller/StatusLiveFeed.aspx?portid=0&name=AutoStore%20Grid";
            var baseUrl = JsonFileReader.Instance
                .GetJsonKeyValue("Configuration/Environment.json", "Application:Url");
            var pageUrl = baseUrl + liveFeedStatusPageUrl;
            FluentElement.Instance
                .Navigate(pageUrl);
        }

        public bool IsPageLoaded()
        {
            return FluentElement.Instance
                .WaitForPageLoad()
                .WaitForElement(PageHeader)
                .Text()
                .Equals("Live feed status");
        }

        public bool IsLiveFeedActionListed(string liveFeedAction)
        {
            return FluentElement.Instance
                .WaitForElement(LiveFeedTable)
                .GetTableElements()
                .FindRowElements(2, liveFeedAction)
                .IsExists();
        }

        public bool ClickShowHideResponsesButton()
        {
            return FluentElement.Instance
                .WaitForElement(ShowHideResponsesButton)
                .Click();
        }

        public bool IsLiveFeedResponseDisplayed(string liveFeedAction)
        {
            return !FluentElement.Instance
                .WaitForElement(LiveFeedTable)
                .GetTableElements()
                .FindRowElements(2, liveFeedAction)
                .GetRowElement(4)
                .GetText()
                .Equals(null);
        }

        public string GetLiveFeedMessage(string liveFeedActionMessageType, string liveFeedAction)
        {
            var liveFeedActionColumnIndex = liveFeedActionMessageType == "Request" ? 3 : 4;
            return FluentElement.Instance
                 .WaitForElement(LiveFeedTable)
                 .GetTableElements()
                 .FindRowElements(2, liveFeedAction)
                 .GetRowElement(liveFeedActionColumnIndex)
                 .GetText();
        }

        public bool SelectActionDropDownOption(string option)
        {
            return FluentElement.Instance
                .WaitForElement(ActionDropDownIcon)
                .SelectDropDown(ActionDropDownMenu, 
                    ".dropdown-item", option);
        }

        private LiveFeedStatus() { }

        private static readonly Lazy<LiveFeedStatus> Singleton = new Lazy<LiveFeedStatus>(() => new LiveFeedStatus());
    }
}
