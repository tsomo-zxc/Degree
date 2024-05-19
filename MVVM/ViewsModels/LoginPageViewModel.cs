using Degree.MVVM.Models;
using Degree.MVVM.Views;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Degree.MVVM.ViewsModels
{
    [AddINotifyPropertyChangedInterface]
    public partial class LoginPageViewModel
    {
        private string _username;
        private string _password;

        public string Username
        {
            get => _username;
            set => _username = value;
        }

        public string Password
        {
            get => _password;
            set => _password = value;            
        }

        public ICommand LoginCommand { get; }

        public LoginPageViewModel()
        {
            LoginCommand = new Command(OnLogin);
        }

        private async void OnLogin()
        {
            if (string.IsNullOrWhiteSpace(_username) || string.IsNullOrWhiteSpace(_password))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please enter username and password", "OK");
                return;
            }

            try
            {
                User user = App.UserRepository.GetItem(x => x.Username == _username);
                if (user != null && user.PasswordHash == HashPassword(_password))
                {
                    await Application.Current.MainPage.DisplayAlert("Success", "Login successful", "OK");
                    // Navigate to the main page or dashboard
                   
                    Preferences.Default.Set("IsLoggedIn", true);
                    Preferences.Default.Set("Username", _username);
                    MessagingCenter.Send<object>(this, "UsernameChanged");

                    await Application.Current.MainPage.Navigation.PushAsync(new ProfilePage());
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Invalid username or password", "OK");
                }
                
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
            
        }

        private string HashPassword(string password)
        {
            // Here, implement your hashing logic, e.g., using SHA256 or any other hashing algorithm
            // This is just a placeholder
            return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(password));
        }

        
    }
}
