using System;
using Android;
using Services;

namespace Common
{
	public class ServiceLocator
	{

		public static ISettingsService SettingsService {
			get {
				return TinyIoC.TinyIoCContainer.Current.Resolve<ISettingsService> ();
			}
		}

		public static IServerService ServerService { 
			get { 
				return TinyIoC.TinyIoCContainer.Current.Resolve<IServerService> (); 
			} 
		}

		public static IUserService UserService {
			get {
				return TinyIoC.TinyIoCContainer.Current.Resolve<IUserService> (); 
			}
		}

	}
}

