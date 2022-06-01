using ReservRO.Helper;
using ReservRO.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ReservRO.ViewModels
{
  public  class MyAppointmentsViewModel:BaseViewModel
    {
        public ObservableCollection<AppointmentsModel> MyAppointments { get; set; }
        public MyAppointmentsViewModel()
        {
            MyAppointments = new ObservableCollection<AppointmentsModel>();
            GetMyAppointments();
        }
        private async void GetMyAppointments()
        {
            MyAppointments.Clear();
            var db = await Utils.Init();
            var fullname = Utils.LogInUser.FirstName + " " + Utils.LogInUser.LastName;
            var appointments = await db.Table<AppointmentsModel>().Where(a => a.ClientName ==fullname ).ToListAsync();
            foreach(var appointment in appointments)
            {
                MyAppointments.Add(appointment);
            }
        }
    }
}
