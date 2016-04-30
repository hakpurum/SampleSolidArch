using System;
using System.Linq;
using Microsoft.SqlServer.Management.Smo;
using Sample.Generator.Helper;
using Sample.Generator.Template;

namespace Sample.Generator
{
    public class BusinessGeneration : BaseGeneration, IGeneration
    {
        private readonly string _generatePath = GetApp("BusinessGenerateFilePath");

        public void Generate()
        {
            var tables = GetTables();
            foreach (var tableName in from Table table in tables select table.Name.ReplaceWith())
            {
                GenerateInterfaces(tableName);
                GenerateManager(tableName);
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

        private void GenerateInterfaces(string className)
        {
            var fileName = _generatePath + "Interfaces/I" + className + "Service.cs";
            var t1 = new BusinessInterfaceTemplate()
            {
                Model = new BusinessTemplateModel() { ClassName = className }
            };

            CreateFile(fileName, t1.TransformText());
        }

        private void GenerateManager(string className)
        {
            var fileName = _generatePath + "Concrete/" + className + "Manager.cs";
            var t1 = new BusinessManagerTemplate
            {
                Model = new BusinessManagerTemplateModel() { ClassName = className }
            };

            CreateFile(fileName, t1.TransformText());
        }
    }
}
