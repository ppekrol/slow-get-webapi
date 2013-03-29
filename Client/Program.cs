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
			//PerformGets("http://localhost:8099"); // self-host
			PerformGets("http://localhost:8098"); // iis express
		}

		private static void PerformGets(string url)
		{
			var client = new HttpClient();
			var buffer = new byte[4 * 1024];

			for (var i = 0; i < 100; i++)
			{
				var watch = Stopwatch.StartNew();
				//var task = client.GetByteArrayAsync(url + "/api/test/");
				//task.Wait();

				var webRequest = WebRequest.Create(url + "/api/test/");
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
	}
}
