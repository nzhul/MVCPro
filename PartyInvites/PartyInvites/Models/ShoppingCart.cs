using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartyInvites.Models
{
	public class ShoppingCart : IEnumerable<Product>
	{
		private IValueCalculator calc;

		public IEnumerable<Product> Products { get; set; }

		public ShoppingCart(IValueCalculator calcParam)
		{
			calc = calcParam;
		}

		public IEnumerator<Product> GetEnumerator()
		{
			return Products.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public decimal CalculateProductTotal()
		{
			return calc.ValueProducts(Products);
		}
	}
}