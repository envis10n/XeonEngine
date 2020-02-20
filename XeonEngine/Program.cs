using System.Reflection;
using System.IO;
using XeonCore.Events;
using System;

namespace XeonEngine
{
    class Program
    {
        public static string AppDir = new FileInfo(Assembly.GetEntryAssembly().Location).Directory.ToString();
        static void Main(string[] args)
        {
            EventLoop Events = new EventLoop(60);
            Events.Enqueue(() =>
            {
                Console.WriteLine("Hello, Event Loop!");
            });
            Events.Join();
        }
    }
}
