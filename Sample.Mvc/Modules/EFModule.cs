using Autofac;
using Sample.Business.Modules;

namespace Sample.Mvc.Modules
{
    public class EFModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new EfCoreModule());
        }
    }
}