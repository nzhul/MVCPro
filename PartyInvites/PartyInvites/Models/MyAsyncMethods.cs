using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace PartyInvites.Models
{
	public class MyAsyncMethods
	{
		public async static Task<long?> GetPageLength()
		{
			HttpClient client = new HttpClient();

			var httpMessage = await client.GetAsync("http://localhost:60529/");

			// we could do other things here while we are waiting
			// for the HTTP request to complete

			return httpMessage.Content.Headers.ContentLength;
		}

		public static Task<long?> GetPageLengthClassic()
		{
			HttpClient client = new HttpClient();
			var httpTask = client.GetAsync("http://localhost:60529/");

			// we could do other things here while we are waiting
			// for the HTTP request to complete

			return httpTask.ContinueWith((Task<HttpResponseMessage> antecedent) => {
				return antecedent.Result.Content.Headers.ContentLength;
			});
		}
	}
}