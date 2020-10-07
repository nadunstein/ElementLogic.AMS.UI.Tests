using System;
using System.Diagnostics;
using System.ServiceProcess;
using ElementLogic.AMS.UI.Tests.Configuration;

namespace ElementLogic.AMS.UI.Tests.Integration
{
    public class WindowsServices
    {
        public static WindowsServices Instance => Singleton.Value;

        public void DoIisReset()
        {
            var iisRestart = new Process
            {
                StartInfo =
                {
                    FileName = "iisreset.exe",
                    Arguments = ConfigFileReader.Instance.ConfigurationKeyValue("Application:context")
                }
            };

            iisRestart.Start();
            iisRestart.WaitForExit();

            var sc = new ServiceController("World Wide Web Publishing Service");
            if (!sc.Status.Equals(ServiceControllerStatus.Stopped) && 
                !sc.Status.Equals(ServiceControllerStatus.StopPending))
            {
                return;
            }

            sc.Start();
        }

        public void RestartAutostoreEmulatorService()
        {
            var autostoreEmulatorService = new ServiceController("ASInterfaceEmulator");

            autostoreEmulatorService.Stop();
            autostoreEmulatorService.WaitForStatus(ServiceControllerStatus.Stopped);
            autostoreEmulatorService.Start();
            autostoreEmulatorService.WaitForStatus(ServiceControllerStatus.Running);
        }

        private WindowsServices() { }

        private static readonly Lazy<WindowsServices>
            Singleton = new Lazy<WindowsServices>(() => new WindowsServices());
    }
}
