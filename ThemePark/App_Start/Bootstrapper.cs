using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using ThemePark.Repositories.Implementations;
using ThemePark.Services.Implementations;

namespace ThemePark
{
    public class Bootstrapper
    {
        public static void Run()
        {
            SetAutofacContainer();           
        }
        private static void SetAutofacContainer()
        {
            var builder = new ContainerBuilder();

          // builder.RegisterType<ThemeParkDBContext>().InstancePerLifetimeScope();
            // Repositories
            builder.RegisterAssemblyTypes(typeof(RideRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();
            // Services
            builder.RegisterAssemblyTypes(typeof(RideService).Assembly)
               .Where(t => t.Name.EndsWith("Service"))
               .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            IContainer container = builder.Build();

            var webApiResolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = webApiResolver;
        }
    }
}