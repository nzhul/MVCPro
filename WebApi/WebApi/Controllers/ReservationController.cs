using System.Collections.Generic;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
	public class ReservationController : ApiController
	{
		IReservationRepository repo = ReservationRepository.getRepository();

		public IEnumerable<Reservation> GetAllReservations()
		{
			return repo.GetAll();
		}

		public Reservation GetReservation(int id)
		{
			return repo.Get(id);
		}

		public Reservation PostReservation(Reservation item)
		{
			return repo.Add(item);
		}

		public bool PutReservation(Reservation item)
		{
			return repo.Update(item);
		}

		public void DeleteReservation(int id)
		{
			repo.Remove(id);
		}
	}
}