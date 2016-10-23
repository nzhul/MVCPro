﻿using HelperMethods.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelperMethods.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			ViewBag.Fruits = new string[] { "Apple", "Orange", "Pear" };
			ViewBag.Cities = new string[] { "New York", "London", "Paris" };

			string message = "This is an HTML element: <input>";

			return View((object)message);
		}

		public ActionResult CreatePerson()
		{
			return View(new Person());
		}
		[HttpPost]
		public ActionResult CreatePerson(Person person)
		{
			return View(person);
		}
	}
}