using Npgsql;
using System;
using Dapper;


namespace Test;


   public class ContextConfig
    {
        public static readonly NpgsqlDataSource DataSource;
        public static readonly string ClientAppBaseUrl = "http://localhost:5000";
        public static readonly string ApiBaseUrl = "http://localhost:5000/api";

        static ContextConfig()
        {
            var envVarKeyName = "pgconn";

            var rawConnectionString = Environment.GetEnvironmentVariable(envVarKeyName);
            if (string.IsNullOrEmpty(rawConnectionString))
            {
                throw new Exception("Environment variable 'pgconn' is not set.");
            }

            try
            {
                var uri = new Uri(rawConnectionString);
                var properlyFormattedConnectionString = new NpgsqlConnectionStringBuilder
                {
                    Host = uri.Host,
                    Database = uri.AbsolutePath.Trim('/'),
                    Username = uri.UserInfo.Split(':')[0],
                    Password = uri.UserInfo.Split(':')[1],
                    Port = uri.Port > 0 ? uri.Port : 5432,
                    Pooling = false
                }.ToString();

                DataSource = new NpgsqlDataSourceBuilder(properlyFormattedConnectionString).Build();
                DataSource.OpenConnection().Close();
            }
            catch (Exception e)
            {
                throw new Exception("There is a problem with the pgconn connection string.", e);
            }
        }

        public static void TriggerRebuild()
        {
            using (var conn = DataSource.OpenConnection())
            {
                try
                {
                    conn.Execute(RebuildScript);
                }
                catch (Exception e)
                {
                    throw new Exception("There was a problem rebuilding the database. Please check your PostgreSQL setup.", e);
                }
            }
        }

        public static string RebuildScript = @"
DROP SCHEMA IF EXISTS test_schema CASCADE;
CREATE SCHEMA test_schema;
create table if not exists test_schema.boxes
(
    id serial PRIMARY KEY,
    name text,
    date_of_creation date,
    category text
);
";
    }

