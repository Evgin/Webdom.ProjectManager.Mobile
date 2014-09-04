using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Common;
using Services;

namespace Android
{
	[Application]
	public class ProjectManagerApplication : Application
	{

		public static Context Context{ get; set; }

		public ProjectManagerApplication (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer)
		{
		}

		public override void OnCreate ()
		{
			base.OnCreate ();
			Context = this;

				TinyIoC.TinyIoCContainer.Current.Register<ISettingsService, SettingsService> ();
				TinyIoC.TinyIoCContainer.Current.Register<IServerService, ServerService> ();
				TinyIoC.TinyIoCContainer.Current.Register<IUserService, UserService> ();


		}

	}
}

