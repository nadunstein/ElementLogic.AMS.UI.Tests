using System;
using ElementLogic.AMS.UI.Tests.Integration;
using ElementLogic.AMS.UI.Tests.Pages.AdminModule.Automation.AutostoreEquipmentList.LiveFeedStatus;
using SeleniumEssential;
using LoginPage = ElementLogic.AMS.UI.Tests.Pages.Login.Login;

namespace ElementLogic.AMS.UI.Tests.Features.SupportTasks
{
    public class SynchronizeAutostoreBins
    {
        public static SynchronizeAutostoreBins Instance => Singleton.Value;

        public void DoAutostoreBinSync()
        {
            var browserMode =
                bool.Parse(JsonFileReader.Instance.GetJsonKeyValue("Configuration/Environment.json",
                    "BrowserSettings:ChromeBrowser:HeadlessMode"));
            WebDriverHelper.Instance.InitializeChromeDriver("Drivers/ChromeDriver", browserMode);

            LiveFeedStatus.Instance.Navigate();
            LoginPage.Instance.LoginToApplication("Admin");
            LiveFeedStatus.Instance.IsPageLoaded();
            LiveFeedStatus.Instance.SelectActionDropDownOption("Synchronize bin contents");
            SynchronizeBinContentsPopup.Instance.IsPopupDisplayed();
            SynchronizeBinContentsPopup.Instance.ClickSynchronizeButton();
            WebDriverHelper.Instance.QuitDriver();
        }

        private SynchronizeAutostoreBins() { }

        private static readonly Lazy<SynchronizeAutostoreBins> Singleton =
            new Lazy<SynchronizeAutostoreBins>(() => new SynchronizeAutostoreBins());
    }
}
