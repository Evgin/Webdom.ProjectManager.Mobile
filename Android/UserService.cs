using System;
using Common;

namespace Services
{
	public class UserService : IUserService
	{
		static string LOGIN_KEY = "LOGIN";
		static string PASSWORD_KEY = "PASSWORD";

		#region IUserService implementation

		void IUserService.SaveUser (User user)
		{
			ServiceLocator.SettingsService.SetProperty (LOGIN_KEY, user.Login);
			ServiceLocator.SettingsService.SetProperty (PASSWORD_KEY, user.Password);
		}

		User IUserService.LoadUser ()
		{
			var login = ServiceLocator.SettingsService.GetStringProperty (LOGIN_KEY);
			var password = ServiceLocator.SettingsService.GetStringProperty (PASSWORD_KEY);

			User user = null;
			if (!string.IsNullOrEmpty (login) && !string.IsNullOrEmpty (password)) {
				user = new User (){ Login = login, Password = password };
			}

			return user;
		}

		#endregion
	}
}

