
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Common;
using System.Timers;

namespace Android
{
	[Activity (Label = "Работаем")]			
	public class TimerActivity : Activity
	{

		IServerService _serverService;

		TextView _time;

		Button _startBtn;
		Button _finishBtn;

		long _lastTime;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.Timer);

			_serverService = ServiceLocator.ServerService;

			_time = FindViewById<TextView> (Resource.Id.time);

			_startBtn = FindViewById<Button> (Resource.Id.start_work);
			_finishBtn = FindViewById<Button> (Resource.Id.finish_work);

			_startBtn.Click += StartWork;
			_finishBtn.Click += FinishWork;

			UpdateStatus ();
		}

		void UpdateStatus ()
		{

			var status = _serverService.GetStatus ();

			if (!status.IsWorking) {
				SetupNonWork ();
			} else {
				SetupWork ();
			}
		}

		void SetupNonWork ()
		{
			_startBtn.Visibility = ViewStates.Visible;
			_finishBtn.Visibility = ViewStates.Invisible;
			_time.Text = "ПОРАБОТАЕМ?";
		}

		void SetupWork ()
		{
			_startBtn.Visibility = ViewStates.Invisible;
			_finishBtn.Visibility = ViewStates.Visible;
			_time.Text = "00:00";
		}

		void SetupTimer ()
		{
			Timer timer = new Timer ();
			timer.Interval = 1000;
			timer.Elapsed += (object sender, ElapsedEventArgs e) => {
				RunOnUiThread (() => {
					// 
				});
			};
			timer.Enabled = true;
		}

		void StartWork (object sender, EventArgs e)
		{
			SetupWork ();
			SetupTimer (DateTime.Now);
		}

		void FinishWork (object sender, EventArgs e)
		{

		}
	}
}
	