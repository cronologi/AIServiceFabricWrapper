using LoggingLibrary.Interfaces;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.ApplicationInsights.Extensibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingLibrary.Appenders
{
    public sealed class AppInsightsLogAppender : ILogAppender
    {
        TelemetryClient _telemetryClient; 
        private AppInsightsAppenderConfig _config;

        public AppInsightsLogAppender(AppInsightsAppenderConfig config)
        {
            _config = config;
            _telemetryClient = new TelemetryClient(TelemetryConfiguration.Active);
        }

        public void LogDebug(string message)
        {
            if (_config.IsEnabled && ToSeverityLevel(_config.Treshold) <= SeverityLevel.Verbose)
            {
                _telemetryClient.TrackTrace(new TraceTelemetry(message) { SeverityLevel = SeverityLevel.Verbose, Timestamp = DateTimeOffset.UtcNow });
            }
        }

        public void LogInformation(string message)
        {
            if (_config.IsEnabled && ToSeverityLevel(_config.Treshold) <= SeverityLevel.Information)
            {
                _telemetryClient.TrackTrace(new TraceTelemetry(message) { SeverityLevel = SeverityLevel.Information, Timestamp = DateTimeOffset.UtcNow });
            }
        }

        public void LogWarning(string message)
        {
            if (_config.IsEnabled && ToSeverityLevel(_config.Treshold) <= SeverityLevel.Warning)
            {
                _telemetryClient.TrackTrace(new TraceTelemetry(message) { SeverityLevel = SeverityLevel.Warning, Timestamp = DateTimeOffset.UtcNow });
            }
        }

        public void LogError(Exception exception, string message = null)
        {
            if (_config.IsEnabled && ToSeverityLevel(_config.Treshold) <= SeverityLevel.Error)
            {
                _telemetryClient.TrackException(new ExceptionTelemetry(exception) { SeverityLevel = SeverityLevel.Error, Timestamp = DateTimeOffset.UtcNow, Message = message ?? "" });
            }
        }

        public void LogError(string message)
        {
            if (_config.IsEnabled && ToSeverityLevel(_config.Treshold) <= SeverityLevel.Error)
            {
                _telemetryClient.TrackException(new ExceptionTelemetry(new Exception(message)) { SeverityLevel = SeverityLevel.Error, Timestamp = DateTimeOffset.UtcNow });
            }
        }

        public void LogCritical(Exception exception, string message = null)
        {
            if (_config.IsEnabled && ToSeverityLevel(_config.Treshold) <= SeverityLevel.Critical)
            {
                _telemetryClient.TrackException(new ExceptionTelemetry(exception) { SeverityLevel = SeverityLevel.Critical, Timestamp = DateTimeOffset.UtcNow, Message = message ?? "" });
            }
        }

        public void LogCritical(string message)
        {
            if (_config.IsEnabled && ToSeverityLevel(_config.Treshold) <= SeverityLevel.Critical)
            {
                _telemetryClient.TrackException(new ExceptionTelemetry(new Exception(message)) { SeverityLevel = SeverityLevel.Critical, Timestamp = DateTimeOffset.UtcNow });
            }
        }

        public void LogRequest(string nameOfRequest, DateTimeOffset startTime, TimeSpan duration, string responseCode, bool success)
        {
            if (_config.IsEnabled && ToSeverityLevel(_config.Treshold) <= SeverityLevel.Information)
            {
                _telemetryClient.TrackRequest(nameOfRequest, startTime, duration, responseCode, success);
            }
        }

        public void LogDependency(string dependencyTypeName, string target, string dependencyName, string data, DateTimeOffset startTime, TimeSpan duration, string resultCode, bool success)
        {
            if (_config.IsEnabled && ToSeverityLevel(_config.Treshold) <= SeverityLevel.Information)
            {
                _telemetryClient.TrackDependency(new DependencyTelemetry(dependencyTypeName, target, dependencyName, data, startTime, duration, resultCode, success));
            }
        }

        public OperationHolder LogStartOperation(string operationName)
        {
            OperationHolder operationHolder = new OperationHolder();

            if (_config.IsEnabled && ToSeverityLevel(_config.Treshold) <= SeverityLevel.Information)
            {
                operationHolder.CurrentOperation = _telemetryClient.StartOperation<RequestTelemetry>(operationName);
            }

            return operationHolder;
        }

        public void LogStopOperation(OperationContext operationHolder)
        {
            if (_config.IsEnabled && ToSeverityLevel(_config.Treshold) <= SeverityLevel.Information)
            {
                foreach (var item in operationHolder.Operations)
                {
                    if (item.CurrentOperation is IOperationHolder<RequestTelemetry> operationToken)
                    {
                        _telemetryClient.StopOperation<RequestTelemetry>(operationToken);
                    }
                }
            }
        }

        public static SeverityLevel ToSeverityLevel(int logLevel)
        {
            switch (logLevel)
            {
                case 0: // Verbose
                case 1: // Debug
                    return SeverityLevel.Verbose;
                case 2: // Information
                    return SeverityLevel.Information;
                case 3: // Warning
                    return SeverityLevel.Warning;
                case 4: // Error
                    return SeverityLevel.Error;
                case 5: // Critical
                    return SeverityLevel.Critical;
                default:
                    return SeverityLevel.Information;
            }
        }
    }
}
