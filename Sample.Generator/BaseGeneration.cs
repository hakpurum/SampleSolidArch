using System;
using System.IO;
using Sample.Generator.Helper;

namespace Sample.Generator
{
    public abstract class BaseGeneration
    {
        public string TemplateFolder => Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\"));

        public static void CreateFile(string fileName, string text)
        {
            if (File.Exists(fileName)) return;
            using (var writer = new StreamWriter(fileName))
            {
                writer.Write(text);
            }
        }

        public static string GetApp(string keyName)
        {
            return AppHelper.GetApp(keyName);
        }

        public static string[] GetTables()
        {
            return AppHelper.GetTables();
        }
    }
}
