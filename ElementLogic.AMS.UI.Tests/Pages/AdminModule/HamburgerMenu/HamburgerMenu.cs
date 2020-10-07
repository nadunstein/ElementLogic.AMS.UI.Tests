using System;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Pages.AdminModule.HamburgerMenu
{
    public class HamburgerMenu
    {
        private const string HamburgerIcon = "#ctl00_radLoginInfo";

        private const string OptionMenu = "#ctl00_radLoginInfo .rmSlide ul";

        private const string LogOutOption = "#ctl00_radLoginInfo_i0_i1_LoginStatus1";

        public static HamburgerMenu Instance => Singleton.Value;

        public bool SelectLogOutOption()
        {
            var clickHamburgerIcon = PageObjectHelper.Instance.Click(HamburgerIcon);
            var isOptionMenuDisplayed = PageObjectHelper.Instance.IsDisplayed(OptionMenu, true);
            PageObjectHelper.Instance.Wait(1);
            var clickOption = PageObjectHelper.Instance.Click(LogOutOption);
            return clickHamburgerIcon && isOptionMenuDisplayed && clickOption;
        }

        private HamburgerMenu() { }

        private static readonly Lazy<HamburgerMenu>
            Singleton = new Lazy<HamburgerMenu>(() => new HamburgerMenu());
    }
}
