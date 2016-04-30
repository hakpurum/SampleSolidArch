using System;
using System.Linq;
using Microsoft.SqlServer.Management.Smo;
using Sample.Generator.Helper;
using Sample.Generator.Template;

namespace Sample.Generator
{
    public class DataLayerGeneration : BaseGeneration, IGeneration
    {
        private readonly string _generatePath = GetApp("DataLayerGenerateFilePath");

        public void Generate()
        {
            var tables = GetTables();
            foreach (var tableName in from Table table in tables select table.Name.ReplaceWith())
            {
                GenerateInterfaces(tableName);
                GenerateEfDal(tableName);
            }


            #region Summary
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("Generated : EntitiesGeneration");
            Console.WriteLine("Generated Folder :" + _generatePath);
            Console.WriteLine("Generated Files : /n " + GeneratedFiles);
            Console.WriteLine("Generated : Completed");
            Console.WriteLine("------------------------------------------------------------");
            #endregion

        }

        private void GenerateInterfaces(string className)
        {
            var fileName = _generatePath + "Interfaces/I" + className + "Dal.cs";
            var t1 = new DataLayerInterfaceTemplate
            {
                Model = new DataLayerInterfaceTemplateModel() { ClassName = className }
            };

            CreateFile(fileName, t1.TransformText());
        }

        private void GenerateEfDal(string className)
        {
            var fileName = _generatePath + "Concrete/EntityFramework/Ef" + className + "Dal.cs";
            var t1 = new DataLayerEfTemplate
            {
                Model = new DataLayerEfTemplateModel() { ClassName = className }
            };

            CreateFile(fileName, t1.TransformText());
        }
    }
}
