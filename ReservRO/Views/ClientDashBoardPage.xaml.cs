using ReservRO.Models;
using ReservRO.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ReservRO.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClientDashBoardPage : ContentPage
    {
        public ClientDashBoardPage()
        {
            InitializeComponent();
            this.BindingContext = new ClientDashBoardViewModel(Navigation);
            
            //List<Day> days = new List<Day>()
            //{
            //  new Day{DayShort="SU"},
            //  new Day{DayShort="MO"},
            //  new Day{DayShort="TU"},
            //  new Day{DayShort="WE"},
            //  new Day{DayShort="TH"},
            //  new Day{DayShort="FR"},
            //  new Day{DayShort="SA"}
            //};
            //dayCollection.ItemsSource = days;
        }
    }
}