using System;
using System.Collections.Generic;
using System.Fabric;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.ServiceFabric.Services.Communication.AspNetCore;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Microsoft.ServiceFabric.Services.Runtime;
using LoggingLibrary;
using LoggingLibrary.Interfaces;
using LoggingLibrary.Appenders;

namespace WebStateless
{
    /// <summary>
    /// The FabricRuntime creates an instance of this class for each service type instance. 
    /// </summary>
    internal sealed class WebStateless : StatelessService
    {
        //ITelemetryLogger logger;

        public WebStateless(StatelessServiceContext context)
            : base(context)
        {
            //logger = new TelemetryLogger(new List<ILogAppender>()
            //    {
            //        new AppInsightsLogAppender(new AppInsightsAppenderConfig()),
            //        new EventSourceLogAppender(new EventSourceAppenderConfig())
            //    });
        }

        /// <summary>
        /// Optional override to create listeners (like tcp, http) for this service instance.
        /// </summary>
        /// <returns>The collection of listeners.</returns>
        protected override IEnumerable<ServiceInstanceListener> CreateServiceInstanceListeners()
        {
            FabricTelemetryInitializerExtension.SetServiceCallContext(this.Context);

            return new ServiceInstanceListener[]
            {
                new ServiceInstanceListener(serviceContext =>
                    new KestrelCommunicationListener(serviceContext, "ServiceEndpoint", (url, listener) =>
                    {
                        //ServiceEventSource.Current.ServiceMessage(serviceContext, $"Starting Kestrel on {url}");

                        return new WebHostBuilder()
                                    .UseKestrel()
                                    .ConfigureServices(
                                        services => services
                                            .AddSingleton<StatelessServiceContext>(serviceContext)
                                            .AddSingleton<IAppenderConfig, AppInsightsAppenderConfig>()
                                            .AddSingleton<IAppenderConfig, EventSourceAppenderConfig>()
                                            .AddSingleton<ILogAppender, AppInsightsLogAppender>()
                                            .AddSingleton<ILogAppender, EventSourceLogAppender>()
                                            .AddSingleton<ITelemetryLogger, TelemetryLogger>()
                                            )
                                    .UseContentRoot(Directory.GetCurrentDirectory())
                                    .UseStartup<Startup>()
                                    .UseServiceFabricIntegration(listener, ServiceFabricIntegrationOptions.None)
                                    .UseUrls(url)
                                    .Build();
                    }))
            };
        }
    }
}
