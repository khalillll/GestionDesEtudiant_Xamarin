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
	public partial class Filiere_Page : ContentPage
	{
		public Filiere_Page ()
		{
			InitializeComponent ();
		}
        private void Modify_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Modifier_Filiere_Page());
        }
    }
}