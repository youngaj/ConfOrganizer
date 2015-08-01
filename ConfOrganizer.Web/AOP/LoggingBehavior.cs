using Microsoft.Practices.Unity.InterceptionExtension;
using Serilog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace ConfOrganizer.Web.AOP
{
    public class LoggingBehavior : IInterceptionBehavior
    {
        private ILogger _log;
        public LoggingBehavior(ILogger log)
        {
            _log = log;
        }

        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            var className = input.Target.ToString().Split('.').Last();
            var methodName = input.MethodBase.Name;

            // Before invoking the method on the original target.
            _log.Debug("{className}: {function} started.", className, methodName);
            var timer = new Stopwatch();
            timer.Start();

            // Invoke the next behavior in the chain.
            var result = getNext()(input, getNext);

            timer.Stop();

            // After invoking the method on the original target.
            if (result.Exception != null)
            {
                _log.Warning("--- {className}: {function} threw exception {exception}.", className, methodName, result.Exception);
            }
            else
            {
                _log.Debug("--- {className}: {function} returned {returnValue}.", className, methodName, result);
            }
            _log.Information("--- {className}: {function} executed in {executionTime} (in Milliseconds).", className, methodName, timer.Elapsed.TotalMilliseconds);
            return result;
        }

        public bool WillExecute
        {
            get { return true; }
        }
    }
}