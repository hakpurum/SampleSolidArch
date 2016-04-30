using System;
using Sample.Generator.Helper;

namespace Sample.Generator
{
    public class GenerationManager
    {
        readonly IGeneration _generation;
        public GenerationManager()
        {
            Console.WriteLine("Generate etmek istediğiniz katman ?");
            Console.WriteLine(@"D => DataLayer
E => Entities 
B => Business");
            var layerVal = Console.ReadLine();
            var generateLayer = (string.IsNullOrEmpty(layerVal) ? AppHelper.GetApp("GenerateLayer") : layerVal).ToUpper();

            switch (generateLayer)
            {
                case "B":
                    _generation = new BusinessGeneration();
                    break;
                case "D":
                    _generation = new DataLayerGeneration();
                    break;
                case "E":
                    _generation = new EntitiesGeneration();
                    break;
                default:
                    break;
            }
        }

        public void Generate()
        {
            _generation.Generate();
        }
    }
}
