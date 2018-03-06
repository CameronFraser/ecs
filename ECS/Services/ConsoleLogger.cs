using System;
using System.Collections.Generic;

namespace ECS.Services
{
    class ConsoleLogger : ILogger
    {
        public List<string> LogBuffer { get; set; }

        public ConsoleLogger()
        {
            this.LogBuffer = new List<string>();
        }

        public void Log(string logEntry)
        {
            var logEntryWithTime = $"{DateTime.Now.ToString()}: {logEntry.ToString()}";
            LogBuffer.Add(logEntryWithTime);
            Console.WriteLine(logEntryWithTime);
        }

        public void DumpBuffer()
        {
            Console.WriteLine($"Console Log Buffer Dump: {string.Join(", ", this.LogBuffer)}");
        }
    }
}
