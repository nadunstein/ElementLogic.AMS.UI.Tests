using System;
using System.Diagnostics;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumEssential
{
    public class WebDriverHelper : WebDriverBase
    {
        public static IWebDriver InitializeChromeDriver(string chromeDriverPath, bool browserHeadless)
        {
            var options = new ChromeOptions();

            if (browserHeadless)
            {
                options.AddArguments("headless");
            }

            options.AddArguments("--window-size=1920,1080");
            options.AddArguments("--ignore-certificate-errors");
            options.AddArguments("--disable-extensions");
            options.AddArguments("--disable-gpu");
            options.AddArguments("--disable-dev-shm-usage");
            options.AddArguments("--no-sandbox");
            options.AddArguments("--verbose");

            var projectAssemblyPath = FileHelper.GetProjectAssemblyPath();
            var chromeDriverFullPath = Path.Combine(projectAssemblyPath, chromeDriverPath);
            Driver = new ChromeDriver(chromeDriverFullPath, options, TimeSpan.FromMinutes(5));
            Driver.Manage().Window.Maximize();
            return Driver;
        }

        public static void QuitDriver()
        {
            Driver.Quit();
        }

        public static void QuitDriver(IWebDriver driver)
        {
            driver.Quit();
        }

        public static void KillProcess(string processName)
        {
            var chromeDriverProcesses = Process.GetProcessesByName(processName);

            foreach (var chromeDriverProcess in chromeDriverProcesses)
            {
                chromeDriverProcess.Kill();
            }
        }
    }
}
