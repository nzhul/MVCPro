using ControllersAndActions.Infrastructure;
using System;
using System.Web.Mvc;

namespace ControllersAndActions.Controllers
{
	public class DerivedController : Controller
	{
		public ActionResult Index()
		{
			ViewBag.Message = "Hello from the derivedController Index method";
			return View();
		}

		public ActionResult ProduceOutput()
		{
			return Redirect("/Basic/Index");

			// Custom redirect
			//if (Server.MachineName == "TINY")
			//{
			//	return new CustomRedirectResult { Url = "/Basic/Index" };
			//}
			//else
			//{
			//	Response.Write("Controller: Derived, Action: ProduceOutput");
			//	return null;
			//}
		}

		//public ActionResult RenameProduct()
		//{
		//	// access various properties from context objects
		//	string userName = User.Identity.Name;
		//	string serverName = Server.MachineName;
		//	string clientIP = Request.UserHostAddress;
		//	DateTime dateStamp = HttpContext.Timestamp;
		//	AuditRequest(userName, serverName, clientIP, dateStamp, "Renaming product");

		//	string oldProductName = Request.Form["OldName"];
		//	string newProductName = Request.Form["NewName"];
		//	bool result = AttemptProductRename(oldProductName, newProductName);


		//	ViewData["RenameResult"] = result;
		//	return View("ProductRenamed");
		//}

		public ActionResult ShowWeatherForecast(string city, DateTime forDate)
		{
			return View();
		}
	}
}