using System;
using System.Web;
using System.Web.Routing;

namespace UrlsAndRoutes.Infrastructure
{
	public class UserAgentConstrain : IRouteConstraint
	{
		private string requiredUserAgent;

		public UserAgentConstrain(string agentParam)
		{
			requiredUserAgent = agentParam;
		}

		public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
		{
			return httpContext.Request.UserAgent != null && httpContext.Request.UserAgent.Contains(requiredUserAgent);
		}
	}
}