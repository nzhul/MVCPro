using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Views.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			ViewData["Message"] = "Hello, World!";
			ViewData["Time"] = DateTime.UtcNow.ToShortTimeString();
			return View("DebugData");
		}

		public ActionResult List()
		{
			return View();
		}
	}
}