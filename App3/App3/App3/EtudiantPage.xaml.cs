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
	public partial class EtudiantPage : ContentPage
	{
		public EtudiantPage ()
		{
			InitializeComponent ();
		}

        private async void Modify_Clicked(object sender, EventArgs e)
        {
            Etudiant et = new Etudiant();
            et.Cne = Convert.ToInt32(cne);
            et.Nom = nom.ToString();
            et.Prenom = prenom.ToString();
            et.Date_naiss = Convert.ToDateTime(date);
            await Navigation.PushAsync(new Modifier_Etudiant_Page()
            {
                BindingContext = et
            });
        }
    }
}