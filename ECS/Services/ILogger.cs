using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS.Services
{
    interface ILogger
    {
        List<string> LogBuffer { get; set; }
        void Log(string logEntry);
    }
}
