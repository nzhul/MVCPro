using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Controllers;
using SportsStore.WebUI.Models;
using System.Linq;
using System.Web.Mvc;

namespace SportsStore.UnitTests
{
	[TestClass]
	public class CartControllerTests
	{
		public IQueryable<Product> TestCollection
		{
			get
			{
				return new Product[] {
					new Product {ProductID = 1, Name = "P1", Category = "Cat1"}
				}.AsQueryable();
			}
		}

		[TestMethod]
		public void Can_Add_To_Cart()
		{
			// Arrange - create the mock repo
			Mock<IProductRepository> mock = new Mock<IProductRepository>();
			mock.Setup(m => m.Products).Returns(this.TestCollection);

			// Arrange - create a Cart
			Cart cart = new Cart();

			// Arrange - create the controller
			CartController target = new CartController(mock.Object, null);

			// Act - add a product to the cart
			target.AddToCart(cart, 1, null);

			Assert.AreEqual(cart.Lines.Count(), 1);
			Assert.AreEqual(cart.Lines.ToArray()[0].Product.ProductID, 1);
		}

		[TestMethod]
		public void Adding_Product_To_Cart_Goes_To_Cart_Screen()
		{
			// Arrange - create the mock repo
			Mock<IProductRepository> mock = new Mock<IProductRepository>();
			mock.Setup(m => m.Products).Returns(this.TestCollection);

			// Arrange - create a Cart
			Cart cart = new Cart();

			// Arrange - create the controller
			CartController target = new CartController(mock.Object, null);

			// Act - add a product to the cart
			RedirectToRouteResult result = target.AddToCart(cart, 2, "myUrl");

			// Assert
			Assert.AreEqual(result.RouteValues["action"], "Index");
			Assert.AreEqual(result.RouteValues["returnUrl"], "myUrl");
		}

		[TestMethod]
		public void Can_View_Cart_Contents()
		{
			// Arrange - create a Cart
			Cart cart = new Cart();

			// Arrange - create the controller
			CartController target = new CartController(null, null);

			// Act - call the Index action method
			CartIndexViewModel result = (CartIndexViewModel)target.Index(cart, "myUrl").ViewData.Model;

			// Assert
			Assert.AreSame(result.Cart, cart);
			Assert.AreEqual(result.ReturnUrl, "myUrl");
		}
	}
}
