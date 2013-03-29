using System.Net.Http;
using System.Web.Http;

namespace WebApi.SelfHost
{
	public class TestController : ApiController
	{
		private static byte[] buffer;

		static TestController()
		{
			buffer = new byte[512 * 1024];
			for (int i = 0; i < buffer.Length; i++)
			{
				buffer[i] = (byte)'a';
			}
		}

		public HttpResponseMessage Get()
		{
			HttpResponseMessage response = Request.CreateResponse();

			response.Content = new PushStreamContent((outputStream, httpContent, transportContext) =>
			{
				try
				{
					int size = buffer.Length / 16;
					var wrote = 0;
					for (int i = 0; i < 16; i++)
					{
						outputStream.Write(buffer, wrote, size);
						wrote += size;
					}
				}
				finally
				{
					outputStream.Close();
				}
			});

			return response;
		}
	}
}
