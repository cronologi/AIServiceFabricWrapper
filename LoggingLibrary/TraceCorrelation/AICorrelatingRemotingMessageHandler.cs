using Microsoft.ServiceFabric.Services.Remoting.V1.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Services.Remoting.V1;
using System.Fabric;
using Microsoft.ServiceFabric.Services.Remoting;

namespace LoggingLibrary.TraceCorrelation
{
    public class AICorrelatingRemotingMessageHandler : IServiceRemotingMessageHandler, IDisposable
    {
        Microsoft.ApplicationInsights.ServiceFabric.Remoting.Activities.CorrelatingRemotingMessageHandler _aiCorrelatingRemotingMessageHandler;

        public AICorrelatingRemotingMessageHandler(ServiceContext serviceContext, IService service)
        {
            _aiCorrelatingRemotingMessageHandler = new Microsoft.ApplicationInsights.ServiceFabric.Remoting.Activities.CorrelatingRemotingMessageHandler(serviceContext, service);
        }
        public void Dispose()
        {
            _aiCorrelatingRemotingMessageHandler.Dispose();
        }

        public void HandleOneWay(IServiceRemotingRequestContext requestContext, ServiceRemotingMessageHeaders messageHeaders, byte[] requestBody)
        {
            _aiCorrelatingRemotingMessageHandler.HandleOneWay(requestContext, messageHeaders, requestBody);
        }

        public Task<byte[]> RequestResponseAsync(IServiceRemotingRequestContext requestContext, ServiceRemotingMessageHeaders messageHeaders, byte[] requestBody)
        {
            return _aiCorrelatingRemotingMessageHandler.RequestResponseAsync(requestContext, messageHeaders, requestBody);
        }
    }
}
