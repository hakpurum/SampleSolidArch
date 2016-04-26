using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Sample.Mvc.Modules;

namespace Sample.Mvc
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);


            //Autofac Configuration
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(Global).Assembly).PropertiesAutowired();
            builder.RegisterApiControllers(typeof(Global).Assembly).PropertiesAutowired();


            builder.RegisterModule(new DataLayerModule());
            builder.RegisterModule(new ServiceModule());
            builder.RegisterModule(new EFModule());


            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);


        }
    }
}