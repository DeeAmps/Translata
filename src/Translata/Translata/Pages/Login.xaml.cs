using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Translata.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Login : ContentPage
	{
		public Login ()
		{
			InitializeComponent ();
            //this.InitializeComponent();
            this.BindingContext = this;
            this.IsBusy = false;
		}

        public async void GoToSignUp(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignUp());
        }

        public async void GoToMain(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        public async void UserLogin(object sender, EventArgs e)
        {
            var emialField = LoginEmail.Text;
            var passwordField = LoginPassword.Text;

            if (String.IsNullOrEmpty(emialField))
            {
                ShowAlert("", "Please enter an email");
            }
            else if (String.IsNullOrEmpty(passwordField))
            {
                ShowAlert("", "Please enter a password");
            }
            else if (!IsValidEmail(emialField))
            {
                ShowAlert("", "Please enter a valid Email");
            }
            else
            {
                this.IsBusy = true;
            }
        }

        public async void ShowAlert(string title, string message)
        {
            await DisplayAlert(title, message, "Cancel");
        }

        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}