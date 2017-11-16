using LoggingLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingLibrary.Appenders
{
    public sealed class EventSourceAppenderConfig : IAppenderConfig
    {
        public int Treshold => 1;
        public bool IsEnabled => true;
    }
}
