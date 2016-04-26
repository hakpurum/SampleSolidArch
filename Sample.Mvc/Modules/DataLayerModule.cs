using System.Reflection;
using Autofac;
using Module = Autofac.Module;

namespace Sample.Mvc.Modules
{
    public class DataLayerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.Load("Sample.DataLayer"))
                .Where(t => t.Name.EndsWith("Dal"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}