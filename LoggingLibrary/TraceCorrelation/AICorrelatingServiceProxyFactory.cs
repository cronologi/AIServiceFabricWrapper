using Microsoft.ServiceFabric.Services.Communication.Client;
using Microsoft.ServiceFabric.Services.Remoting.Client;
using Microsoft.ServiceFabric.Services.Remoting.V1;
using Microsoft.ServiceFabric.Services.Remoting.V1.Client;
using System;
using System.Collections.Generic;
using System.Fabric;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Services.Client;
using Microsoft.ServiceFabric.Services.Remoting;

namespace LoggingLibrary.TraceCorrelation
{
    public class AICorrelatingServiceProxyFactory : IServiceProxyFactory
    {
        Microsoft.ApplicationInsights.ServiceFabric.Remoting.Activities.CorrelatingServiceProxyFactory _aiCorrelatingServiceProxyFactory;

        public AICorrelatingServiceProxyFactory(ServiceContext serviceContext, Func<IServiceRemotingCallbackClient, IServiceRemotingClientFactory> createServiceRemotingClientFactory = null, OperationRetrySettings retrySettings = null)
        {
            _aiCorrelatingServiceProxyFactory = new Microsoft.ApplicationInsights.ServiceFabric.Remoting.Activities.CorrelatingServiceProxyFactory(serviceContext, createServiceRemotingClientFactory, retrySettings);
        }

        public TServiceInterface CreateServiceProxy<TServiceInterface>(Uri serviceUri, ServicePartitionKey partitionKey = null, TargetReplicaSelector targetReplicaSelector = TargetReplicaSelector.Default, string listenerName = null) where TServiceInterface : IService
        {
            return _aiCorrelatingServiceProxyFactory.CreateServiceProxy<TServiceInterface>(serviceUri, partitionKey, targetReplicaSelector, listenerName);
        }
    }
}
