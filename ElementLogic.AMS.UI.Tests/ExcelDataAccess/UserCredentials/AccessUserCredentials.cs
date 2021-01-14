using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using ElementLogic.AMS.UI.Tests.ExcelDataAccess.Manager;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.ExcelDataAccess.UserCredentials
{
    public class AccessUserCredentials
    {
        private const string FileName = "UserCredentials.xlsx";

        public static AccessUserCredentials Instance => Singleton.Value;

        public UserData GetUserCredentials(string userKey)
        {
            var usersDetails = AccessUserDetails();
            return usersDetails.FirstOrDefault(user => user.Key == userKey);
        }

        private static IEnumerable<UserData> AccessUserDetails()
        {
            var projectPath = FileHelper.Instance.GetProjectAssemblyPath();
            var fullExcelFilePath = Path.Combine(projectPath, $"ExcelDataAccess/UserCredentials/{FileName}");

            var dataTable = AccessManager.Instance.ImportExcelData(fullExcelFilePath);
            var userList = (from DataRow dataRow in dataTable.Rows
                select new UserData
                {
                    Key = dataRow["Key"].ToString(),
                    Username = dataRow["Username"].ToString(),
                    Password = dataRow["Password"].ToString()
                }).ToList();

            return userList;
        }

        private AccessUserCredentials() { }

        private static readonly Lazy<AccessUserCredentials> Singleton =
            new Lazy<AccessUserCredentials>(() => new AccessUserCredentials());

        public class UserData
        {
            public string Key { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
        }
    }
}
