﻿using System;
using System.IO;
using Dapper;
using ElementLogic.AMS.UI.Tests.Data.Manager;
using ElementLogic.AMS.UI.Tests.Integration;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Data.DatabaseQueries
{
    public class Database
    {
        public static Database Instance => Singleton.Value;

        public void CreateDatabase(string nameOfTheDatabase)
        {
            var mainSql = $"create database {nameOfTheDatabase}";
            ConnectionManager.Instance.ExecuteCreateDropDatabase(connection => connection.Execute(mainSql));
        }

        public void DeleteDatabase(string nameOfTheDatabase)
        {
            var mainSql = "USE MASTER " +
                               $"IF EXISTS(SELECT * FROM SYS.DATABASES WHERE NAME = '{nameOfTheDatabase}') " +
                               $"ALTER DATABASE {nameOfTheDatabase} SET SINGLE_USER WITH ROLLBACK IMMEDIATE " +
                               $"DROP DATABASE IF EXISTS {nameOfTheDatabase}";
            ConnectionManager.Instance.ExecuteCreateDropDatabase(connection => connection.Execute(mainSql));
        }

        public void RestoreDatabase(string nameOfTheDatabase)
        {
            var copyDatabaseFileTo = JsonFileReader.Instance.GetJsonKeyValue("Configuration/Environment.json", "DatabaseSettings:CopyDatabaseFileTo");
            if (!string.IsNullOrEmpty(copyDatabaseFileTo))
            {
                var originalLocation = Path.Combine(FileHelper.Instance.GetProjectAssemblyPath(), "Database\\", string.Concat(nameOfTheDatabase, ".bak"));
                var newLocation = Path.Combine(copyDatabaseFileTo, string.Concat(nameOfTheDatabase, ".bak"));
                File.Copy(originalLocation, newLocation, true);
            }
            
            var databasePath = JsonFileReader.Instance.GetJsonKeyValue("Configuration/Environment.json", "DatabaseSettings:DatabasePath");
            databasePath = string.IsNullOrEmpty(databasePath) 
                ? Path.Combine(FileHelper.Instance.GetProjectAssemblyPath(), "Database\\", string.Concat(nameOfTheDatabase, ".bak"))
                : string.Concat(databasePath, nameOfTheDatabase, ".bak");

            var dataLogFilePath = JsonFileReader.Instance.GetJsonKeyValue("Configuration/Environment.json",
                "DatabaseSettings:DatabaseDataLogFilePath");
            var dataFilePath =
                Path.Combine(dataLogFilePath, string.Concat(nameOfTheDatabase, ".mdf"));
            var dataLogePath =
                Path.Combine(dataLogFilePath, string.Concat(nameOfTheDatabase, "_log.ldf"));

            var mainSql = "USE MASTER " +
                               $"RESTORE DATABASE {nameOfTheDatabase} FROM DISK = '{databasePath}' " +
                                "WITH " +
                               $"MOVE '{nameOfTheDatabase}' TO '{dataFilePath}'," +
                               $"MOVE '{nameOfTheDatabase + "_log"}' TO '{dataLogePath}'";
            ConnectionManager.Instance.ExecuteCreateDropDatabase(connection => connection.Execute(mainSql));
        }

        private Database() { }

        private static readonly Lazy<Database> Singleton = new Lazy<Database>(() => new Database());
    }
}
