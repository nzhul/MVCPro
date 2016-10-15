using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace UrlsAndRoutes
{
	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			Route myRoute = new Route("{controller}/{action}", new MvcRouteHandler());
			routes.Add("MyRoute", myRoute);

			// MVC Only
			//routes.MapRoute("MyRoute", "{controller}/{action}");

			// WebForms only
			//routes.MapPageRoute();
		}
	}
}
