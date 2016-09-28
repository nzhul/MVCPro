using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartyInvites.Models
{
	public static class MyExtensionMethods
	{
		public static decimal TotalPrices(this IEnumerable<Product> productEnum)
		{
			decimal total = 0;
			foreach (Product product in productEnum)
			{
				total += product.Price;
			}

			return total;
		}

		public static IEnumerable<Product> FilterByCategory(this IEnumerable<Product> productEnum, string categoryParam)
		{
			foreach (Product prod in productEnum)
			{
				if (prod.Category == categoryParam)
				{
					yield return prod;
				}
			}
		}

		public static IEnumerable<Product> Filter(this IEnumerable<Product> productEnum, Func<Product, bool> selectorParam)
		{
			foreach (Product prod in productEnum)
			{
				if (selectorParam(prod))
				{
					yield return prod;
				}
			}
		}
	}
}