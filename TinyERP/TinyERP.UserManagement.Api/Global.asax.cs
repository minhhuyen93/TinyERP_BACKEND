﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TinyERP.Common.Applications;

namespace TinyERP.UserManagement.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        private IApplication app;
        public WebApiApplication()
        {
            this.app = new Application();
        }
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            this.app.OnApplicationStarted();
        }
    }
}
