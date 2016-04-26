using Autofac;
using Sample.Core.DataAccess;
using Sample.Core.Interface;
using Sample.DataLayer.Concrete.EntityFramework;
using System.Data.Entity;
using System.Reflection;
using Module = Autofac.Module;


namespace Sample.Business.Modules
{
    public class EfCoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.Load("Sample.Core"));
            builder.RegisterType(typeof(SampleDbContext)).As(typeof(DbContext)).InstancePerLifetimeScope();

            builder.RegisterType(typeof(UnitOfWork)).As(typeof(IUnitOfWork)).InstancePerRequest();
        }
    }
}
