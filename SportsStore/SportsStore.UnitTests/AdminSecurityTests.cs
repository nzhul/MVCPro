using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportsStore.WebUI.Controllers;
using SportsStore.WebUI.Infrastructure.Abstract;
using SportsStore.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SportsStore.UnitTests
{
	[TestClass]
	public class AdminSecurityTests
	{
		[TestMethod]
		public void CanLogin_WithValidCredentials()
		{
			// arrange - create a mock authentication provider
			Mock<IAuthProvider> mock = new Mock<IAuthProvider>();
			mock.Setup(m => m.Authenticate("admin", "secret")).Returns(true);

			// arrange - create the view model
			LoginViewModel model = new LoginViewModel
			{
				UserName = "admin",
				Password = "secret"
			};

			// arrange - create the controller
			AccountController target = new AccountController(mock.Object);

			// act - authenticate using valid credentials
			ActionResult result = target.Login(model, "/MyUrl");

			// assert
			Assert.IsInstanceOfType(result, typeof(RedirectResult));
			Assert.AreEqual("/MyUrl", ((RedirectResult)result).Url);
		}

		[TestMethod]
		public void CannotLogin_WithInvalidCredentials()
		{
			// arrange - create a mock authentication provider
			Mock<IAuthProvider> mock = new Mock<IAuthProvider>();
			mock.Setup(m => m.Authenticate("badUser", "badPass")).Returns(false);

			// arrange - create the view model
			LoginViewModel model = new LoginViewModel
			{
				UserName = "badUser",
				Password = "badPass"
			};

			// arrange - create the controller
			AccountController target = new AccountController(mock.Object);

			// act - authenticate using valid credentials
			ActionResult result = target.Login(model, "/MyUrl");

			// assert
			Assert.IsInstanceOfType(result, typeof(ViewResult));
			Assert.IsFalse(((ViewResult)result).ViewData.ModelState.IsValid);
		}
	}
}
