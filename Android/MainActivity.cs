using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Net.Mobidom.Logging;
using Common;

namespace Android
{
	[Activity (Label = "ProjectManager", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{

		User _current;
		bool _isUserSaved;

		EditText _loginET;
		EditText _passwordET;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.Login);

			_loginET = FindViewById<EditText> (Resource.Id.login);
			_passwordET = FindViewById<EditText> (Resource.Id.password);
			FindViewById<Button> (Resource.Id.login_btn).Click += async (object sender, EventArgs e) => {
				Log.Info ("login: '{0}' password: '{1}'", _loginET.Text, _passwordET.Text);
				_current = new User (){ Login = _loginET.Text, Password = _passwordET.Text };
				ServiceLocator.ServerService.Login (_current, LoginSuccess, LoginFailed);
			};

			_current = ServiceLocator.UserService.LoadUser ();
			if (_current != null) {
				Log.Info ("user saved");
				_isUserSaved = true;
				ServiceLocator.ServerService.Login (_current, LoginSuccess, LoginFailed);
			} else {
				Log.Info ("user not saved");
				_isUserSaved = false;
			}
		}

		void LoginSuccess ()
		{
			if (!_isUserSaved) {
				AlertDialog.Builder builder = new AlertDialog.Builder (this);
				builder.SetTitle ("Сохранить?");
				builder.SetMessage ("Сохранить Логин и Пароль?");
				builder.SetPositiveButton ("Да", new EventHandler<DialogClickEventArgs> (delegate(object sender, DialogClickEventArgs e) {
					ServiceLocator.UserService.SaveUser (_current);
					Log.Info ("user saved");
					Next ();
				}));
				builder.SetNegativeButton ("Нет", new EventHandler<DialogClickEventArgs> (delegate(object sender, DialogClickEventArgs e) {
					Next ();
				}));
				builder.Show ();
			}
			Next ();
		}

		void Next ()
		{
			RunOnUiThread (delegate {

			});
		}

		void LoginFailed (string message)
		{
			AlertDialog.Builder builder = new AlertDialog.Builder (this);
			builder.SetTitle ("Ошибка!");
			builder.SetMessage (message);
			builder.SetNeutralButton ("OK", new EventHandler<DialogClickEventArgs> (delegate(object sender, DialogClickEventArgs e) {
				Log.Info ("retry");
				_loginET.Text = "";
				_passwordET.Text = "";
			}));
			builder.Show ();
		}
	}
}


