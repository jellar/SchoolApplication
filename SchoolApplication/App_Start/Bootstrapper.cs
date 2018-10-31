using Autofac;
using Autofac.Integration.Mvc;
using SchoolApplication.Data.Infrastructure;
using SchoolApplication.Data.Repository;
using SchoolApplication.Mappings;
using SchoolApplication.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolApplication
{
    public class Bootstrapper
    {
        public static void Run()
        {
            SetAutofacContainer();
            AutoMapperConfiguration.Configure();
        }

        private static void SetAutofacContainer()
        {
            var builder = new ContainerBuilder();

            // Register your MVC controllers.
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<DatabaseFactory>().As<IDatabaseFactory>().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(CourseRepository).Assembly)
                    .Where(t => t.Name.EndsWith("Repository"))
                    .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(CourseService).Assembly)
                    .Where(t => t.Name.EndsWith("Service"))
                    .AsImplementedInterfaces().InstancePerRequest();

            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}