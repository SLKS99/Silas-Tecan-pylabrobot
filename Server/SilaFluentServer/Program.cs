using System;
using System.Reflection;
using Tecan.Sila2.Server;

namespace Tecan.VisionX.Sila2
{
    class Program
    {
        static void Main(string[] args)
        {
    
        
            Bootstrapper.Start(args);
            Console.ReadLine();
        }
    }
}
