using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControllersAndActions.Controllers
{
	public class ExampleController : Controller
	{
		public ViewResult Index()
		{
			return View((object)"Hello, World");
		}
	}
}