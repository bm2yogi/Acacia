using System.Reflection;
using System.Web.Http;
using Acacia.Logging;
using Autofac;
using Autofac.Integration.WebApi;

namespace Acacia
{
    public static class DependencyConfig
    {
        public static void RegisterDependencies(HttpConfiguration httpConfiguration)
        {
            var builder = new ContainerBuilder();
            var currentAssembly = Assembly.GetExecutingAssembly();

            builder.RegisterApiControllers(currentAssembly);
            builder.RegisterAssemblyTypes(currentAssembly).AsImplementedInterfaces();
            builder.Register(c => new LoggingFilterAttribute(c.Resolve<ILogger>()));

            httpConfiguration.DependencyResolver = 
                new AutofacWebApiDependencyResolver(builder.Build());
        }
    }
}