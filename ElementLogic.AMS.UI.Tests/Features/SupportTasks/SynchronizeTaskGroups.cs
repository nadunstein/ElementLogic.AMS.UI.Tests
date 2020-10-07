using System;
using ElementLogic.AMS.UI.Tests.Configuration;
using ElementLogic.AMS.UI.Tests.Pages.AdminModule.Automation.AutostoreEquipmentList.LiveFeedStatus;
using NUnit.Framework;
using SeleniumEssential;
using LoginPage = ElementLogic.AMS.UI.Tests.Pages.Login.Login;

namespace ElementLogic.AMS.UI.Tests.Features.SupportTasks
{
    public class SynchronizeTaskGroups
    {
        public static SynchronizeTaskGroups Instance => Singleton.Value;

        public void DoAutostoreTaskGroupSync()
        {
            //var browserMode =
            //    bool.Parse(ConfigFileReader.Instance.ConfigurationKeyValue("BrowserSettings:ChromeBrowser:HeadlessMode"));
            //WebDriverHelper.Instance.InitializeChromeDriver("Drivers/ChromeDriver", browserMode);

            LiveFeedStatus.Instance.Navigate();
            LoginPage.Instance.LoginToApplication("Admin");
            Assert.AreEqual("Live feed status", LiveFeedStatus.Instance.GetPageTitle(),
                "The Live feed status page is NOT loaded");

            LiveFeedStatus.Instance.SelectActionDropDownOption("Synchronize task groups");
            Assert.AreEqual("Synchronize task groups", SynchronizeTaskGroupsPopUp.Instance.GetPopUpTitle(),
                "Synchronize task groups popUp is NOT displayed");
            SynchronizeTaskGroupsPopUp.Instance.ClickSynchronizeButton();

            //WebDriverHelper.Instance.QuitDriver();
        }

        private SynchronizeTaskGroups() { }

        private static readonly Lazy<SynchronizeTaskGroups> Singleton =
            new Lazy<SynchronizeTaskGroups>(() => new SynchronizeTaskGroups());
    }
}
