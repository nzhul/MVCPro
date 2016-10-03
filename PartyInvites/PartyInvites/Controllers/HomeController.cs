using PartyInvites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace PartyInvites.Controllers
{
	public class HomeController : Controller
	{
		private IValueCalculator calc;

		public HomeController(IValueCalculator calcParam)
		{
			this.calc = calcParam;
		}

		private Product[] array =
			{
				new Product {Name = "Kayak", Price = 275M},
				new Product {Name = "Lifejacket", Price = 48.95M},
				new Product {Name = "Soccer ball", Price = 19.50M},
				new Product {Name = "Corner flag", Price = 34.95M}
			};

		public ActionResult Index()
		{
			ShoppingCart cart = new ShoppingCart(this.calc) { Products = array };
			decimal totalValue = cart.CalculateProductTotal();
			return View(totalValue);
		}

		public ViewResult SumProducts()
		{
			Product[] products = {
				new Product {Name = "Kayak", Category = "Watersports", Price = 275M},
				new Product {Name = "Lifejacket", Category = "Watersports", Price = 48.95M},
				new Product {Name = "Soccer ball", Category = "Soccer", Price = 19.50M},
				new Product {Name = "Corner flag", Category = "Soccer", Price = 34.95M}
			};

			var results = products.Sum(e => e.Price);

			products[2] = new Product { Name = "Stadium", Price = 79600M };

			return View("Result", (object)String.Format("Sum: {0:c}", results));
		}

		public ViewResult FindProductsLinqDotNotation()
		{
			Product[] products = {
				new Product {Name = "Kayak", Category = "Watersports", Price = 275M},
				new Product {Name = "Lifejacket", Category = "Watersports", Price = 48.95M},
				new Product {Name = "Soccer ball", Category = "Soccer", Price = 19.50M},
				new Product {Name = "Corner flag", Category = "Soccer", Price = 34.95M}
			};

			var foundProducts = products.OrderByDescending(e => e.Price)
				.Take(5)
				.Select(e => new {
					e.Name,
					e.Price
				});

			products[2] = new Product { Name = "Stadium", Price = 79600M };

			// create the result
			StringBuilder result = new StringBuilder();
			foreach (var p in foundProducts)
			{
				result.AppendFormat("Price: {0} ", p.Price);
			}

			return View("Result", (object)result.ToString());
		}


		public ViewResult FindProductsLinq()
		{
			Product[] products = {
				new Product {Name = "Kayak", Category = "Watersports", Price = 275M},
				new Product {Name = "Lifejacket", Category = "Watersports", Price = 48.95M},
				new Product {Name = "Soccer ball", Category = "Soccer", Price = 19.50M},
				new Product {Name = "Corner flag", Category = "Soccer", Price = 34.95M}
			};

			var foundProducts = from match in products
								orderby match.Price descending
								select new
								{
									match.Name,
									match.Price
								};

			// create the result
			int count = 0;
			StringBuilder result = new StringBuilder();
			foreach (var p in foundProducts)
			{
				result.AppendFormat("Price: {0} ", p.Price);
				if (++count == 3)
				{
					break;
				}
			}

			return View("Result", (object)result.ToString());
		}

		public ViewResult FindProductsClassic()
		{
			Product[] products = {
				new Product {Name = "Kayak", Category = "Watersports", Price = 275M},
				new Product {Name = "Lifejacket", Category = "Watersports", Price = 48.95M},
				new Product {Name = "Soccer ball", Category = "Soccer", Price = 19.50M},
				new Product {Name = "Corner flag", Category = "Soccer", Price = 34.95M}
			};

			// define the array to hold the results
			Product[] foundProducts = new Product[3];
			// sort the content of the array
			Array.Sort(products, (item1, item2) => { return Comparer<decimal>.Default.Compare(item1.Price, item2.Price); });
			// get the first three items in the array as the results
			Array.Copy(products, foundProducts, 3);

			// create the result
			StringBuilder result = new StringBuilder();
			foreach (Product p in foundProducts)
			{
				result.AppendFormat("Price: {0} ", p.Price);
			}

			return View("Result", (object)result.ToString());
		}

		public ViewResult CreateANonArray()
		{
			var oddsAndEnds = new[]
			{
				new { Name = "MVC", Category = "Pattern"},
				new { Name = "Hat", Category = "Clothing"},
				new { Name = "Apple", Category = "Fruit"}
			};

			StringBuilder result = new StringBuilder();
			foreach (var item in oddsAndEnds)
			{
				result.Append(item.Name).Append(" ");
			}

			return View("Result", (object)result.ToString());
		}

		public ViewResult UseFilterExtensionMethod()
		{
			IEnumerable<Product> products = new ShoppingCart(this.calc)
			{
				Products = new List<Product> {
					new Product {Name = "Kayak", Category = "Watersports", Price = 275M},
					new Product {Name = "Lifejacket", Category = "Watersports",
					Price = 48.95M},
					new Product {Name = "Soccer ball", Category = "Soccer",
					Price = 19.50M},
					new Product {Name = "Corner flag", Category = "Soccer",
					Price = 34.95M}
				}
			};

			//Func<Product, bool> categoryFilter = prod => prod.Category == "Soccer";

			// The same without Lambda
			//Func<Product, bool> categoryFilter = delegate(Product prod)
			//{
			//	return prod.Category == "Soccer";
			//};

			decimal total = 0;
			//foreach (Product prod in products.FilterByCategory("Soccer"))
			//{
			//	total += prod.Price;
			//}

			foreach (Product prod in products.Filter(p => p.Category == "Soccer" && p.Price > 20))
			{
				total += prod.Price;
			}

			return View("Result", (object)String.Format("Total: {0}", total));
		}

		public ViewResult UseExtension()
		{
			IEnumerable<Product> products = new ShoppingCart(this.calc)
			{
				Products = new List<Product> {
				new Product {Name = "Kayak", Price = 275M},
				new Product {Name = "Lifejacket", Price = 48.95M},
				new Product {Name = "Soccer ball", Price = 19.50M},
				new Product {Name = "Corner flag", Price = 34.95M}
				}
			};

			// create and populate an array of Product objects
			Product[] productArray =
			{
				new Product {Name = "Kayak", Price = 275M},
				new Product {Name = "Lifejacket", Price = 48.95M},
				new Product {Name = "Soccer ball", Price = 19.50M},
				new Product {Name = "Corner flag", Price = 34.95M}
			};

			// get the total value of the products in the cart
			decimal cartTotal = products.TotalPrices();
			decimal arrayTotal = productArray.TotalPrices();

			return View("Result", (object)String.Format("Cart Total: {0}, Array Total: {1}", cartTotal, arrayTotal));
		}

		[HttpGet]
		public ActionResult RsvpForm()
		{
			return View();
		}

		[HttpPost]
		public ViewResult RsvpForm(GuestResponse guestResponse)
		{
			if (ModelState.IsValid)
			{
				// TODO: Email response to the party organizer
				return View("Thanks", guestResponse);
			}
			else
			{
				// there is a validation error
				return View();
			}
		}
	}
}