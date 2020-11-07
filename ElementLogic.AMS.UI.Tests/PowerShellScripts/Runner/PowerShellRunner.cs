using System;
using System.Management.Automation.Runspaces;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.PowerShellScripts.Runner
{
    public class PowerShellRunner
    {
        private static readonly string ProjectPath = WebDriverHelper.Instance.GetProjectAssemblyPath();

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
        }

        private PowerShellRunner() { }

        private static readonly Lazy<PowerShellRunner> Singleton = new Lazy<PowerShellRunner>(() => new PowerShellRunner());
    }
}
