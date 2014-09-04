using System;
using Common;

namespace Services
{
	public class ServerService : IServerService
	{
		#region IServerService implementation

		void IServerService.Login (User user, Action success, Action<string> failed)
		{
			if (user.Login.Equals("q")) {
				success ();
			} else {
				failed ("error");
			}
		}

		#endregion
	}
}

