using Degree.MVVM.Models;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Degree.MVVM.ViewsModels
{
    [AddINotifyPropertyChangedInterface]
    public class RegistrationPageViewModel
    {
       
            private string _username;
            private string _email;
            private string _password;
            private string _confirmPassword;
            private string _role = "User";

            public string Username
            {
                get => _username;
                set
                {
                    _username = value;
                    
                }
            }

            public string Email
            {
                get => _email;
                set
                {
                    _email = value;
                   
                }
            }

            public string Password
            {
                get => _password;
                set
                {
                    _password = value;
                   
                }
            }

            public string ConfirmPassword
            {
                get => _confirmPassword;
                set
                {
                    _confirmPassword = value;
                   
                }
            }

            public ICommand RegisterCommand { get; }

            public RegistrationPageViewModel()
            {
                RegisterCommand = new Command(OnRegister);
            }

            private async void OnRegister()
            {
                if (!ValidateInputs())
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Invalid input data", "OK");
                    return;
                }

                var user = new User
                {
                    Username = _username,
                    Email = _email,
                    PasswordHash = HashPassword(_password),
                    Role = _role
                };

                try
                {
                    var existingUser =  App.UserRepository.GetItem(x => x.Username == _username);
                    var existingEmail = App.UserRepository.GetItem(x => x.Email == _email);

                    if (existingUser != null || existingEmail != null)
                    {
                        await Application.Current.MainPage.DisplayAlert("Error", "Username or Email already exists", "OK");
                        return;
                    }

                    App.UserRepository.SaveItem(user);
                    await Application.Current.MainPage.DisplayAlert("Success", "User registered successfully", "OK");
                    ClearFields();
                }
                catch (Exception ex)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
                }
            }

            private bool ValidateInputs()
            {
                if (string.IsNullOrWhiteSpace(_username) || string.IsNullOrWhiteSpace(_email) ||
                    string.IsNullOrWhiteSpace(_password) || string.IsNullOrWhiteSpace(_confirmPassword))
                {
                    return false;
                }

                if (!Regex.IsMatch(_email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    return false;
                }

                if (_password != _confirmPassword)
                {
                    return false;
                }

                return true;
            }

            private string HashPassword(string password)
            {
                // Here, implement your hashing logic, e.g., using SHA256 or any other hashing algorithm
                // This is just a placeholder
                return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(password));
            }

            private void ClearFields()
            {
                Username = string.Empty;
                Email = string.Empty;
                Password = string.Empty;
                ConfirmPassword = string.Empty;
            }

           
        }
    }

