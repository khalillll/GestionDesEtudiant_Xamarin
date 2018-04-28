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
	public partial class ProfilePage : ContentPage
	{
        private List<Admin> addmins;
		public ProfilePage (Admin ad)
		{
			InitializeComponent ();
            this.Icon = "user.png";

            addmins = new List<Admin>();
            addmins.Add(ad);
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            AdminListView.ItemsSource = addmins;
        }

        public async void Admin_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new Modifier_Admin_Page() { BindingContext = e.SelectedItem as Admin });
            }
        }
    }
}