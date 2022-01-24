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

        public void StartScreenRecording(ScenarioContext scenarioContext)
        {
            var nameOfTheScenario = scenarioContext.ScenarioInfo.Title;
            var videoName = string.Concat(nameOfTheScenario, ".wmv");
            var screenRecordingMainPath = Path
                .Combine(FileHelper.GetProjectBinPath(), PathToVideos);
            var screenRecordingFullPath = Path.Combine(screenRecordingMainPath, videoName);
            VideoRecorder.CaptureRectangle = Screen.PrimaryScreen.Bounds;
            VideoRecorder.ShowFlashingBoundary = true;
            VideoRecorder.OutputScreenCaptureFileName = screenRecordingFullPath;
            CreateScreenRecordingDirectory(screenRecordingMainPath);
            VideoRecorder.Start();
        }

        public void StopScreenRecording(ScenarioContext scenarioContext)
        {
            var videoFileName = VideoRecorder.ScreenCaptureFileName;
            VideoRecorder.Stop();
            if (scenarioContext.TestError == null)
            {
                File.Delete(videoFileName);
            }
        }

        private static void CreateScreenRecordingDirectory(string directoryPath)
        {
            var directory = new DirectoryInfo(directoryPath);
            if (!directory.Exists)
            {
                Directory.CreateDirectory(directoryPath);
            }
        }

        private ScreenRecorder() { }

        private static readonly Lazy<ScreenRecorder>
            Singleton = new Lazy<ScreenRecorder>(() => new ScreenRecorder());
    }
}
