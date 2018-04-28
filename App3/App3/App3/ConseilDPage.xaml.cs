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
	public partial class ConseilDPage : ContentPage
	{
        private IEnumerable<Etudiant> te { get; set; }
        public ConseilDPage ()
		{
			InitializeComponent ();
		}
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            List<Filiere> p = await App.Database.GetFilieresAsync();
            picker.ItemsSource = p;

            EtudiantListView.ItemsSource = await App.Database.GetConseilAsync();
        }

        public void OnFiliereChosen()
        {
            int ii = picker.SelectedIndex;
            String m = picker.Items[ii].ToString();
            te = new Gestion_Etudiant(App.Database.database.GetConnection().DatabasePath).GetEtudiantfiliereconditionConseilAsync(m);
            EtudiantListView.ItemsSource = te;
        }
    }
}