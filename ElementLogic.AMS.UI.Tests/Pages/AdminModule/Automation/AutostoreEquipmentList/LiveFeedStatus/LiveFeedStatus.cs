using System;
using System.Linq;
using ElementLogic.AMS.UI.Tests.Configuration;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Pages.AdminModule.Automation.AutostoreEquipmentList.LiveFeedStatus
{
    public class LiveFeedStatus
    {
        private const string PageHeader = "#live-feed .container-fluid h3";
        
        private const string LiveFeedTable = "#live-feed table";
        
        private const string LiveFeedActions = "tbody tr";
        
        private const string ShowHideResponsesButton = "#live-feed .btn-primary";
        
        private const string ActionDropDownIcon = "#actions";
        
        private const string ActionDropDownMenu = ".dropdown-menu";

        public static LiveFeedStatus Instance => Singleton.Value;

        public void Navigate()
        {
            const string liveFeedStatusPageUrl =
                "/Pages/Controller/StatusLiveFeed.aspx?portid=0&name=AutoStore%20Grid";
            string baseUrl = ConfigFileReader.Instance.ConfigurationKeyValue("Application:Url");
            PageObjectHelper.Instance.Navigate(baseUrl, liveFeedStatusPageUrl);
        }

        public string GetPageTitle()
        {
            return PageObjectHelper.Instance.GetTextValue(PageHeader, true);
        }

        public bool IsLiveFeedActionListed(string liveFeedAction)
        {
            var actions = PageObjectHelper.Instance.Finds(
                LiveFeedActions, LiveFeedTable);

            return actions
                .Select(action => PageObjectHelper.Instance.Finds("td", action))
                .Any(actionColumns => actionColumns[1].Text.Contains(liveFeedAction));
        }

        public bool ClickShowHideResponsesButton()
        {
            return PageObjectHelper.Instance.Click(ShowHideResponsesButton);
        }

        public bool IsLiveFeedResponseDisplayed(string liveFeedAction)
        {
            var actions = PageObjectHelper.Instance.Finds(
                LiveFeedActions, LiveFeedTable);

            foreach (var action in actions)
            {
                var actionColumns = PageObjectHelper.Instance.Finds("td", action);
                if (!actionColumns[1].Text.Contains(liveFeedAction))
                {
                    continue;
                }

                try
                {
                    return PageObjectHelper.Instance.Finds("td", action)[3].Displayed;
                }
                catch (Exception)
                {
                    return false;
                }
            }

            return false;
        }

        public string GetLiveFeedXml(string xmlType, string liveFeedAction)
        {
            var actions = PageObjectHelper.Instance.Finds(
                LiveFeedActions, LiveFeedTable);

            return (from action in actions
                select PageObjectHelper.Instance.Finds("td", action)
                into actionColumns
                where actionColumns[1].Text.Contains(liveFeedAction)
                select xmlType switch
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
