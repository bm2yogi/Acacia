using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;
using Acacia.Logging;

namespace Acacia.ExceptionHandling
{
    public class ExceptionHandlerAttribute : ExceptionFilterAttribute
    {
        private readonly Action<string> _logInfo = CustomLogger.LogInfo;

        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            var ex = actionExecutedContext.Exception;
            var message = string.Format("Unhandled Exception: {0} \n\tStackTrace: {1}", ex.Message, ex.StackTrace);
            _logInfo(message);

            actionExecutedContext.Response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
        }
    }
}