using System.Reflection;
using Autofac;
using Autofac.Integration.WebApi;
using Module = Autofac.Module;

namespace Sample.Mvc.Modules
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.Load("Sample.Business"))
                .Where(t => t.Name.EndsWith("Manager"))
                .AsImplementedInterfaces()
                .InstancePerApiRequest()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(Assembly.Load("Sample.Core"))
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .InstancePerApiRequest()
                .InstancePerLifetimeScope();
        }
    }
}