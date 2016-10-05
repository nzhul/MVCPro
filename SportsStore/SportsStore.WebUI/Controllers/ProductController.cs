using SportsStore.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.WebUI.Controllers
{
	public class ProductController : Controller
	{
		private IProductRepository repository;
		public int PageSize = 4;

		public ProductController(IProductRepository productRepository)
		{
			this.repository = productRepository;
		}

		public ViewResult List(int page = 1)
		{
			return View(this.repository.Products
				.OrderBy(p => p.ProductID)
				.Skip((page - 1) * PageSize)
				.Take(PageSize));
		}
	}
}