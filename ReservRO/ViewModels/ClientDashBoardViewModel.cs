using ReservRO.Helper;
using ReservRO.Models;
using ReservRO.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ReservRO.ViewModels
{
   public class ClientDashBoardViewModel :BaseViewModel
    {
        private INavigation Navigation { get; set; }
        public ICommand AppointmentPageCommand { get; set; }
        public ICommand BookCommand { get; set; }
        public ObservableCollection<UserModel> Business { get; set; }
        
        public ClientDashBoardViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            Business = new ObservableCollection<UserModel>();

            AppointmentPageCommand = new Command<UserModel>(async (item) =>
              {
                  var user = item;
                  SelectedUser = user;
                  await Navigation.PushModalAsync(new AppointmentPage(this));
              });
            BookCommand = new Command(async () =>
              {
                  string[] inputs = {_selectedDate.ToString("dd/MM/yyyy"),_selectedTime.ToString() };
                  foreach(var input in inputs)
                  {
                      if (string.IsNullOrEmpty(input))
                      {
                          await App.Current.MainPage.DisplayAlert("Attention", "Please Select the Required Fields", "OK");
                          return;
                      }
                  }
                  AppointmentsModel appointment = new AppointmentsModel();
                  appointment.BusinessName = _selectedUser.FirstName + " " + _selectedUser.LastName;
                  appointment.ClientName = Utils.LogInUser.FirstName + " " + Utils.LogInUser.LastName;
                  appointment.PhoneNo = Utils.LogInUser.Phone;
                  appointment.Date = _selectedDate.ToString("dd/MM/yyyy");
                  appointment.Time = _selectedTime.ToString();
                  appointment.Description = _description;
                  var db = await Utils.Init();
                  var isSaved = await db.InsertAsync(appointment);
                  if (isSaved > 0)
                  {
                      await App.Current.MainPage.DisplayAlert("Success", "Appointment Saved Successfully","Ok");
                      await Navigation.PopModalAsync();
                  }
                  else
                  {
                      await App.Current.MainPage.DisplayAlert("Failure", "Appointment Not Saved", "Ok");
                  }
              });
            _= GetData();
        }
        private async Task  GetData()
        {
            var db = await Utils.Init();
            var business = await db.Table<UserModel>().Where(u => u.UseType == "Business").ToListAsync();
             foreach(var busi in business)
            {
                Business.Add(busi);
            }

        }
        private UserModel _selectedUser = new UserModel();
        public UserModel SelectedUser
        {
            get => _selectedUser;
            set
            {
                _selectedUser = value;
                OnPropertyChanged("SelectedUser");
            }
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
                OnPropertyChanged("SelectedTimed");
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
