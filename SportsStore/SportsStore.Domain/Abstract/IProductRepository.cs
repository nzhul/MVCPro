using SportsStore.Domain.Entities;
using System.Linq;

namespace SportsStore.Domain.Abstract
{
	public interface IProductRepository
	{
		IQueryable<Product> Products { get; }
	}
}
