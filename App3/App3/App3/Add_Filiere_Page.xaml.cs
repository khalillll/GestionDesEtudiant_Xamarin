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
	public partial class Add_Filiere_Page : ContentPage
	{
		public Add_Filiere_Page ()
		{
			InitializeComponent ();
		}
        async void Add_Button_Clicked(object sender, EventArgs e)
        {

            try
            {
                Filiere filiere = new Filiere
                {
                    Filierename = nom_filiere.Text
                };


                await App.Database.AddFiliere(filiere);
                await Navigation.PopAsync();
            }
            catch (Exception ev)
            {
                Console.WriteLine(ev);
            }
        }
    }
}