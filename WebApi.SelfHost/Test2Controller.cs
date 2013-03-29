using System.Net.Http;
using System.Web.Http;

namespace WebApi.SelfHost
{
	public class Test2Controller : ApiController
	{
		private static byte[] buffer;

		static Test2Controller()
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