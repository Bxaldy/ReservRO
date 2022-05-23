using ReservRO.Helper;
using ReservRO.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ReservRO.ViewModels
{
   public class ManualAppointmentViewModel  :BaseViewModel
    {   public ICommand BookCommand { get; set; }
        public ManualAppointmentViewModel()
        {
            BookCommand = new Command(async () =>
             {
                 string[] inputs = { _selectedDate.ToString(),_selectedTime.ToString(),_fullName,_phone,_description   };
                 foreach(var input in inputs)
                 {
                     if (string.IsNullOrEmpty(input))
                     {
                         await App.Current.MainPage.DisplayAlert("Attention", "Please Select All Fields", "Ok");
                         return;
                     }
                 }
                 AppointmentsModel appointment = new AppointmentsModel();
                 appointment.BusinessName = Utils.LogInUser.FirstName + " " + Utils.LogInUser.LastName;
                 appointment.ClientName = _fullName;
                 appointment.Date = _selectedDate.ToString("dd/MM/yyyy");
                 appointment.Time = _selectedTime.ToString();
                 appointment.PhoneNo = _phone;
                 appointment.Description = _description;
                 var db = await Utils.Init();
                 var isSaved = await db.InsertAsync(appointment);
                 if (isSaved > 0)
                 {
                     await App.Current.MainPage.DisplayAlert("Success", "Appointment Saved Successfully", "Ok");
                     await Application.Current.MainPage.Navigation.PopAsync();
                 }
                 else
                 {
                     await App.Current.MainPage.DisplayAlert("Failure", "Something Went Wrong", "Ok");
                 }
             });
        }
        private DateTime _selectedDate;
        public DateTime SelectedDate
        {
            get => _selectedDate;
            set
            {
                _selectedDate = value;
                OnPropertyChanged("SelectedDate");
            }
        }
        private TimeSpan _selectedTime;
        public TimeSpan SelectedTime
        {
            get => _selectedTime;
            set
            {
                _selectedTime = value;
                OnPropertyChanged("SelectedTime");
            }
        }
        private string _fullName;
        public string FullName
        {
            get => _fullName;
            set
            {
                _fullName = value;
                OnPropertyChanged("FullName");
            }
        }

        private string _phone;
        public string Phone
        {
            get => _phone;
            set
            {
                _phone = value;
                OnPropertyChanged("Phone");
            }
        }
        private string _description;
        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged("Description");
            }
        }

    }
}
