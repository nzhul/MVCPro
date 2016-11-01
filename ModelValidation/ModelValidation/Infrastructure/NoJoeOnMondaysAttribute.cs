﻿using ModelValidation.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace ModelValidation.Infrastructure
{
	public class NoJoeOnMondaysAttribute : ValidationAttribute
	{
		public override bool IsValid(object value)
		{
			Appointment app = value as Appointment;
			if (app == null || string.IsNullOrEmpty(app.ClientName) ||
				app.Date == null)
			{
				// we dont't have a model of the right type to validate , or we don't have 
				// the values for the ClientName and Date properties we require
				return true;
			}
			else
			{
				return !(app.ClientName == "Joe" && 
					app.Date.DayOfWeek == DayOfWeek.Monday);
			}
		}
	}
}