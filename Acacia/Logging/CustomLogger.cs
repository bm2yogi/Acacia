using System;
using System.IO;
using System.Threading;

namespace Acacia.Logging
{
    public class CustomLogger : ILogger
    {
        public CustomLogger()
        {
            LogInfo("Custom Logger Instantiated");
        }

        public static void LogInfo(string message)
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logfile.txt");
            var text = string.Format("{0:u} | {1} | ThreadId: {2}\n", 
                DateTime.Now, 
                message, 
                Thread.CurrentThread.ManagedThreadId);
            
            File.AppendAllText(path, text);
        }

        void ILogger.LogInfo(string message)
        {
            LogInfo(message);
        }
    }
}