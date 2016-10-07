using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using System.Linq;
using SportsStore.WebUI.Controllers;
using System.Collections.Generic;
using System.Web.Mvc;
using SportsStore.WebUI.Models;
using SportsStore.WebUI.HtmlHelpers;

namespace SportsStore.UnitTests
{
	[TestClass]
	public class UnitTest1
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
		public void Generate_Category_Specific_Product_Count()
		{
			// Arrange - mock repository
			Mock<IProductRepository> mock = new Mock<IProductRepository>();
			mock.Setup(m => m.Products).Returns(this.TestCollection);

			// Arrange - create a controller and make the page size 3 items
			ProductController target = new ProductController(mock.Object);
			target.PageSize = 3;

			// Action - test the product counts for different categories
			int result1 = ((ProductsListViewModel)target.List("Cat1").Model).PagingInfo.TotalItems;
			int result2 = ((ProductsListViewModel)target.List("Cat2").Model).PagingInfo.TotalItems;
			int result3 = ((ProductsListViewModel)target.List("Cat3").Model).PagingInfo.TotalItems;
			int resultAll = ((ProductsListViewModel)target.List(null).Model).PagingInfo.TotalItems;

			// Assert
			Assert.AreEqual(result1, 2);
			Assert.AreEqual(result2, 2);
			Assert.AreEqual(result3, 1);
			Assert.AreEqual(resultAll, 5);
		}

		[TestMethod]
		public void Indicates_Selected_Category()
		{
			// Arrange - create mock repository
			Mock<IProductRepository> mock = new Mock<IProductRepository>();
			mock.Setup(m => m.Products).Returns(this.TestCollection);

			// Arrange create the controller
			NavController target = new NavController(mock.Object);

			// Arrange - define the category to selected
			string categoryToSelect = "Cat2";

			// Action
			string result = target.Menu(categoryToSelect).ViewBag.SelectedCategory;

			// Assert
			Assert.AreEqual(categoryToSelect, result);
		}

		[TestMethod]
		public void Can_Create_Categories()
		{
			// Arrange - create the mock repository
			Mock<IProductRepository> mock = new Mock<IProductRepository>();
			mock.Setup(m => m.Products).Returns(this.TestCollection);

			// Arrange - create the controller
			NavController target = new NavController(mock.Object);

			// Act - get the set of categories
			string[] results = ((IEnumerable<string>)target.Menu().Model).ToArray();

			Assert.AreEqual(results.Length, 3);
			Assert.AreEqual(results[0], "Cat1");
			Assert.AreEqual(results[1], "Cat2");
			Assert.AreEqual(results[2], "Cat3");
		}

		[TestMethod]
		public void Can_Filter_Products()
		{
			// Arrange
			Mock<IProductRepository> mock = new Mock<IProductRepository>();
			mock.Setup(m => m.Products).Returns(this.TestCollection);

			// Arrange - create a controller and make the page size 3 items
			ProductController controller = new ProductController(mock.Object);
			controller.PageSize = 3;

			// Action
			Product[] result = ((ProductsListViewModel)controller.List("Cat2", 1).Model).Products.ToArray();

			// Assert
			Assert.AreEqual(result.Length, 2);
			Assert.IsTrue(result[0].Name == "P2" && result[0].Category == "Cat2");
			Assert.IsTrue(result[1].Name == "P4" && result[0].Category == "Cat2");
		}

		[TestMethod]
		public void Can_Paginate()
		{
			// Arrange
			Mock<IProductRepository> mock = new Mock<IProductRepository>();
			mock.Setup(m => m.Products).Returns(this.TestCollection);

			ProductController controller = new ProductController(mock.Object);
			controller.PageSize = 3;

			// Act
			ProductsListViewModel model = (ProductsListViewModel)controller.List(null, 2).Model;

			IEnumerable<Product> result = model.Products;

			// Assert
			Product[] prodArray = result.ToArray();
			Assert.IsTrue(prodArray.Length == 2);
			Assert.AreEqual(prodArray[0].Name, "P4");
			Assert.AreEqual(prodArray[1].Name, "P5");
		}

		[TestMethod]
		public void Can_Generate_Page_Links()
		{
			// Arrange - define an HTML helper - we need to do this 
			// in order to apply the extension method
			HtmlHelper myHelper = null;

			// Arrange - create PagingInfo data
			PagingInfo pagingInfo = new PagingInfo
			{
				CurrentPage = 2,
				TotalItems = 28,
				ItemsPerPage = 10
			};

			// Arrange - set up the delegate using a lambda expression
			Func<int, string> pageUrlDelegate = i => "Page" + i;

			// Act
			MvcHtmlString result = myHelper.PageLinks(pagingInfo, pageUrlDelegate);

			// Assert
			Assert.AreEqual(result.ToString(), @"<a href=""Page1"">1</a>"
								+ @"<a class=""selected"" href=""Page2"">2</a>"
								+ @"<a href=""Page3"">3</a>");
		}

		[TestMethod]
		public void Can_Send_Pagination_View_Model()
		{
			// Arrange
			Mock<IProductRepository> mock = new Mock<IProductRepository>();
			mock.Setup(m => m.Products).Returns(this.TestCollection);

			// Arrange
			ProductController controller = new ProductController(mock.Object);
			controller.PageSize = 3;

			// Act
			ProductsListViewModel result = (ProductsListViewModel)controller.List(null, 2).Model;

			// Assert
			PagingInfo pageInfo = result.PagingInfo;
			Assert.AreEqual(pageInfo.CurrentPage, 2);
			Assert.AreEqual(pageInfo.ItemsPerPage, 3);
			Assert.AreEqual(pageInfo.TotalItems, 5);
			Assert.AreEqual(pageInfo.TotalPages, 2);
		}
	}
}
