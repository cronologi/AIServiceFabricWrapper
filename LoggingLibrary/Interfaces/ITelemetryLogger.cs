using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingLibrary.Interfaces
{
    public interface ITelemetryLogger
    {
        void LogDependency(string dependencyTypeName, string target, string dependencyName, string data, DateTimeOffset startTime, TimeSpan duration, string resultCode, bool success);

        void LogRequest(string nameOfRequest, DateTimeOffset startTime, TimeSpan duration, string responseCode, bool success);

        void LogInformation(string message);

        void LogDebug(string message);

        void LogCritical(Exception exception, string message = null);

        void LogCritical(string message);

        void LogWarning(string message);

        void LogError(Exception exception, string message = null);

        void LogError(string message);

        OperationContext LogStartOperation(string operationName);

        void LogStopOperation(OperationContext operationHolder);
    }
}
