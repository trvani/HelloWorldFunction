using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Tracing;

namespace HelloWorldFunctionTest
{
    public class TracerWriterStub : TraceWriter
    {
        protected System.Diagnostics.TraceLevel _level;
        protected ConcurrentBag<TraceEvent> _traces;

        public TracerWriterStub(System.Diagnostics.TraceLevel level) : base(level) 
        {
            _level = level;
            _traces = new ConcurrentBag<TraceEvent>();
        }

        public override void Trace(TraceEvent traceEvent)
        {
            _traces.Add(traceEvent);
        }

        public List<TraceEvent> Traces =>_traces.ToList();
    }
}
