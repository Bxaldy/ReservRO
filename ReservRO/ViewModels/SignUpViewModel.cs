using ReservRO.Helper;
using ReservRO.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ReservRO.ViewModels
{
   public class SignUpViewModel   :BaseViewModel
    {
        private INavigation Navigation { get; set; }
        public ICommand SignUpCommand { get; set; }
        public SignUpViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            SignUpCommand = new Command(async () =>
            {
                string[] inputs = { _email, _firstName, _lastName, _password, _confirmPassword, _phone, _userType };
                foreach(var input in inputs)
                {
                    if (string.IsNullOrEmpty(input))
                    {
                        await App.Current.MainPage.DisplayAlert("Attention", "Please Enter the All Required Fields", "Ok");
                        return;
                    }
                        
                }
                if (!_email.Contains("@"))
                {
                    await App.Current.MainPage.DisplayAlert("Attention", "Please Enter a Valid Email", "Ok");
                    return;
                }

                if (_password.Length < 8)
                {
                    await App.Current.MainPage.DisplayAlert("Attention", "Enter Mininum 8 Characters", "Ok");
                    return;
                }

                if (_password != _confirmPassword)
                {
                    await App.Current.MainPage.DisplayAlert("Attention", "Confirm Password is not Correct", "Ok");
                    return;
                }
                UserModel user = new UserModel
                {
                    Email = _email,
                    FirstName = _firstName,
                    LastName = _lastName,
                    Password = _password,
                    Phone = _phone,
                    UseType=_userType
                };
                var db =await Utils.Init();
                int isSaved =await db.InsertAsync(user);
                if (isSaved > 0)
                {
                    await App.Current.MainPage.DisplayAlert("Success", "Sign Up Successfull", "Ok");
                    await Navigation.PopAsync();
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Failure", "Something Went Wrong", "Ok");
                }
                
            });
        }
        private string _email;
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged("Email");
            }
        }
        private string _firstName;
        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                OnPropertyChanged("FirstName");
            }
        }
        private string _lastName;
        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged("LastName");
            }
        }
        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged("Password");
            }
        }
        private string _confirmPassword;
        public string ConfirmPassword
        {
            get => _confirmPassword;
            set
            {
                _confirmPassword = value;
                OnPropertyChanged("ConfirmPassword");
            }
        }
        private string _userType;
        public string UserType
        {
            get => _userType;
            set
            {
                _userType = value;
                OnPropertyChanged("UserType");
            }
        }

        private string _phone;
        public string Phone
        {
            get => _phone;
            set
            {
                _phone = value;
                OnPropertyChanged("UserType");
            }
        }
    }
}
