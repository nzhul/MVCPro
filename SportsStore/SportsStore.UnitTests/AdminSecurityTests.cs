using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportsStore.WebUI.Infrastructure.Abstract;
using SportsStore.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
		}
	}
}
