using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

using PatientCheckup.ViewModels;

namespace PatientCheckup
{	
	public partial class LoginPage : ContentPage
	{	

		private LoginViewModel _viewModel;

		public LoginPage ()
		{
			InitializeComponent ();
			_viewModel = new LoginViewModel(Navigation);
			this.BindingContext = _viewModel;
			_viewModel.UserSaved += (s, e) => {
				this.DisplayAlert("User saved!", "The user was saved for future logins.", "OK", null);
			};
			_viewModel.LoginFailed += (s, e) => {
				this.DisplayAlert("Login failed!", "The username and password were not valid.", "OK", null);
			};
		}
	}
}
