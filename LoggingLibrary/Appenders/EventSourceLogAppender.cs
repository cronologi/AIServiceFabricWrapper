using LoggingLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingLibrary.Appenders
{
    public sealed class EventSourceLogAppender : ILogAppender
    {
        private EventSourceAppenderConfig _config;

        public EventSourceLogAppender(EventSourceAppenderConfig config)
        {
            _config = config;
        }

        public void LogCritical(Exception exception, string message = null)
        {
            if (_config.IsEnabled)
            {
                
            }
        }

        public void LogCritical(string message)
        {
            if (_config.IsEnabled)
            {

            }
        }

        public void LogDebug(string message)
        {
            if (_config.IsEnabled)
            {

            }
        }

        public void LogDependency(string dependencyTypeName, string target, string dependencyName, string data, DateTimeOffset startTime, TimeSpan duration, string resultCode, bool success)
        {
            if (_config.IsEnabled)
            {

            }
        }

        public void LogError(Exception exception, string message = null)
        {
            if (_config.IsEnabled)
            {

            }
        }

        public void LogError(string message)
        {
            if (_config.IsEnabled)
            {

            }
        }

        public void LogInformation(string message)
        {
            if (_config.IsEnabled)
            {

            }
        }

        public void LogRequest(string nameOfRequest, DateTimeOffset startTime, TimeSpan duration, string responseCode, bool success)
        {
            if (_config.IsEnabled)
            {

            }
        }

        public OperationHolder LogStartOperation(string operationName)
        {
            if (_config.IsEnabled)
            {

            }
            var test =  new OperationHolder();
            test.CurrentOperation = new object();
            return test;
        }

        public void LogStopOperation(OperationContext operationHolder)
        {
            if (_config.IsEnabled)
            {

            }
        }

        public void LogWarning(string message)
        {
            if (_config.IsEnabled)
            {

            }
        }
    }
}
