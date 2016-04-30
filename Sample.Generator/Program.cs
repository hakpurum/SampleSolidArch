using System;

namespace Sample.Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            var manager = new GenerationManager();
            manager.Generate();
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
