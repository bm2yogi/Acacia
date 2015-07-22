using System.Web.Http;
using System.Web.Http.Filters;
using Acacia.Logging;

namespace Acacia
{
    public class WebApiFilterConfig
    {
        public static void RegisterGlobalWebApiFilters(HttpConfiguration httpConfiguration)
        {
            var loggingFilter = (IFilter) httpConfiguration.DependencyResolver.GetService(typeof(LoggingFilterAttribute));
            httpConfiguration.Filters.Add(loggingFilter);
        }
    }
}
