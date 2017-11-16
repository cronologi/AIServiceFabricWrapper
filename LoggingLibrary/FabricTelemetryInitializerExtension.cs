using Microsoft.ApplicationInsights.ServiceFabric;
using System;
using System.Collections.Generic;
using System.Fabric;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingLibrary
{
    public static class FabricTelemetryInitializerExtension
    {
        public static void SetServiceCallContext(ServiceContext context)
        {
            Microsoft.ApplicationInsights.ServiceFabric.FabricTelemetryInitializerExtension.SetServiceCallContext(context);
        }
    }
}
