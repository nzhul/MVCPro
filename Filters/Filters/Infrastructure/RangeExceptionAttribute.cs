using System;
using System.Web.Mvc;

namespace Filters.Infrastructure
{
	public class RangeExceptionAttribute : FilterAttribute, IExceptionFilter
	{
		public void OnException(ExceptionContext filterContext)
		{
			if (!filterContext.ExceptionHandled && filterContext.Exception is ArgumentOutOfRangeException)
			{
				int val = (int)(((ArgumentOutOfRangeException)filterContext.Exception).ActualValue);

				//Info: We can modify the ViewResult that the action return when an exception occurs
				filterContext.Result = new ViewResult
				{
					ViewName = "RangeError",
					ViewData = new ViewDataDictionary<int>(val)
				};

				filterContext.ExceptionHandled = true;

				//filterContext.Result = new RedirectResult("~/Content/RangeErrorPage.html");
				//filterContext.ExceptionHandled = true;
			}
		}
	}
}