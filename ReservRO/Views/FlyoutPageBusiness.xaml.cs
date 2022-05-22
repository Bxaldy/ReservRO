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
    public partial class FlyoutPageBusiness : FlyoutPage
    {
        public FlyoutPageBusiness()
        {
            InitializeComponent();
            FlyoutPage.ListView.ItemSelected += ListView_ItemSelected;
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as FlyoutPageBusinessFlyoutMenuItem;
            if (item == null)
            {
                return;
            }
            else
            {
                if (item.Title == "Log Out")
                {
                    await Navigation.PopAsync();
                }
                if(item.Title=="Add Appointment")
                {
                    await Navigation.PushAsync(new ManualAppointmentPage());
                }
            }
               
           

            //var page = (Page)Activator.CreateInstance(item.TargetType);
            //page.Title = item.Title;

            //Detail = new NavigationPage(page);
            //IsPresented = false;

            FlyoutPage.ListView.SelectedItem = null;
        }
    }
}