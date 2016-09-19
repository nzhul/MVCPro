using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PartyInvites.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			int hour = DateTime.Now.Hour;
			ViewBag.Greeting = hour < 12 ? "Good Morning" : "Good Afternoon";
			return View();
		}

		public ActionResult RsvpForm()
		{
			return View();
		}
	}
}