using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Filters;
using Acacia.ExceptionHandling;
using Acacia.Logging;

namespace Acacia
{
    public class WebApiFilterConfig
    {
        public static void RegisterGlobalWebApiFilters(HttpConfiguration httpConfiguration)
        {
            var filters = new List<IFilter>
            {
                new TimerAttribute(),
                new ExceptionHandlerAttribute()
            };
            
            filters.ForEach(httpConfiguration.Filters.Add);
        }
    }
}
