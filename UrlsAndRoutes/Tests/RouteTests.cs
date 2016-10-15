using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web;
using Moq;
using System.Web.Routing;
using UrlsAndRoutes;
using System.Reflection;

namespace Tests
{
	[TestClass]
	public class RouteTests
	{
		private HttpContextBase CreateHttpContext(string targetUrl = null, string httpMethod = "GET")
		{
			// create the mock request
			Mock<HttpRequestBase> mockRequest = new Mock<HttpRequestBase>();
			mockRequest.Setup(m => m.AppRelativeCurrentExecutionFilePath)
				.Returns(targetUrl);
			mockRequest.Setup(m => m.HttpMethod).Returns(httpMethod);

			// create the mock response
			Mock<HttpResponseBase> mockResponse = new Mock<HttpResponseBase>();
			mockResponse.Setup(m => m.ApplyAppPathModifier(It.IsAny<string>())).Returns<string>(s => s);

			// create the mock context, using the request and response
			Mock<HttpContextBase> mockContext = new Mock<HttpContextBase>();
			mockContext.Setup(m => m.Request).Returns(mockRequest.Object);
			mockContext.Setup(m => m.Response).Returns(mockResponse.Object);

			//return the mocked context
			return mockContext.Object;
		}

		private void TestRouteMatch(string url, string controller, string action, object routeProperties = null, string httpMethod = "GET")
		{
			// arrange
			RouteCollection routes = new RouteCollection();
			RouteConfig.RegisterRoutes(routes);

			// act - process the route

			RouteData result = routes.GetRouteData(CreateHttpContext(url, httpMethod));

			// assert
			Assert.IsNotNull(result);
			Assert.IsTrue(TestIncomingRouteResult(result, controller, action, routeProperties));
		}

		private bool TestIncomingRouteResult(RouteData routeResult, string controller, string action, object propertySet)
		{
			Func<object, object, bool> valCompare = (v1, v2) =>
			{
				return StringComparer.InvariantCultureIgnoreCase.Compare(v1, v2) == 0;
			};

			bool result = valCompare(routeResult.Values["controller"], controller) && valCompare(routeResult.Values["action"], action);

			if (propertySet != null)
			{
				PropertyInfo[] propInfo = propertySet.GetType().GetProperties();
				foreach (PropertyInfo pi in propInfo)
				{
					if (!(routeResult.Values.ContainsKey(pi.Name)
					&& valCompare(routeResult.Values[pi.Name],
					pi.GetValue(propertySet, null))))
					{
						result = false;
						break;
					}
				}
			}

			return result;
		}

		private void TestRouteFail(string url)
		{
			// arrange
			RouteCollection routes = new RouteCollection();
			RouteConfig.RegisterRoutes(routes);

			// act - process the route
			RouteData result = routes.GetRouteData(CreateHttpContext(url));

			// assert
			Assert.IsTrue(result == null || result.Route == null);
		}

		[TestMethod]
		public void TestIncomingRoutes()
		{
			// check for the url that we hope to receive

			TestRouteMatch("~/Admin/Index", "Admin", "Index");

			// check that the values are being obtained from the segments
			TestRouteMatch("~/One/Two", "One", "Two");

			// ensure that too many or too few segments fails to match
			TestRouteFail("~/Admin/Index/Segment");
			TestRouteFail("~/Admin");
		}
	}
}
