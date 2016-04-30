using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Sample.Generator.Template;
using Microsoft.SqlServer.Management.Smo;
using Sample.Generator.Helper;

namespace Sample.Generator
{
    public class EntitiesGeneration : BaseGeneration, IGeneration
    {
        private readonly string _generatePath = GetApp("EntitiesGenerateFilePath");
        public void Generate()
        {
            var tables = GetTables();
            foreach (Table table in tables)
            {
                var tableName = table.Name.ReplaceWith();
                var fileName = _generatePath + "Concrete/" + tableName + ".cs";
                var t1 = new EntitiesTemplate
                {
                    Model = new EntitiesTemplateModel { ClassName = tableName, Columns = table.Columns.ToProperties() }
                };

                CreateFile(fileName, t1.TransformText());
            }

            #region Summary
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("Generated : EntitiesGeneration");
            Console.WriteLine("Generated Folder :" + _generatePath);
            Console.WriteLine("Generated Files :" + GeneratedFiles);
            Console.WriteLine("Generated : Completed");
            Console.WriteLine("------------------------------------------------------------");
            #endregion

        }
    }
}
