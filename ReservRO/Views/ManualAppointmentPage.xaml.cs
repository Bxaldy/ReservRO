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
    public partial class ManualAppointmentPage : ContentPage
    {
        ManualAppointmentViewModel vm;
        public ManualAppointmentPage()
        {
            InitializeComponent();
            vm = new ManualAppointmentViewModel();
            this.BindingContext = vm;
        }

       
    }
}