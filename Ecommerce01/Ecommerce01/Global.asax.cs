using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Ecommerce01.Classes;
using Ecommerce01.Models;

namespace Ecommerce01
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //added
            //and simplify with usings
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Ecommerce01Context, Migrations.Configuration>());
            //last add
            CheckRolesAndSuperUser();

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        //last add
        private void CheckRolesAndSuperUser()
        {
            //developer i'am Vargas
            UsersHelper.CheckRole("Admin");
            //Altri admin of ecommerce Clients
            UsersHelper.CheckRole("User");
            //SuperUser can create Users is always Admin
            UsersHelper.CheckSuperUser();

        }

        //added
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            CultureInfo culture = new CultureInfo("it-IT");
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
        }

    }
}
