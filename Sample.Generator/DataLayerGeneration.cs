using System;
using Sample.Generator.Template;

namespace Sample.Generator
{
    public class DataLayerGeneration : BaseGeneration, IGeneration
    {
        private readonly string _generatePath = GetApp("DataLayerGenerateFilePath");

        public void Generate()
        {
            var tables = GetTables();

            for (int i = 0; i < tables.Length; i++)
            {
                GenerateInterfaces(tables[i]);
                GenerateEfDal(tables[i]);
            }

            #region Summary
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("Generated : DataLayerGeneration");
            Console.WriteLine("Generated Folder :" + _generatePath);
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
