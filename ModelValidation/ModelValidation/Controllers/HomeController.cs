using ModelValidation.Models;
using System;
using System.Web.Mvc;

namespace ModelValidation.Controllers
{
	public class HomeController : Controller
	{
		public ViewResult MakeBooking()
		{
			return View(new Appointment
			{
				Date = DateTime.Now
			});
		}

		[HttpPost]
		public ViewResult MakeBooking(Appointment appt)
		{
			if (string.IsNullOrEmpty(appt.ClientName))
			{
				ModelState.AddModelError("ClientName", "Please enter your name");
			}

			if (ModelState.IsValidField("Date") && DateTime.Now > appt.Date)
			{
				ModelState.AddModelError("Date", "Please enter a date in the future");
			}

			if (!appt.TermsAccepted)
			{
				ModelState.AddModelError("TermsAccepted", "Your must accepnt the terms");
			}

			if (ModelState.IsValid)
			{
				return View("Completed", appt);
			}
			else
			{
				return View();
			}

			return View("Completed", appt);
			
		}
	}
}