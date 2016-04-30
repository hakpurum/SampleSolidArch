using System;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using Sample.Generator.Helper;

namespace Sample.Generator
{
    public abstract class BaseGeneration
    {
        public string TemplateFolder => Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\"));

        public static StringBuilder GeneratedFiles = new StringBuilder();

        public static void CreateFile(string fileName, string text)
        {
            if (File.Exists(fileName)) return;
            using (var writer = new StreamWriter(fileName))
            {
                writer.Write(text);
                GeneratedFiles.AppendLine(fileName);
            }
        }

        public static string GetApp(string keyName)
        {
            return AppHelper.GetApp(keyName);
        }

        public static TableCollection GetTables()
        {
            var appSqlConnectionString = GetApp("DbConnection");
            var sqlConnection = new SqlConnection(appSqlConnectionString);
            var serverConnection = new ServerConnection(sqlConnection);
            var server = new Server(serverConnection);
            var tables = server.Databases[server.ConnectionContext.DatabaseName].Tables;

            return tables;
        }
    }
}
