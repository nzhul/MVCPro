using ControllersAndActions.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;

namespace ControllersAndActions.Tests
{
	[TestClass]
	public class ActionTests
	{
		[TestMethod]
		public void ViewSelectionTest()
		{
			// arrange - create the controller
			ExampleController target = new ExampleController();

			// act - call the action method
			ViewResult result = target.Index();

			// assert - check the result
			Assert.AreEqual("HomePage", result.ViewName);
		}
	}
}
