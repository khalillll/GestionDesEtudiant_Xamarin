using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterAdmin : ContentPage
    {
        public RegisterAdmin()
        {
            InitializeComponent();
        }

        async void Add_Button_Clicked(object sender, EventArgs e)
        {

            try
            {

                if (password.Text == cpassword.Text)
                {
                    Admin admin = new Admin
                    {
                        Username = username.Text,
                        Password = password.Text
                    };

                    await App.Database.Register_Admin(admin);
                    await Navigation.PushAsync(new Gestion_des_EtudiantPage());
                }
            }
            catch (Exception exe)
            {
                Console.WriteLine(exe);
                await this.DisplayAlert("Alert", exe.ToString(), "ok");
                await Navigation.PushAsync(new RegisterAdmin());
            }



        }

    }
}