using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModelBinding.Infrastructure
{
	public class CountryValueProvider : IValueProvider
	{
		public bool ContainsPrefix(string prefix)
		{
			return prefix.ToLower().IndexOf("country") > -1;
		}

		public ValueProviderResult GetValue(string key)
		{
			if (this.ContainsPrefix(key))
			{
				return new ValueProviderResult("USA", "USA", CultureInfo.InvariantCulture);
			}
			else
			{
				return null;
			}
		}
	}
}