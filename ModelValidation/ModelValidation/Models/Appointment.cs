using ModelValidation.Infrastructure;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ModelValidation.Models
{
	[NoJoeOnMondays]
	public class Appointment //: IValidatableObject
	{
		[Required]
		public string ClientName { get; set; }

		//[DataType(DataType.Date)]
		//[Required(ErrorMessage = "Please enter a date")]
		//[FutureDate(ErrorMessage = "Please enter a date in the future")]
		[Remote("ValidateDate", "Home")]
		public DateTime Date { get; set; }

		[MustBeTrue(ErrorMessage = "You must accept the terms")]
		public bool TermsAccepted { get; set; }

		//public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		//{
		//	List<ValidationResult> errors = new List<ValidationResult>();

		//	if (string.IsNullOrEmpty(ClientName))
		//	{
		//		errors.Add(new ValidationResult("Please enter your name"));
		//	}

		//	if (DateTime.Now > Date)
		//	{
		//		errors.Add(new ValidationResult("Please enter a date in the future"));
		//	}

		//	if (errors.Count == 0 && ClientName == "Joe" &&
		//		Date.DayOfWeek == DayOfWeek.Monday)
		//	{
		//		errors.Add(new ValidationResult("Joe cannot book appointments on Mondays"));
		//	}

		//	if (!TermsAccepted)
		//	{
		//		errors.Add(new ValidationResult("Your must accept the terms"));
		//	}

		//	return errors;
		//}
	}
}