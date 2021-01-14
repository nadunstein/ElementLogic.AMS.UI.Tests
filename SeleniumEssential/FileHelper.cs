using System;
using System.IO;
using System.Reflection;

namespace SeleniumEssential
{
    public class FileHelper
    {
        public static FileHelper Instance => Singleton.Value;

        public string GetProjectPath()
        {
            var projectPath = Directory
                .GetParent(Directory.GetParent(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
                    .ToString()).ToString();

            return projectPath;
        }

        public string GetProjectBinPath()
        {
            return Directory.GetParent(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
                .ToString();
        }

        public string GetProjectAssemblyPath()
        {
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }

        public void DeleteFiles(string pathToDirectory)
        {
            var directory = new DirectoryInfo(pathToDirectory);

            if (!directory.Exists)
            {
                return;
            }

            foreach (var file in directory.GetFiles())
            {
                file.Delete();
            }
        }

        private FileHelper() { }

        private static readonly Lazy<FileHelper> Singleton =
            new Lazy<FileHelper>(() => new FileHelper());
    }
}
