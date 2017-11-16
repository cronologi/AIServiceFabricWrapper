using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppFunc = System.Func<
    System.Collections.Generic.IDictionary<string, object>,
    System.Threading.Tasks.Task>;

namespace LoggingLibrary.TraceCorrelation
{
    public class RequestTrackingMiddleware
    {
        AppFunc _next;
        RequestTrackingMiddlewareOptions _options;

        public async Task Invoke(IDictionary<string, object> environment)
        {
            var ctx = new OwinContext(environment);

            _options.OnIncomingRequest(ctx);
            await _next(environment);
            _options.OnOutgoingRequest(ctx);
        }
    }
}
