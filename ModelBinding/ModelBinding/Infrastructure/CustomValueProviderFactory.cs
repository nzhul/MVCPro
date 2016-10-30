﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModelBinding.Infrastructure
{
	public class CustomValueProviderFactory : ValueProviderFactory
	{
		public override IValueProvider GetValueProvider(ControllerContext controllerContext)
		{
			return new CountryValueProvider();
		}
	}
}