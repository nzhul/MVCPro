using System.Collections.Generic;

namespace PartyInvites.Models
{
	public interface IValueCalculator
	{
		decimal ValueProducts(IEnumerable<Product> products);
	}
}