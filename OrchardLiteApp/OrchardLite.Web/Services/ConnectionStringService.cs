using System;
using Microsoft.Extensions.Configuration;

namespace OrchardLite.Web.Services
{
    public interface IConnectionStringService
    {
        string GetConnectionString(bool includeDatabase = true);
    }

    public class ConnectionStringService : IConnectionStringService
    {
        private readonly IConfiguration _configuration;

        public ConnectionStringService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnectionString(bool includeDatabase = true)
        {
            var connStr = _configuration.GetConnectionString("OrchardLiteDB") ?? string.Empty;

            connStr = connStr
                .Replace("${DB_HOST}", Environment.GetEnvironmentVariable("DB_HOST") ?? "localhost")
                .Replace("${DB_PORT}", Environment.GetEnvironmentVariable("DB_PORT") ?? "3306")
                .Replace("${DB_NAME}", includeDatabase ? (Environment.GetEnvironmentVariable("DB_NAME") ?? "OrchardLiteDB") : "")
                .Replace("${DB_USER}", Environment.GetEnvironmentVariable("DB_USER") ?? "root")
                .Replace("${DB_PASSWORD}", Environment.GetEnvironmentVariable("DB_PASSWORD") ?? "password");

            if (!includeDatabase)
            {
                connStr = connStr.Replace("Database=;", "");
            }

            return connStr;
        }
    }
}
