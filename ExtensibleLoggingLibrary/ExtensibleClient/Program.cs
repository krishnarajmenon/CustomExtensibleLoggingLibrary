using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExtensibleLoggingLibrary;
using System.IO;
using System.Reflection;

namespace ExtensibleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            LoggingManager.Log("This is a test message");
            //List<Assembly> assemblyList = new List<Assembly>();
            //foreach (string str in Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll"))
            //{
            //    string file = str.Remove(0, str.LastIndexOf("\\") + 1);
            //    file = file.Remove(file.IndexOf("."));
            //    Assembly assembly = Assembly.Load(file);
            //    assemblyList.Add(assembly);
            //}

            //Type[] typeList = assemblyList[0].GetTypes();
            //Console.WriteLine(typeList[0].ToString());
            
            //Console.Write(Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll"));
        }
    }
}
