using System;

namespace Net.Mobidom.Logging
{
	public class Log
	{
		private static string TAG = "Xamarin";

		private static string BuildMessage (object format, params object[] parms)
		{
			string msg = null;
			if (parms.Length > 0) {
				msg = string.Format (ObjectToString (format), parms);
			} else {
				msg = ObjectToString (format);
			}
			return msg;
		}

		public static void Info (string msgFormat, params object[] parms)
		{
			var msg = BuildMessage (msgFormat, parms);
			#if __ANDROID__
			Android.Util.Log.Info (TAG, msg);
			#else
			Console.WriteLine ("INFO " + msg);
			#endif
		}

		public static void Debug (string msgFormat, params object[] parms)
		{
			var msg = BuildMessage (msgFormat, parms);
			#if __ANDROID__
			Android.Util.Log.Debug (TAG, msg);
			#else
			Console.WriteLine ("DEBUG " + msg);
			#endif
		}

		public static void Error (string msgFormat, params object[] parms)
		{
			var msg = BuildMessage (msgFormat, parms);
			#if __ANDROID__
			Android.Util.Log.Error (TAG, msg);
			#else
			Console.WriteLine ("ERROR " + msg);
			#endif
		}

		private static string ObjectToString (object o)
		{
			return o != null ? o.ToString () : "null";
		}
	}
}

