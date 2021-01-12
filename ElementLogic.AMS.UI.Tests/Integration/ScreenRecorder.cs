using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.Expression.Encoder.ScreenCapture;
using SeleniumEssential;
using TechTalk.SpecFlow;

namespace ElementLogic.AMS.UI.Tests.Integration
{
    public class ScreenRecorder
    {
        private const string PathToVideos = "ScreenCaptureVideos\\";
        private static readonly ScreenCaptureJob VideoRecorder = new ScreenCaptureJob();

        public static ScreenRecorder Instance => Singleton.Value;

        public void StartScreenVideoRecording(ScenarioContext scenarioContext)
        {
            var nameOfTheScenario = scenarioContext.ScenarioInfo.Title;
            var videoName = string.Concat(nameOfTheScenario, ".wmv");
            var screenRecordingMainPath = Path
                .Combine(WebDriverHelper.Instance.GetProjectBinPath(), PathToVideos);
            var screenRecordingFullPath = Path.Combine(screenRecordingMainPath, videoName);
            VideoRecorder.CaptureRectangle = Screen.PrimaryScreen.Bounds;
            VideoRecorder.ShowFlashingBoundary = true;
            VideoRecorder.OutputScreenCaptureFileName = screenRecordingFullPath;
            var directory = new DirectoryInfo(screenRecordingMainPath);
            if (directory.Exists && File.Exists(screenRecordingFullPath))
            {
                File.Delete(screenRecordingFullPath);
            }

            if (!directory.Exists)
            {
                Directory.CreateDirectory(screenRecordingMainPath);
            }

            VideoRecorder.Start();
        }

        public void StopScreenVideoRecording(ScenarioContext scenarioContext)
        {
            var videoFileName = VideoRecorder.ScreenCaptureFileName;
            VideoRecorder.Stop();
            if (scenarioContext.TestError == null)
            {
                File.Delete(videoFileName);
            }
        }

        private ScreenRecorder() { }

        private static readonly Lazy<ScreenRecorder>
            Singleton = new Lazy<ScreenRecorder>(() => new ScreenRecorder());
    }
}
