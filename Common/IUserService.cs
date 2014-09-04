using System;

namespace Common
{
	public interface IUserService
	{
		void SaveUser(User user);
		User LoadUser();
	}
}

