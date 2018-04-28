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
	public partial class Modifier_Admin_Page : ContentPage
	{
		public Modifier_Admin_Page ()
		{
			InitializeComponent ();
		}

        async void Modifier_Button_Clicked(object sender, EventArgs e)
        {
            if (confirmpassword.Text == password.Text)
            {
                Admin aadmin = await App.Database.GetAdminAsync(Convert.ToInt32(id.Text));
                aadmin.Username = username.Text;
                aadmin.Password=password.Text;
                await App.Database.database.UpdateAsync(aadmin);
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Alert", "le nom ou le mot de pass est inconrrct", "ok");
                await Navigation.PushAsync(new MenuPage());
            }
        
            
        }

        async void Supprimer_Button_Clicked(object sender, EventArgs e)
        {


            Admin ee = await App.Database.GetAdminAsync(Convert.ToInt32(id.Text));


            await App.Database.database.DeleteAsync(ee);

            await Navigation.PopAsync();


        }
    }
}