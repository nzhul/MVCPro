using System;
using System.Web.Mvc;

namespace ControllerExtensibility.Infrastructure
{
	public class CustomActionInvoker : IActionInvoker
	{
		public bool InvokeAction(ControllerContext controllerContext, string actionName)
		{
			if (actionName == "Index")
			{
				controllerContext.HttpContext.Response.Write("This is the output of the Index action");
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}