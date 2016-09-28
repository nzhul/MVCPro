using PartyInvites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PartyInvites.Controllers
{
	public class RazorController : Controller
	{
		public Product myProduct = new Product
		{
			Id = 1,
			Name = "Kayak",
			Description = "Simple description text",
			Category = "Watersports",
			Price = 275M
		};

		public ActionResult Index()
		{
			return View(myProduct);
		}
	}
}