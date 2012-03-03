using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExtensibleLoggingLibrary;
using System.IO;

namespace PlugInLogger2
{
    public class ThirdLogger : ILogger
    {
        #region ILogger Members

        public void LogMessage(string message, ExtensibleLoggingLibrary.Enumerations.DateTimeDisplayFormat dateTimeDisplayFormat)
        {
            StreamWriter writer = new StreamWriter("c:\\logs\\Testing3.txt");
            writer.AutoFlush = true;
            writer.Write("This is again a nice third text message");
            writer.Close();
            writer.Dispose();
        }

        #endregion
    }
}
