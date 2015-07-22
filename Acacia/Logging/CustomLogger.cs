using System;

namespace Acacia.Logging
{
    public class CustomLogger : ILogger
    {
        public CustomLogger()
        {
            Console.WriteLine("{0} | Custom Logger Instantiated", DateTime.Now);    
        }

        public void LogInfo(string message)
        {
            Console.WriteLine("{0} | {1}", DateTime.Now, message);
        }
    }
}