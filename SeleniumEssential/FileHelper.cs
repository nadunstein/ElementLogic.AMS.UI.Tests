using System.IO;
using System.Reflection;

namespace SeleniumEssential
{
    public class FileHelper
    {
        public static string GetProjectPath()
        {
            var projectPath = Directory
                .GetParent(Directory.GetParent(Directory
                    .GetParent(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
                    .ToString()).ToString()).ToString();

            return projectPath;
        }

        public static string GetProjectBinPath()
        {
            return Directory.GetParent(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)).ToString();
        }

        public static string GetProjectAssemblyPath()
        {
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }

        public static void DeleteFiles(string pathToDirectory)
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
    }
}
