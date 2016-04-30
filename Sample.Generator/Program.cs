using System;
using System.Data.SqlClient;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;

namespace Sample.Generator
{
    class Program
    {
        static void Main(string[] args)
        {

            var sqlConnection = new SqlConnection(@"Data Source=SZCN\SQLEXPRESS;Initial Catalog=Sample;Integrated Security=True;");
            var serverConnection = new ServerConnection(sqlConnection);
            var server = new Server(serverConnection);
            var tables = server.Databases[server.ConnectionContext.DatabaseName].Tables;
            foreach (Table table in tables)
            {
                foreach (Column column in table.Columns)
                {
                    
                }
            }

            var manager = new GenerationManager();
            manager.Generate();
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
