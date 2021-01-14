using System;
using System.Management.Automation.Runspaces;
using System.Threading;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Integration
{
    public class PowerShellRunner
    {
        private static readonly string ProjectPath = FileHelper.Instance.GetProjectAssemblyPath();

        public static PowerShellRunner Instance => Singleton.Value;

        public void ExecutePowerShellScript(string powerShellFileName)
        {
            var runSpaceConfiguration = RunspaceConfiguration.Create();

            var runSpace = RunspaceFactory.CreateRunspace(runSpaceConfiguration);
            runSpace.Open();
            var pipeline = runSpace.CreatePipeline();
            var myCommand = new Command(ProjectPath + "/PowerShellScripts/" + powerShellFileName);
            pipeline.Commands.Add(myCommand);
            pipeline.Invoke();
            Thread.Sleep(TimeSpan.FromSeconds(10));
        }

        private PowerShellRunner() { }

        private static readonly Lazy<PowerShellRunner> Singleton = new Lazy<PowerShellRunner>(() => new PowerShellRunner());
    }
}
