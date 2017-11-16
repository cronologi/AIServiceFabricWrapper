using LoggingLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Fabric;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingLibrary
{
    public sealed class TelemetryLogger : ITelemetryLogger
    {
        private List<ILogAppender> _appenders;
        private ServiceContext _serviceContext;

        public TelemetryLogger(IEnumerable<ILogAppender> appenders)
        {
            _appenders = appenders.ToList();
        }

        public void LogDebug(string message)
        {
            foreach (ILogAppender appender in _appenders)
            {
                appender.LogDebug(message);
            }
        }

        public void LogDependency(string dependencyTypeName, string target, string dependencyName, string data, DateTimeOffset startTime, TimeSpan duration, string resultCode, bool success)
        {
            foreach (ILogAppender appender in _appenders)
            {
                appender.LogDependency(dependencyTypeName, target, dependencyName, data, startTime, duration, resultCode, success);
            }
        }

        public void LogError(string message)
        {
            foreach (ILogAppender appender in _appenders)
            {
                appender.LogError(message);
            }
        }

        public void LogError(Exception ex, string message = null)
        {
            foreach (ILogAppender appender in _appenders)
            {
                appender.LogError(ex, message);
            }
        }

        public void LogCritical(string message)
        {
            foreach (ILogAppender appender in _appenders)
            {
                appender.LogCritical(message);
            }
        }

        public void LogCritical(Exception ex, string message = null)
        {
            foreach (ILogAppender appender in _appenders)
            {
                appender.LogCritical(ex, message);
            }
        }

        public void LogInformation(string message)
        {
            foreach (ILogAppender appender in _appenders)
            {
                appender.LogInformation(message);
            }
        }

        public void LogRequest(string nameOfRequest, DateTimeOffset startTime, TimeSpan duration, string responseCode, bool success)
        {
            foreach (ILogAppender appender in _appenders)
            {
                appender.LogRequest(nameOfRequest, startTime, duration, responseCode, success);
            }
        }

        public OperationContext LogStartOperation(string operationName)
        {
            OperationContext operationHolder = new OperationContext();

            foreach (ILogAppender appender in _appenders)
            {
                operationHolder.Operations.Add(appender.LogStartOperation(operationName));
            }

            return operationHolder;
        }

        public void LogStopOperation(OperationContext operationHolder)
        {
            foreach (ILogAppender appender in _appenders)
            {
                appender.LogStopOperation(operationHolder);
            }
        }

        public void LogWarning(string message)
        {
            foreach (ILogAppender appender in _appenders)
            {
                appender.LogWarning(message);
            }
        }
    }
}
