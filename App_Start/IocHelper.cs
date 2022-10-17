using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Employee.API.Repositories;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;

namespace Employee.API.App_Start {
    public class IocHelper {
        public static IContainer CreateContainer() {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterModule<RepositoryModule>();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            return container;
        }
    }
}

