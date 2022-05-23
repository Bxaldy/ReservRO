using ReservRO.Helper;
using ReservRO.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ReservRO.ViewModels
{
   public class BusinessDashBoardViewModel :BaseViewModel
    {
        public ICommand BackCommand { get; set; }
          public ObservableCollection<AppointmentsModel> Appointments { get; set; }
        public BusinessDashBoardViewModel()
        {
            Appointments = new ObservableCollection<AppointmentsModel>();
            BackCommand = new Command(async () =>
             {

             });
            GetData();
        }
        public async void GetData()
        {
            Appointments.Clear();
            var db = await Utils.Init();
            var appointments = await db.Table<AppointmentsModel>().ToListAsync();
            foreach(var appointment in appointments)
            {
                Appointments.Add(appointment);
            }
        }
    }
}
