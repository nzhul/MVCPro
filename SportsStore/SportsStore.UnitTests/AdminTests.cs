using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SportsStore.UnitTests
{
	[TestClass]
	public class AdminTests
	{
		public IQueryable<Product> TestCollection
		{
			get
			{
				return new Product[] {
					new Product {ProductID = 1, Name = "P1", Category = "Cat1"},
					new Product {ProductID = 2, Name = "P2", Category = "Cat2"},
					new Product {ProductID = 3, Name = "P3", Category = "Cat1"},
					new Product {ProductID = 4, Name = "P4", Category = "Cat2"},
					new Product {ProductID = 5, Name = "P5", Category = "Cat3"}
				}.AsQueryable();
			}
		}

		[TestMethod]
		public void IndexContains_AllProducts()
		{
			// Arrange - create the mock repository
			Mock<IProductRepository> mock = new Mock<IProductRepository>();
			mock.Setup(m => m.Products).Returns(this.TestCollection);

			// arrange - controller
			AdminController target = new AdminController(mock.Object);

			// action
			Product[] result = ((IEnumerable<Product>)target.Index().ViewData.Model).ToArray();

			// assert
			Assert.AreEqual(result.Length, 5);
			Assert.AreEqual("P1", result[0].Name);
			Assert.AreEqual("P2", result[1].Name);
			Assert.AreEqual("P3", result[2].Name);
			Assert.AreEqual("P4", result[3].Name);
			Assert.AreEqual("P5", result[4].Name);
		}

		[TestMethod]
		public void CanEdit_Product()
		{
			// Arrange - create the mock repository
			Mock<IProductRepository> mock = new Mock<IProductRepository>();
			mock.Setup(m => m.Products).Returns(this.TestCollection);

			// arrange - controller
			AdminController target = new AdminController(mock.Object);

			// act
			Product p1 = target.Edit(1).ViewData.Model as Product;
			Product p2 = target.Edit(2).ViewData.Model as Product;
			Product p3 = target.Edit(3).ViewData.Model as Product;

			// assert
			Assert.AreEqual(1, p1.ProductID);
			Assert.AreEqual(2, p2.ProductID);
			Assert.AreEqual(3, p3.ProductID);
		}

		[TestMethod]
		public void CannotEdit_NonExistentProduct()
		{
			// Arrange - create the mock repository
			Mock<IProductRepository> mock = new Mock<IProductRepository>();
			mock.Setup(m => m.Products).Returns(this.TestCollection);

			// arrange - controller
			AdminController target = new AdminController(mock.Object);

			// act 
			Product result = (Product)target.Edit(6).ViewData.Model;

			// assert
			Assert.IsNull(result);
		}

		[TestMethod]
		public void CanSave_ValidChanges()
		{
			// arrange
			Mock<IProductRepository> mock = new Mock<IProductRepository>();

			// create the controller
			AdminController target = new AdminController(mock.Object);

			// arrange - create a product
			Product product = new Product { Name = "Test" };

			// act - try to save the product
			ActionResult result = target.Edit(product);

			// assert - check that the repository was called
			mock.Verify(m => m.SaveProduct(product));

			// assert - check the method result type
			Assert.IsNotInstanceOfType(result, typeof(ViewResult));
		}

		[TestMethod]
		public void CannotSave_InvalidChanges()
		{
			// arrange - create mock repository
			Mock<IProductRepository> mock = new Mock<IProductRepository>();

			// arrange - create the controller
			AdminController target = new AdminController(mock.Object);

			// arrange - create a product
			Product product = new Product { Name = "Test" };

			// arrange - add an error to the model state
			target.ModelState.AddModelError("error", "error");

			// act - try to save the product
			ActionResult result = target.Edit(product);

			// assert - check that the repository was not called
			mock.Verify(m => m.SaveProduct(It.IsAny<Product>()), Times.Never());

			//assert - check the method result type
			Assert.IsInstanceOfType(result, typeof(ViewResult));
		}

		[TestMethod]
		public void CanDelete_ValidProducts()
		{
			// Arrange - create a product
			Product prod = new Product { ProductID = 2, Name = "Test" };

			// arrange - create a mock repository
			Mock<IProductRepository> mock = new Mock<IProductRepository>();
			mock.Setup(m => m.Products).Returns(new Product[] {
							new Product {ProductID = 1, Name = "P1"},
							prod,
							new Product {ProductID = 3, Name = "P3"},
							}.AsQueryable());

			// arrange - create the controller
			AdminController target = new AdminController(mock.Object);

			// act - delete the product
			target.Delete(prod.ProductID);

			// assert - ensure that the repository delete method was
			// called with the correct Product

			mock.Verify(m => m.DeleteProduct(prod.ProductID));
		}
	}
}
