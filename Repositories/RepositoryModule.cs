using Autofac;

namespace Employee.API.Repositories {
    public class RepositoryModule : Module {
        protected override void Load(ContainerBuilder builder) {
            builder.RegisterType<EmployeeRepository>().As<IEmployeeRepository>();
        }
    }
}