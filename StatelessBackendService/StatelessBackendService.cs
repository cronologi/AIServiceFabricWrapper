using LoggingLibrary;
using LoggingLibrary.Appenders;
using LoggingLibrary.Interfaces;
using LoggingLibrary.TraceCorrelation;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Microsoft.ServiceFabric.Services.Remoting.Runtime;
using Microsoft.ServiceFabric.Services.Remoting.V1.FabricTransport.Runtime;
using Microsoft.ServiceFabric.Services.Runtime;
using RemotingInterfaces;
using System;
using System.Collections.Generic;
using System.Fabric;
using System.Threading;
using System.Threading.Tasks;

namespace StatelessBackendService
{
    /// <summary>
    /// An instance of this class is created for each service instance by the Service Fabric runtime.
    /// </summary>
    internal sealed class StatelessBackendService : StatelessService, IMyService
    {
        ITelemetryLogger logger;
        public StatelessBackendService(StatelessServiceContext context)
            : base(context)
        {
            logger = new TelemetryLogger(new List<ILogAppender>()
                {
                    new AppInsightsLogAppender(new AppInsightsAppenderConfig(), context),
                    new EventSourceLogAppender(new EventSourceAppenderConfig())
                });
            //FabricTelemetryInitializerExtension.SetServiceCallContext(this.Context);

        }

        public Task<string> HelloWorldAsync()
        {
            
            logger.LogDebug("Inside StatelessBackendService");
            return Task.FromResult<string>("Hello World");
        }

        /// <summary>
        /// Optional override to create listeners (e.g., TCP, HTTP) for this service replica to handle client or user requests.
        /// </summary>
        /// <returns>A collection of listeners.</returns>
        protected override IEnumerable<ServiceInstanceListener> CreateServiceInstanceListeners()
        {

            return new ServiceInstanceListener[1]
            {
                new ServiceInstanceListener(context => new FabricTransportServiceRemotingListener(context, new AICorrelatingRemotingMessageHandler(context, this)))
                //new ServiceInstanceListener(this.CreateServiceRemotingListener)
            };
        }

        /// <summary>
        /// This is the main entry point for your service instance.
        /// </summary>
        /// <param name="cancellationToken">Canceled when Service Fabric needs to shut down this service instance.</param>
        protected override async Task RunAsync(CancellationToken cancellationToken)
        {
            // TODO: Replace the following sample code with your own logic 
            //       or remove this RunAsync override if it's not needed in your service.

            long iterations = 0;

            while (true)
            {
                cancellationToken.ThrowIfCancellationRequested();

                await Task.Delay(TimeSpan.FromSeconds(1), cancellationToken);
            }
        }
    }
}
