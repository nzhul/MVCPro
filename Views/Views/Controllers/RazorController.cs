using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Views.Controllers
{
	public class RazorController : Controller
	{
		public ActionResult Index()
		{
			string[] names = { "Apple", "Orange", "Pear" };
			return View(names);
		}

		public ActionResult List()
		{
			return View();
		}
	}
}