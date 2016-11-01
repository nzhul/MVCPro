using ModelValidation.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ModelValidation.Models
{
	public class Appointment
	{
		[Required]
		public string ClientName { get; set; }

		[DataType(DataType.Date)]
		[Required(ErrorMessage = "Please enter a date")]
		[FutureDate(ErrorMessage = "Please enter a date in the future")]
		public DateTime Date { get; set; }

		[MustBeTrue(ErrorMessage = "You must accept the terms")]
		public bool TermsAccepted { get; set; }
	}
}