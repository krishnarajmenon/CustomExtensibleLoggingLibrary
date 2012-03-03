using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using ExtensibleLoggingLibrary.Enumerations;

namespace ExtensibleLoggingLibrary
{
    class FileLogger : ILogger
    {
        #region ILogger Members

        public StreamWriter Writer
        {
            get;
            set;
        }

        public FileLogger()
        {
            //LoggingManager.AddLogger(this);
            string logFileName = System.Configuration.ConfigurationSettings.AppSettings.Count > 0 ? 
                System.Configuration.ConfigurationSettings.AppSettings["LogFileName"] : "c:\\logs\\Test.txt";
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
