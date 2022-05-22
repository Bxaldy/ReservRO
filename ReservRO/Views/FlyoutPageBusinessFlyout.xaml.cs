using ReservRO.Helper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ReservRO.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FlyoutPageBusinessFlyout : ContentPage
    {
        public ListView ListView;

        public FlyoutPageBusinessFlyout()
        {
            InitializeComponent();

            BindingContext = new FlyoutPageBusinessFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        class FlyoutPageBusinessFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<FlyoutPageBusinessFlyoutMenuItem> MenuItems { get; set; }

            public FlyoutPageBusinessFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<FlyoutPageBusinessFlyoutMenuItem>(new[]
                {
                    new FlyoutPageBusinessFlyoutMenuItem { Id = 0, Title = "Add Appointment" },
                    new FlyoutPageBusinessFlyoutMenuItem { Id = 1, Title = "Log Out" },
                    //new FlyoutPageBusinessFlyoutMenuItem { Id = 2, Title = "Page 3" },
                    //new FlyoutPageBusinessFlyoutMenuItem { Id = 3, Title = "Page 4" },
                    //new FlyoutPageBusinessFlyoutMenuItem { Id = 4, Title = "Page 5" },
                });
            }
            public string UserName { get; set; } = Utils.LogInUser.FirstName + " " + Utils.LogInUser.LastName;
            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}