using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Dapper;
using System.Data.SqlClient;
using System.Data;

namespace MFileCL.DA
{
    internal static class MFDA
    {
        public static IConfiguration GetConfiguration()
        {
            var builder = new Microsoft.Extensions.Configuration.ConfigurationBuilder()
            .SetBasePath(System.AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables();

            return builder.Build();
        }


        public static string GetConnectionString(string connectionName = "ConnectionString")
        {
            var connstr = GetConfiguration().GetConnectionString("ConnectionString").ToString();

            return connstr;

        }


        public static List<T> LoadData<T>(string sql)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Query<T>(sql).ToList();
            }
        }

        public static int SaveData<T>(string sql, T data)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Execute(sql, data);
            }
        }

    }
}
