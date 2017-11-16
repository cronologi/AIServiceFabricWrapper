using Microsoft.AspNetCore.Builder;
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
        public static IApplicationBuilder UseRequestTracking(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestTrackingMiddleware>();
        }
    }
}
