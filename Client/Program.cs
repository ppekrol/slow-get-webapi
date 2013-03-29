using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;

namespace Client
{
	public class Program
	{
		public static void Main(string[] args)
		{
			//PerformGetsUsingWebRequest("http://localhost:8099"); // self-host
			PerformGetsUsingWebRequest("http://localhost/WebApi.Web"); // iis

			//PerformGetsUsingHttpClient("http://localhost:8099"); // self-host
			//PerformGetsUsingHttpClient("http://localhost/WebApi.Web"); // iis

			//PerformGetsUsingHttpClientAlt("http://localhost:8099"); // self-host
			//PerformGetsUsingHttpClientAlt("http://localhost/WebApi.Web"); // iis
		}

		private static void PerformGetsUsingWebRequest(string url)
		{
			var buffer = new byte[4 * 1024];

			for (var i = 0; i < 100; i++)
			{
				var webRequest = WebRequest.Create(url + "/api/test/");
				var watch = Stopwatch.StartNew();
				using (var response = webRequest.GetResponse())
				using (var stream = response.GetResponseStream())
				{
					while (stream.Read(buffer, 0, buffer.Length) > 0)
					{
					}
				}

				watch.Stop();
				Console.WriteLine("{0,-3}: {1}", i, watch.ElapsedMilliseconds);
			}
		}

		private static void PerformGetsUsingHttpClient(string url)
		{
			var client = new HttpClient();

			for (var i = 0; i < 100; i++)
			{
				var watch = Stopwatch.StartNew();
				var task = client.GetByteArrayAsync(url + "/api/test/");
				task.Wait();

				watch.Stop();
				Console.WriteLine("{0,-3}: {1}", i, watch.ElapsedMilliseconds);
			}
		}

		private static void PerformGetsUsingHttpClientAlt(string url)
		{
			for (var i = 0; i < 100; i++)
			{
				var client = new HttpClient();

				var watch = Stopwatch.StartNew();
				var task = client.GetByteArrayAsync(url + "/api/test/");
				task.Wait();

				watch.Stop();
				Console.WriteLine("{0,-3}: {1}", i, watch.ElapsedMilliseconds);
			}
		}
	}
}
