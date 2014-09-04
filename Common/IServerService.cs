using System;

namespace Common
{
	public interface IServerService
	{
		void Login(User user, Action success, Action<string> failed);
	}
}

