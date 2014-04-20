using BillsApplicationDomain;
using BillsApplicationDomain.Repository;
using BillsApplicationDomain.Services;
using Ninject;
using Ninject.Web.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace BillsApplication
{
    public class MvcApplication : NinjectHttpApplication
    {
        protected override void OnApplicationStarted()
        {
            base.OnApplicationStarted();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected override Ninject.IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            kernel.Bind<DbContext>().To<BillsDbContext>();

            // Delete below if using Ninject Conventions Extension
            kernel.Bind<IBillService>().To<BillService>();
            kernel.Bind<IGenericRepository>().To<GenericRepository>();
            

            // Ninject Conventions Extension use this nuget package to replace above Bindings 
            // kernel.Bind(x => x.FromThisAssembly().SelectAllClasses().EndingWith("MySuffix").BindAllInterfaces();

            return kernel;
        }
    }
}
