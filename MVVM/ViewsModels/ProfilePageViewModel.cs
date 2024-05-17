using Degree.MVVM.Models;
using Degree.MVVM.Services;
using Degree.MVVM.Views;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace Degree.MVVM.ViewsModels
{
    [AddINotifyPropertyChangedInterface]
    public class ProfilePageViewModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        private const string NullValuePlaceholder = "NULL";
        

        private bool _isLoggedIn;

        public bool IsLoggedIn
        {
            get => _isLoggedIn;
            private set
            {
                _isLoggedIn = value;               
            }
        }

        public bool IsLoggedOut => !IsLoggedIn;

        public ICommand NavigateToRegisterCommand { get; }
        public ICommand NavigateToLoginCommand { get; }
        public ICommand LogOutCommand { get; }

        public ProfilePageViewModel()
        {
            LoadProfileData();
            MessagingCenter.Subscribe<object>(this, "UsernameChanged", (sender) => {
                //IsLoggedIn = Preferences.ContainsKey("IsLoggedIn") && Preferences.Get("IsLoggedIn", false);
                LoadProfileData();
            });
            NavigateToRegisterCommand = new Command( async () => await Shell.Current.Navigation.PushAsync(new RegistrationPage()));
            NavigateToLoginCommand = new Command(async () => await Shell.Current.Navigation.PushAsync(new LoginPage()));
            LogOutCommand = new Command(LogOut);

           

        }

        private async void LogOut()
        {
            User user = App.UserRepository.GetItem(x => x.Username == Username);
            Preferences.Default.Set("IsLoggedIn", false);            
            Preferences.Default.Set("Username", NullValuePlaceholder);
            MessagingCenter.Send<object>(this, "UsernameChanged");


            await Shell.Current.Navigation.PushAsync(new ProfilePage());
            IsLoggedIn = false;
        }

        private void LoadProfileData()
        {
            IsLoggedIn = Preferences.Get("IsLoggedIn", false);
            if (IsLoggedIn)
            {
                Username = Preferences.Get("Username","NULL");
                var user = App.UserRepository.GetItem(x => x.Username == Username);
                if (user != null)
                {
                    Email = user.Email;
                }
            }
        }
    }
}
