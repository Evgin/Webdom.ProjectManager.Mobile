using System;
using Android.Content;
using Android.Preferences;
using Common;
using Android;

namespace Services
{
	public class SettingsService : ISettingsService
	{
		#region ISettingsService implementation

		static ISharedPreferences prefs;

		static SettingsService ()
		{
			prefs = PreferenceManager.GetDefaultSharedPreferences (ProjectManagerApplication.Context);
		}

		public void SetProperty (string key, string val)
		{
			prefs.Edit ().PutString (key, val).Commit ();
		}

		public string GetStringProperty (string key)
		{
			return prefs.GetString (key, null);
		}

		public void SetProperty (string key, bool val)
		{
			prefs.Edit ().PutBoolean (key, val).Commit ();
		}

		public bool GetBooleanProperty (string key)
		{
			return prefs.GetBoolean (key, false);
		}

		public void SetProperty (string key, int val)
		{
			prefs.Edit ().PutInt (key, val).Commit ();
		}

		public int GetIntProperty (string key)
		{
			return prefs.GetInt (key, 0);
		}

		#endregion
	}
}

