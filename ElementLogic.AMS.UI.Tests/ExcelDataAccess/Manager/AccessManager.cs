using System;
using System.Data;
using System.IO;
using ExcelDataReader;

namespace ElementLogic.AMS.UI.Tests.ExcelDataAccess.Manager
{
    public class AccessManager
    {
        public static AccessManager Instance => Singleton.Value;

        public DataTable ImportExcelData(string filePath)
        {
            using var stream = File.Open(filePath, FileMode.Open, FileAccess.Read);
            using var reader = ExcelReaderFactory.CreateReader(stream);
            var config = new ExcelDataSetConfiguration
            {
                ConfigureDataTable = _ => new ExcelDataTableConfiguration
                {
                    UseHeaderRow = true
                }
            };

            var dataSet = reader.AsDataSet(config);
            var dataTable = dataSet.Tables[0];
            return dataTable;
        }

        private AccessManager() { }

        private static readonly Lazy<AccessManager> Singleton = new Lazy<AccessManager>(() => new AccessManager());
    }
}
