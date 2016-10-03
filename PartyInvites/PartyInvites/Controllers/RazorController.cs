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

		public ActionResult NameAndPrice()
		{
			return View(myProduct);
		}

		public ActionResult DemoArray()
		{
			Product[] array =
			{
				new Product {Name = "Kayak", Price = 275M},
				new Product {Name = "Lifejacket", Price = 48.95M},
				new Product {Name = "Soccer ball", Price = 19.50M},
				new Product {Name = "Corner flag", Price = 34.95M}
			};

			return View(array);
		}

		public ActionResult DemoExpression()
		{
			ViewBag.ProductCount = 1;
			ViewBag.ExpressShip = true;
			ViewBag.ApplyDiscount = false;
			ViewBag.Supplier = null;

			return View(myProduct);
		}
	}
}