using System;
using System.Linq;
using ElementLogic.AMS.UI.Tests.Integration;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Pages.AdminModule.Automation.AutostoreEquipmentList.LiveFeedStatus
{
    public class LiveFeedStatus
    {
        private const string PageHeader = "#live-feed .container-fluid h3";
        
        private const string LiveFeedTable = "#live-feed table tbody";
        
        private const string LiveFeedActions = "tbody tr";
        
        private const string ShowHideResponsesButton = "#live-feed .btn-primary";
        
        private const string ActionDropDownIcon = "#actions";
        
        private const string ActionDropDownMenu = ".dropdown-menu";

        public static LiveFeedStatus Instance => Singleton.Value;

        public void Navigate()
        {
            const string liveFeedStatusPageUrl =
                "/Pages/Controller/StatusLiveFeed.aspx?portid=0&name=AutoStore%20Grid";
            string baseUrl = JsonFileReader.Instance.GetJsonKeyValue("Configuration/Environment.json", "Application:Url");
            PageObjectHelper.Instance.Navigate(baseUrl, liveFeedStatusPageUrl);
        }

        public bool IsPageLoaded()
        {
            return PageObjectHelper.Instance.IsPageLoaded(PageHeader, "Live feed status");
        }

        public bool IsLiveFeedActionListed(string liveFeedAction)
        {
            return PageObjectHelper.Instance.TableDataExists(LiveFeedTable, 2, liveFeedAction);
        }

        public bool ClickShowHideResponsesButton()
        {
            return PageObjectHelper.Instance.Click(ShowHideResponsesButton);
        }

        public bool IsLiveFeedResponseDisplayed(string liveFeedAction)
        {
            var actions = PageObjectHelper.Instance.Finds(
                LiveFeedActions, LiveFeedTable);
            return (from action in actions
                let actionColumns = PageObjectHelper.Instance.Finds("td", action)
                where actionColumns[1].Text.Contains(liveFeedAction)
                select PageObjectHelper.Instance.Finds("td", action)
                into tableRowData
                select PageObjectHelper.Instance.IsDisplayed(tableRowData[3])).FirstOrDefault();
        }

        public string GetLiveMessage(string liveFeedActionMessageType, string liveFeedAction)
        {
            PageObjectHelper.Instance.Wait(3);
            var actions = PageObjectHelper.Instance.Finds(
                LiveFeedActions, LiveFeedTable);

            return (from action in actions
                select PageObjectHelper.Instance.Finds("td", action)
                into actionColumns
                where actionColumns[1].Text.Contains(liveFeedAction)
                select liveFeedActionMessageType switch
                {
                    "Request" => actionColumns[2].Text,
                    "Response" => actionColumns[3].Text,
                    _ => null
                }).FirstOrDefault();
        }

        public bool SelectActionDropDownOption(string option)
        {
            return PageObjectHelper.Instance.SelectDropDown(ActionDropDownIcon, 
                ActionDropDownMenu, ".dropdown-item", option);
        }

        private LiveFeedStatus() { }

        private static readonly Lazy<LiveFeedStatus> Singleton = new Lazy<LiveFeedStatus>(() => new LiveFeedStatus());
    }
}
