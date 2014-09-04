using System;

namespace Common
{
	public interface ISettingsService
	{
		void SetProperty (string key, string val);

		string GetStringProperty (string key) ;

		void SetProperty (string key, bool val);

		bool GetBooleanProperty (string key) ;

		void SetProperty (string key, int val);

		int GetIntProperty (string key) ;
	}
}

