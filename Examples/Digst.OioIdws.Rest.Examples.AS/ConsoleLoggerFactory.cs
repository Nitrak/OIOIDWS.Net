using System;
using System.Diagnostics;
using System.Runtime.Remoting.Messaging;
using Microsoft.Owin.Logging;

namespace Digst.OioIdws.Rest.Examples.AS
{
    internal class ConsoleLoggerFactory : ILoggerFactory
    {
        class Logger : ILogger
        {
            private readonly string _name;

            public Logger(string name)
            {
                _name = name;
            }

            public bool WriteCore(TraceEventType eventType, int eventId, object state, Exception exception, Func<object, Exception, string> formatter)
            {
                Console.WriteLine($"{_name} (requestid:{CallContext.LogicalGetData("correlationIdentifier")}): {eventType} - {formatter(state, exception)}");
                return true;
            }
        }
        public ILogger Create(string name)
        {
            return new Logger(name);
        }
    }
}