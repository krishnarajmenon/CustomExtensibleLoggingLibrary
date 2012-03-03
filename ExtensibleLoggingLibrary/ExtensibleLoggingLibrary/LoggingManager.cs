using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;

namespace ExtensibleLoggingLibrary
{
    public static class LoggingManager
    {
        static LoggingManager()
        {
            string fileName = string.Empty;

            TypeList = new List<Type>();
            List<Assembly> assemblyList = new List<Assembly>();

            string[] allLibrariesInAppFolder = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll");
            allLibrariesInAppFolder = allLibrariesInAppFolder.Where(item => !item.Contains("ExtensibleLoggingLibrary.dll")).ToArray();

            foreach (string dllFile in allLibrariesInAppFolder)
            {
                fileName = dllFile.Remove(0, dllFile.LastIndexOf("\\") + 1);
                fileName = fileName.Remove(fileName.IndexOf("."));
                Assembly assembly = Assembly.Load(fileName);

                var results = from type in assembly.GetTypes()
                              where typeof(ILogger).IsAssignableFrom(type)
                              select type;

                TypeList.AddRange(results.ToList());
            }

            TypeList.Add(typeof(FileLogger));
        }

        public static List<Type> TypeList { get; set; }

        public static void Log(string message)
        {
            foreach (Type type in TypeList)
            {
                (Activator.CreateInstance(type) as ILogger).LogMessage(message, 
                    ExtensibleLoggingLibrary.Enumerations.DateTimeDisplayFormat.SimpleDateTimeFormat);
            }
        }
    }
}
