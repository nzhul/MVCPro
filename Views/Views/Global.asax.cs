using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Views.Infrastructure;

namespace Views
{
	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();

			// Using CustomLocationViewEngine
			ViewEngines.Engines.Clear();
			ViewEngines.Engines.Add(new CustomLocationViewEngine());

			//// Adding custom view engine
			//ViewEngines.Engines.Clear();
			//ViewEngines.Engines.Add(new DebugDataViewEngine());

			//The action invoker stops calling FindView methods as soon as it receives a 
			//ViewEngineResult object that contains an IView.
			// This means that the order in which engines are added to the ViewEngines.Engines
			// collection is significant if two or more engines are able to service a request for the same view name.If you
			// want your view to take precedence, then you can insert it at the start of the collection, like this:

			//ViewEngines.Engines.Insert(0, new DebugDataViewEngine());


			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
		}
	}
}
