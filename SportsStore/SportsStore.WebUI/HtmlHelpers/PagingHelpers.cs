using SportsStore.WebUI.Models;
using System;
using System.Text;
using System.Web.Mvc;

namespace SportsStore.WebUI.HtmlHelpers
{
	public static class PagingHelpers
	{
		public static MvcHtmlString PageLinks(this HtmlHelper html, PagingInfo paginfInfo, Func<int, string> pageUrl)
		{
			StringBuilder result = new StringBuilder();
			for (int i = 1; i <= paginfInfo.TotalPages; i++)
			{
				TagBuilder tag = new TagBuilder("a");
				tag.MergeAttribute("href", pageUrl(i));
				tag.InnerHtml = i.ToString();
				if (i == paginfInfo.CurrentPage)
				{
					tag.AddCssClass("selected");
				}

				result.Append(tag.ToString());
			}

			return MvcHtmlString.Create(result.ToString());
		}
	}
}