using ReservRO.Helper;
using ReservRO.Models;
using ReservRO.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ReservRO.ViewModels
{
   public class LogInViewModel     :BaseViewModel
    {
        public INavigation Navigation { get; set; }
        public ICommand LogInCommand { get; set; }
        public ICommand SignUpPageCommand { get; set; }
        public LogInViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            LogInCommand = new Command(async() =>
            {
                if (string.IsNullOrEmpty(_email) || string.IsNullOrEmpty(_password))
                {
                    await App.Current.MainPage.DisplayAlert("Attention", "Enter the credentials", "Ok");
                    return;
                }
                else
                {
                    var db = await Utils.Init();
                    UserModel user =await db.Table<UserModel>().Where(u => u.Email == _email && u.Password==_password).FirstOrDefaultAsync();
                    if (user != null)
                    {
                        string usertype = user.UseType;
                        if (usertype == "Client")
                        {
                            Utils.LogInUser = user;
                            await Navigation.PushAsync(new FlyoutPage1());
                        }
                        else
                        {
                            Utils.LogInUser = user;
                            await Navigation.PushAsync(new FlyoutPageBusiness());
                        }
              
                    }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert("Attention", "User doesn't Exist", "Ok");
                    }
                }
            });
            SignUpPageCommand = new Command(async () =>
              {
                  await Navigation.PushAsync(new SignUpPage());
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
    }
}
