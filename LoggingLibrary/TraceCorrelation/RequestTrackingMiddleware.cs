using Microsoft.AspNetCore.Http;
using System;
using System.Fabric;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;

namespace LoggingLibrary.TraceCorrelation
{
    public class RequestTrackingMiddleware
    {
        private readonly RequestDelegate next;

        public RequestTrackingMiddleware(RequestDelegate next)
        {
            //this.next = next;
        }

        public async Task Invoke(HttpContext context, ServiceContext serviceContext)
        {
            //CallContext.LogicalSetData(HeaderIdentifiers.TraceId, context.Request.HttpContext.TraceIdentifier);

            //AddTracingDetailsOnRequest(context, serviceContext);

            //try
            //{
            //    await next(context);
            //}
            //catch (Exception ex)
            //{
            //    throw;
            //}
            //finally
            //{
            //}

        }

        private static void AddTracingDetailsOnRequest(HttpContext context, ServiceContext serviceContext)
        {
            //if (!context.Request.Headers.ContainsKey("X-Fabric-AddTracingDetails")) return;

            //context.Response.Headers.Add("X-Fabric-NodeName", serviceContext.NodeContext.NodeName);
            //context.Response.Headers.Add("X-Fabric-InstanceId", serviceContext.ReplicaOrInstanceId.ToString(CultureInfo.InvariantCulture));
            //context.Response.Headers.Add("X-Fabric-TraceId", context.Request.HttpContext.TraceIdentifier);
        }
    }
}
