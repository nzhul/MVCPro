using Filters.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Filters.Controllers
{
	//[CustomAuth(false)]
	public class HomeController : Controller
	{
		[Authorize(Users = "adam, steve, jacqui", Roles = "admin")]
		public string Index()
		{
			return "This is the index action on the Home controller";
		}

		[RangeException]
		public string RangeTest(int id)
		{
			if (id > 100)
			{
				return string.Format("The id value is: {0}", id);
			}
			else
			{
				throw new ArgumentOutOfRangeException("id", id, "");
			}
		}
	}
}