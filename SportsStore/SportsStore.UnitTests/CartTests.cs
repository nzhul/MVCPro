using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SportsStore.UnitTests
{
	[TestClass]
	public class CartTests
	{
		[TestMethod]
		public void Can_Add_New_Lines()
		{
			// Arrange - create some test products
			Product p1 = new Product { ProductID = 1, Name = "P1" };
			Product p2 = new Product { ProductID = 2, Name = "P2" };

			// Arrange - create a new cart
			Cart target = new Cart();

			target.AddItem(p1, 1);
			target.AddItem(p2, 1);
			CartLine[] results = target.Lines.ToArray();

			// Assert
			Assert.AreEqual(results.Length, 2);
			Assert.AreEqual(results[0].Product, p1);
			Assert.AreEqual(results[1].Product, p2);
		}

		[TestMethod]
		public void Can_Add_Quantity_For_Existing_Lines()
		{
			// Arrange - create some test products
			Product p1 = new Product { ProductID = 1, Name = "P1" };
			Product p2 = new Product { ProductID = 2, Name = "P2" };

			// Arrange - create a new cart
			Cart target = new Cart();

			// Act
			target.AddItem(p1, 1);
			target.AddItem(p2, 1);
			target.AddItem(p1, 10);
			CartLine[] results = target.Lines.OrderBy(c => c.Product.ProductID).ToArray();

			// Assert
			Assert.AreEqual(results.Length, 2);
			Assert.AreEqual(results[0].Quantity, 11);
			Assert.AreEqual(results[1].Quantity, 1);
		}

		[TestMethod]
		public void Can_Remove_Line()
		{
			// Arrange - create some test products
			Product p1 = new Product { ProductID = 1, Name = "P1" };
			Product p2 = new Product { ProductID = 2, Name = "P2" };
			Product p3 = new Product { ProductID = 3, Name = "P3" };

			// Arrange - create a new cart
			Cart target = new Cart();

			// Arrange - add some products to the cart
			target.AddItem(p1, 1);
			target.AddItem(p2, 2);
			target.AddItem(p3, 5);
			target.AddItem(p2, 1);

			// Act
			target.RemoveLine(p2);

			// Assert
			Assert.AreEqual(target.Lines.Where(c => c.Product == p2).Count(), 0);
			Assert.AreEqual(target.Lines.Count(), 2);
		}

		[TestMethod]
		public void Calculate_Cart_Total()
		{
			// Arrange - create some test products
			Product p1 = new Product { ProductID = 1, Name = "P1", Price = 100M };
			Product p2 = new Product { ProductID = 2, Name = "P2", Price = 50M };

			// Arrange - create a new cart
			Cart target = new Cart();

			// Act
			target.AddItem(p1, 1);
			target.AddItem(p2, 1);
			target.AddItem(p1, 3);
			decimal result = target.ComputeTotalValue();

			// Assert
			Assert.AreEqual(result, 450M);
		}

		[TestMethod]
		public void Can_Clear_Contents()
		{
			// Arrange - create some test products
			Product p1 = new Product { ProductID = 1, Name = "P1", Price = 100M };
			Product p2 = new Product { ProductID = 2, Name = "P2", Price = 50M };

			// Arrange - create a new cart
			Cart target = new Cart();

			// Act
			target.AddItem(p1, 1);
			target.AddItem(p2, 1);

			// Act
			target.Clear();

			// Assert
			Assert.AreEqual(target.Lines.Count(), 0);
		}

		[TestMethod]
		public void Cannot_Checkout_Empty_Cart()
		{
			// Arrange - create a mock order processor
			Mock<IOrderProcessor> mock = new Mock<IOrderProcessor>();

			// Arrange - create an empty cart
			Cart cart = new Cart();

			// Arrange - create shipping details
			ShippingDetails shippingDetails = new ShippingDetails();

			// Arrange - create an instance of the controller
			CartController target = new CartController(null, mock.Object);

			// Act
			ViewResult result = target.Checkout(cart, shippingDetails);

			// Assert - check that the order hasn't been passed to the processor
			mock.Verify(m => m.ProcessOrder(It.IsAny<Cart>(), It.IsAny<ShippingDetails>()), Times.Never());

			// Assert - check that the method is returning the default view
			Assert.AreEqual("", result.ViewName);

			// Assert - check that we are passing an invalid model to the view
			Assert.AreEqual(false, result.ViewData.ModelState.IsValid);
		}

		[TestMethod]
		public void Canot_Checkout_Invalid_ShippingDetails()
		{
			// Arrange - create a mock order processor
			Mock<IOrderProcessor> mock = new Mock<IOrderProcessor>();

			// Arrange - create a cart item with an item
			Cart cart = new Cart();
			cart.AddItem(new Product(), 1);

			// Arrange - create an instance of the controller
			CartController target = new CartController(null, mock.Object);

			//Arrange - add an error to the model
			target.ModelState.AddModelError("error", "error");

			// act - try to checkout
			ViewResult result = target.Checkout(cart, new ShippingDetails());

			// Assert - check thast the order hans't been passed on to the processor
			mock.Verify(m => m.ProcessOrder(It.IsAny<Cart>(), It.IsAny<ShippingDetails>()), Times.Never());

			// Assert - check that the method is returning the default view
			Assert.AreEqual("", result.ViewName);
			// assert - check that we are apssing an invalid mode to the view
			Assert.AreEqual(false, result.ViewData.ModelState.IsValid);
		}

		[TestMethod]
		public void Can_Checkout_And_Submit_Order()
		{
			// Arrange - create a mock order processor
			Mock<IOrderProcessor> mock = new Mock<IOrderProcessor>();

			// Arrange - create a cart with an item
			Cart cart = new Cart();
			cart.AddItem(new Product(), 1);

			// Arrange - create an instance of the controller
			CartController target = new CartController(null, mock.Object);

			// Act - try to checkout
			ViewResult result = target.Checkout(cart, new ShippingDetails());

			// assert - check that the order has been passed on to the processor
			mock.Verify(m => m.ProcessOrder(It.IsAny<Cart>(), It.IsAny<ShippingDetails>()), Times.Once());

			// assert - check that the method is returning the "Completed" view
			Assert.AreEqual("Completed", result.ViewName);

			Assert.AreEqual(true, result.ViewData.ModelState.IsValid);

		}
	}
}
