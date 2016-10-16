using System.Web.Mvc;

namespace UrlsAndRoutes.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			ViewBag.Controller = "Home";
			ViewBag.Action = "Index";
			return View("ActionName");
		}

		public ActionResult CustomVariable(string id = "DefaultId")
		{
			ViewBag.Controller = "Home";
			ViewBag.Action = "CustomVariable";
			ViewBag.CustomVariable = id;
			ViewBag.CatchAll = RouteData.Values["catchall"];
			return View();
		}

		public ViewResult MyActionMethod()
		{
			string myActionUrl = Url.Action("Index", new { id = "MyID" });
			string myRouteUrl = Url.RouteUrl(new { controller = "Home", action = "Index" });

			// do something with the URLS

			return View();
		}
	}
}