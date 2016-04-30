using System;
using Sample.Generator.Template;

namespace Sample.Generator
{
    public class BusinessGeneration : BaseGeneration, IGeneration
    {
        private readonly string _generatePath = GetApp("BusinessGenerateFilePath");

        public void Generate()
        {
            var tables = GetTables();

            for (int i = 0; i < tables.Length; i++)
            {
                GenerateInterfaces(tables[i]);
                GenerateManager(tables[i]);
            }

            #region Summary
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("Generated : BusinessGeneration");
            Console.WriteLine("Generated Folder :" + _generatePath);
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
