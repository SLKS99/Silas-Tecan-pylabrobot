using System;
using System.Reflection;
using Tecan.Sila2.Server;

namespace SilaFluentServer
{
    class grpcProgram
    {
        static void Main(string[] args)
        {
    
        
            Bootstrapper.Start(args);
            Console.ReadLine();
        }
    }
}
