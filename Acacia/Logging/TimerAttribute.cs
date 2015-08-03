using System;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Acacia.Logging
{
    public class TimerAttribute : ActionFilterAttribute
    {
        private readonly Action<string> _logInfo = CustomLogger.LogInfo;
        private readonly Stopwatch _stopwatch = new Stopwatch();

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            _stopwatch.Restart();
            Task.Run(() =>
            {
                var methodName = MethodName(actionContext);
                var requestId = RequestId(actionContext.Request);
                var message = String.Format("Executing: {0} | RequestId: {1}", methodName, requestId);
                _logInfo(message);
            });
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            _stopwatch.Stop();
            Task.Run(() =>
            {
                var methodName = MethodName(actionExecutedContext.ActionContext);
                var requestId = RequestId(actionExecutedContext.Request);
                var elapsed = _stopwatch.ElapsedMilliseconds;
                var message = String.Format("Executed: {0} | RequestId: {1} | ElapsedMS: {2}", methodName, requestId, elapsed);
                _logInfo(message);
            });
        }

        private static string MethodName(HttpActionContext action)
        {
            return string.Format("{0}.{1}",
                action.ControllerContext.ControllerDescriptor.ControllerName,
                action.ActionDescriptor.ActionName);
        }

        private static string RequestId(HttpRequestMessage request)
        {
            return request.Headers.GetValues("RequestId").First();
        }
    }
}