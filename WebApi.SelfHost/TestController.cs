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

		public byte[] Get()
		{
			return buffer;
		}
	}
}
