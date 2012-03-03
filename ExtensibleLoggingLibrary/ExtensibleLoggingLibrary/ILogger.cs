using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExtensibleLoggingLibrary.Enumerations;

namespace ExtensibleLoggingLibrary
{
    public interface ILogger
    {
        void LogMessage(string message, DateTimeDisplayFormat dateTimeDisplayFormat);
    }
}
