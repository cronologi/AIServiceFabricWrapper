using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Fabric;
using RemotingInterfaces;
using Microsoft.ServiceFabric.Services.Remoting.Client;
using LoggingLibrary.TraceCorrelation;
using Microsoft.ServiceFabric.Services.Remoting.V1.FabricTransport.Client;
using LoggingLibrary.Interfaces;

namespace WebStateless.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        ServiceContext serviceContext;
        ITelemetryLogger logger;

        public ValuesController(StatelessServiceContext serviceContext)
        {
            this.serviceContext = serviceContext;
        }

        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<string>> Get()
        {
            var proxyFactory = new AICorrelatingServiceProxyFactory(this.serviceContext, callbackClient => new FabricTransportServiceRemotingClientFactory(callbackClient: callbackClient));
            IMyService proxy = proxyFactory.CreateServiceProxy<IMyService>(new Uri("fabric:/LoggingLibraryPOC/StatelessBackendService"));


            //IMyService proxy = ServiceProxy.Create<IMyService>(new Uri("fabric:/LoggingLibraryPOC/StatelessBackendService"));
            string message = await proxy.HelloWorldAsync();

            return await Task.FromResult(new string[] { "value1", "value2", message });
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
