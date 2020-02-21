using System.Reflection;
using System.IO;

namespace XeonEngine
{
    class Program
    {
        public static string AppDir = new FileInfo(Assembly.GetEntryAssembly().Location).Directory.ToString();
        static void Main(string[] args)
        {
            Storage.Init();
        }
    }
}
