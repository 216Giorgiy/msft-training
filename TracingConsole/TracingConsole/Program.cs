using Microsoft.ApplicationInsights.Extensibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace TracingConsole {
    class Program {
        static void Main(string[] args) {
            TelemetryConfiguration.Active.InstrumentationKey = "916a80d3-c8a6-452c-8241-c35dfff6b462";

            AppTrace.Verbose("Verbose Message");
            AppTrace.Warning("Warning message");
            AppTrace.Error("Error Message");

            Console.ReadKey();
        }
    }
}
