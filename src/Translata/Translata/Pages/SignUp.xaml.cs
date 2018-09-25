
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Translata.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SignUp : ContentPage
	{
        private bool _canClose = true;
        

        public SignUp ()
		{
            //var countryList = new List<string>();
            //countryList.Add("Ghana");
            //countryList.Add("Argentina");
            //countryList.Add("USA"); 
            //Country.ItemsSource = countryList;

            NavigationPage.SetHasBackButton(this, false);
            InitializeComponent ();
		}

        protected override bool OnBackButtonPressed()
        {
            if (_canClose)
            {
                ShowExitDialog();
            }
            return _canClose;
        }

        private async void ShowExitDialog()
        {
            var answer = await DisplayAlert("", "Cancel Registration?", "Yes", "No");
            if (answer)
            {
                _canClose = false;
                await Navigation.PopModalAsync();
            }
        }

        public async void Login(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new Login()));
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

        public void NextSignUp(object sender, EventArgs e)
        {
            var firstName = FirstName.Text;
            var lastName = LastName.Text;
            var email = Email.Text;
            var password = Password.Text;
            var confPassword = Password.Text;
            var dob = DateOfBirth.Date;
            //var country = (string)Country.SelectedItem;

            if (String.IsNullOrEmpty(firstName))
            {
                ShowAlert("", "Please enter First Name");
            }
            else if (String.IsNullOrEmpty(lastName))
            {
                ShowAlert("", "Please enter Last Name");
            }
            else if (String.IsNullOrEmpty(email))
            {
                ShowAlert("", "Please enter your email");
            }
            else if (!IsValidEmail(email))
            {
                ShowAlert("", "Please enter a valid email");
            }
            else if (String.IsNullOrEmpty(password))
            {
                ShowAlert("", "Please enter a password");
            }

            else if (password.Length < 6)
            {
                ShowAlert("", "Passwords dont match");
            }
            else if (password != confPassword)
            {
                ShowAlert("", "Passwords dont match");
            }
            else if (!CheckDate(dob, DateTime.Now))
            {
                ShowAlert("", "Must be at least 18 years to sign up");
            }
            //else if (String.IsNullOrEmpty(country))
            //{
            //    ShowAlert("", "Please select your country");
            //}
            else
            {
                ShowAlert("", "Validations complete");
            }
        }

        public bool CheckDate(DateTime date1, DateTime date2)
        {
            return date1.AddYears(-18) < date2;
        }
    }
}