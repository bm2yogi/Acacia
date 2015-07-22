using System;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Acacia.Logging
{
    public class LoggingFilterAttribute : ActionFilterAttribute
    {
        private readonly ILogger _logger;

        public LoggingFilterAttribute(ILogger logger)
        {
            _logger = logger;
        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var message = String.Format("Executing: {0}.{1}",
                actionContext.ControllerContext.ControllerDescriptor.ControllerName,
                actionContext.ActionDescriptor.ActionName);
            _logger.LogInfo(message);
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            var message = String.Format("Executed: {0}.{1}",
                actionExecutedContext.ActionContext.ControllerContext.ControllerDescriptor.ControllerName,
                actionExecutedContext.ActionContext.ActionDescriptor.ActionName);
            _logger.LogInfo(message);
        }
    }
}