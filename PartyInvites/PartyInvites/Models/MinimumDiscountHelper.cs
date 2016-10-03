﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartyInvites.Models
{
	public class MinimumDiscountHelper : IDiscountHelper
	{
		public decimal ApplyDiscount(decimal totalParam)
		{
			if (totalParam < 0)
			{
				throw new ArgumentOutOfRangeException();
			}
			else if (totalParam > 100)
			{
				return totalParam * .9M;
			}
			else if (totalParam >= 10 && totalParam <= 100)
			{
				return totalParam - 5;
			}
			else
			{
				return totalParam;
			}
		}
	}
}