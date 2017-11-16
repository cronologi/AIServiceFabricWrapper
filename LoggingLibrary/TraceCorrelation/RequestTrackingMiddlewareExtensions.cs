using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingLibrary.TraceCorrelation
{
    public static class RequestTrackingMiddlewareExtensions
    {
        public static void UseRequestTrackingMiddleware(this IAppBuilder app, RequestTrackingMiddlewareOptions options = null)
        {
            if (options == null)
                options = new RequestTrackingMiddlewareOptions();

            app.Use<RequestTrackingMiddleware>(options);
        }
    }
}
