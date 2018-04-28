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
	public partial class Gestion_des_Filiere_Page : ContentPage
	{
		public Gestion_des_Filiere_Page ()
		{
			InitializeComponent ();
            this.Icon = "cityhallmajor.png";

            var toolbarItem = new ToolbarItem
            {
                Icon= "plus.png"

            };
            toolbarItem.Clicked += async (sender, e) =>
            {
                await Navigation.PushAsync(new Add_Filiere_Page()
                {
                    BindingContext = new Filiere()
                });
            };
            ToolbarItems.Add(toolbarItem);
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            FiliereList.ItemsSource = await App.Database.GetFilieresAsync();

        }

        async void Filiere_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new Modifier_Filiere_Page() { BindingContext = e.SelectedItem as Filiere });
            }
        }
    }
}