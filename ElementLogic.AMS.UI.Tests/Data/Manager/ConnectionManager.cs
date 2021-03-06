﻿using System;
using System.Data.Common;
using System.Data.SqlClient;
using ElementLogic.AMS.UI.Tests.Integration;

namespace ElementLogic.AMS.UI.Tests.Data.Manager
{
    public class ConnectionManager
    {
        public static ConnectionManager Instance => Singleton.Value;

        public T ExecuteReturn<T>(Func<DbConnection, T> command)
        {
            var connection = GetConnection();
            try
            {
                connection.Open();
                var result = command(connection);
                return result;
            }
            finally
            {
                if (connection.State != System.Data.ConnectionState.Closed)
                    connection.Close();
            }
        }

        public void Execute(Action<DbConnection> command)
        {
            var connection = GetConnection();
            try
            {
                connection.Open();
                command(connection);
            }
            finally
            {
                if (connection.State != System.Data.ConnectionState.Closed)
                    connection.Close();
            }
        }

        public void ExecuteCreateDropDatabase(Action<DbConnection> command)
        {
            var connection = GetCreateDatabaseConnection();
            try
            {
                connection.Open();
                command(connection);
            }
            finally
            {
                if (connection.State != System.Data.ConnectionState.Closed)
                    connection.Close();
            }
        }

        private static DbConnection GetCreateDatabaseConnection()
        {
            var connectionString = JsonFileReader.Instance.GetJsonKeyValue("Configuration/Environment.json",
                "DatabaseSettings:connectionString");
            return CreateConnectionUsingConfigKey(connectionString);
        }

        private static DbConnection GetConnection()
        {
            var connectionString =
                new SqlConnectionStringBuilder(
                    JsonFileReader.Instance.GetJsonKeyValue("Configuration/Environment.json", 
                        "DatabaseSettings:connectionString"))
                {
                    InitialCatalog = JsonFileReader.Instance.GetJsonKeyValue("Configuration/Environment.json", 
                        "DatabaseSettings:DatabaseName")
        }.ConnectionString;

            return CreateConnectionUsingConfigKey(connectionString);
        }

        private static DbConnection CreateConnectionUsingConfigKey(string connectionString)
        {
            var providerName =
                JsonFileReader.Instance.GetJsonKeyValue("Configuration/Environment.json",
                    "DatabaseSettings:providerName");

            var provider = DbProviderFactories.GetFactory(providerName);
            var connection = provider.CreateConnection();
            if (connection != null)
                connection.ConnectionString = connectionString;
            return connection;
        }

        private ConnectionManager() { }

        private static readonly Lazy<ConnectionManager> Singleton =
            new Lazy<ConnectionManager>(() => new ConnectionManager());
    }
}
