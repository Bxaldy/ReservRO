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
    public partial class BusinessDashBoardPage : ContentPage
    {
        BusinessDashBoardViewModel vm;
        public BusinessDashBoardPage()
        {
            InitializeComponent();
            vm = new BusinessDashBoardViewModel();
            this.BindingContext = vm;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            vm.GetData();
        }
    }
}