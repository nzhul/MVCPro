﻿using ModelBinding.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModelBinding.Infrastructure
{
	public class AddressSummaryBinder : IModelBinder
	{
		public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
		{
			AddressSummary model = (AddressSummary)bindingContext.Model ?? new AddressSummary();

			model.City = GetValue(bindingContext, "City");
			model.Country = GetValue(bindingContext, "Country");
			return model;
		}

		private string GetValue(ModelBindingContext context, string name)
		{
			name = (context.ModelName == "" ? "" : context.ModelName + ".") + name;

			ValueProviderResult result = context.ValueProvider.GetValue(name);
			if (result == null || result.AttemptedValue == "")
			{
				return "<Not Specified>";
			}
			else
			{
				return (string)result.AttemptedValue;
			}
		}
	}
}