using System;
using Sample.Generator.Template;

namespace Sample.Generator
{
    public class EntitiesGeneration : BaseGeneration, IGeneration
    {
        private readonly string _generatePath = GetApp("EntitiesGenerateFilePath");
        public void Generate()
        {
            var tables = GetTables();

            for (int i = 0; i < tables.Length; i++)
            {
                var fileName = _generatePath + "Concrete/" + tables[i] + ".cs";
                var t1 = new EntitiesTemplate
                {
                    Model = new EntitiesTemplateModel { ClassName = tables[i] }
                };

                CreateFile(fileName, t1.TransformText());
            }

            #region Summary
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("Generated : EntitiesGeneration");
            Console.WriteLine("Generated Folder :" + _generatePath);
            Console.WriteLine("Generated : Completed");
            Console.WriteLine("------------------------------------------------------------");
            #endregion

        }
    }
}
