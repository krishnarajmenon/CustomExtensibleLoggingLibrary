using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExtensibleLoggingLibrary;
using System.IO;
using ExtensibleLoggingLibrary.Enumerations;

namespace PlugInLogger
{
    public class SecondFileLogger : ILogger
    {
        #region ILogger Members

        public StreamWriter Writer
        {
            get;
            set;
        }

        public SecondFileLogger()
        {
            string logFileName = System.Configuration.ConfigurationSettings.AppSettings.Count > 0 ? 
                System.Configuration.ConfigurationSettings.AppSettings["LogFileName"] : "c:\\logs\\Testing.txt";
            Writer = new StreamWriter(logFileName);
            Writer.AutoFlush = true;
        }

        public void LogMessage(string message, DateTimeDisplayFormat dateTimeDisplayFormat)
        {
            Writer.Write(GetDateTimeString(dateTimeDisplayFormat) + ": " + message);
        }

        private string GetDateTimeString(DateTimeDisplayFormat dateTimeDisplayFormat)
        {
            switch (dateTimeDisplayFormat)
            {
                case DateTimeDisplayFormat.SimpleDateTimeFormat:
                    return DateTime.Now.ToString();

                case DateTimeDisplayFormat.CompleteDateTimeFormat:
                    return DateTime.Now.ToString();

                default:
                    return DateTime.Now.ToString("MM/dd/yy H:mm:ss zzz");
            }
        }

        #endregion
    }
}
