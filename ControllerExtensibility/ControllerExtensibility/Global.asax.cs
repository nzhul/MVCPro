﻿using ControllerExtensibility.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ControllerExtensibility
{
	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);

			ControllerBuilder.Current.SetControllerFactory(new DefaultControllerFactory(new CustomControllerActivator()));

			//ControllerBuilder.Current.SetControllerFactory(new CustomControllerFactory());

			//ControllerBuilder.Current.DefaultNamespaces.Add("MyControllerNamespace");
			//ControllerBuilder.Current.DefaultNamespaces.Add("MyProject.*");

		}
	}
}
