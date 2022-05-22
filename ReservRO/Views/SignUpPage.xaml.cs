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
    public partial class SignUpPage : ContentPage
    {
        public SignUpPage()
        {
            InitializeComponent();
            this.BindingContext = new SignUpViewModel(Navigation);
        }
        public async void Sign_Up(object sender, EventArgs e)
        {


            string email = EmailNew.Text;
            string password = PasswordNew.Text;
            string lastName = Nume.Text;
            string firstName = Prenume.Text;
            string passwordConfirm = PasswordConfirmation.Text;
            string telefon = Phone.Text;



            string[] inputuri = { email, password, lastName, firstName, passwordConfirm, telefon };

            foreach (string i in inputuri)           //asta mereu sa fie primul altfel isi ia object not set to a refference error
            {
                if (string.IsNullOrEmpty(i))
                {
                    await DisplayAlert("Campuri necompletate", "Atentie, exista campuri necompletate", "OK");
                    return;
                }
            }                                       //

            if (!email.Contains("@"))
            {
                await DisplayAlert("Alert", "Mail-ul nu este valid", "OK");
                return;
            }

            if (password.Length < 8)
            {
                await DisplayAlert("Parola prea scurta", "Parola trebuie sa aiba minim 8 caractere", "OK");
                return;
            }

            if (password != passwordConfirm)
            {
                await DisplayAlert("Confirmare parola", "Parolele nu se potrivesc", "OK");
                return;
            }

            if (TipUtilizare.SelectedIndex == -1)
            {
                await DisplayAlert("Atentie!", "Selecteaza tipul de utilizator", "Ok");
                TipUtilizare.Focus();
                return;
            }
            else
            {
                var utilizator = TipUtilizare.SelectedItem.ToString();
            }


        }
    }
}