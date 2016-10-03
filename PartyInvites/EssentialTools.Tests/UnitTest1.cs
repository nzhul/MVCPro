using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PartyInvites.Models;

namespace EssentialTools.Tests
{
	[TestClass]
	public class UnitTest1
	{
		private IDiscountHelper getTestObject()
		{
			return new MinimumDiscountHelper();
		}

		[TestMethod]
		public void TestMethod1()
		{
			// arrange
			IDiscountHelper target = getTestObject();
			decimal total = 200;

			// act
			var discountedTotal = target.ApplyDiscount(total);

			// assert
			Assert.AreEqual(total * .9M, discountedTotal);
		}

		[TestMethod]
		public void Discount_Between_10_And_100()
		{
			// arrange
			IDiscountHelper target = getTestObject();

			// act
			decimal tenDollarDiscount = target.ApplyDiscount(10);
			decimal hundredDollarDiscount = target.ApplyDiscount(100);
			decimal fiftyDollarDiscount = target.ApplyDiscount(50);

			// assert
			Assert.AreEqual(5, tenDollarDiscount, "$10 discount is wrong");
			Assert.AreEqual(95, hundredDollarDiscount, "$100 discount is wrong");
			Assert.AreEqual(45, fiftyDollarDiscount, "$50 discount is wrong");
		}

		[TestMethod]
		public void Discount_Less_Than_10()
		{
			// arrange
			IDiscountHelper target = getTestObject();

			// act
			decimal discount5 = target.ApplyDiscount(5);
			decimal discount0 = target.ApplyDiscount(0);

			// assert
			Assert.AreEqual(5, discount5);
			Assert.AreEqual(0, discount0);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void Discount_Negative_Total()
		{
			// arrange
			IDiscountHelper target = getTestObject();

			// act
			target.ApplyDiscount(-1);
		}
	}
}
