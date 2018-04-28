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
	public partial class Add_Etudiant_Page : ContentPage
	{
        public static String filierename = "";
        public Add_Etudiant_Page ()
		{
			InitializeComponent ();
		}
        public void OnFiliereChosen(object sender, EventArgs args)
        {
            Picker filiere = (Picker)sender;
            filierename = filiere.SelectedItem.ToString();

        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            List<Filiere> list = new List<Filiere>();
            list = await App.Database.GetFilieresAsync();
            foreach (Filiere f in list)
            {
                picker.Items.Add(f.Filierename);
            }

        }
        void Plus_Clicked(object sender, EventArgs e)
        {
            int a = 0;
            a = Convert.ToInt32(abs.Text);
            a++;
            abs.Text = a.ToString();
        }
        void Subs_Clicked(object sender, EventArgs e)
        {
            int a = 0;
            a = Convert.ToInt32(abs.Text);
            if (a > 0)
            {
                a--;
                abs.Text = a.ToString();
            }
            else
            {
                a = 0;
                abs.Text = a.ToString();
            }

        }
        async void Add_Button_Clicked(object sender, EventArgs e)
        {
            Etudiant et = new Etudiant();
            try
            {
                et.Cne = Convert.ToInt32(cne.Text);
            
                Filiere ff=await App.Database.GetFiliereAsync(filierename);
                et.IdFiliere = ff.Id;
                et.Nom = nom.Text;
                et.Prenom = prenom.Text;
                et.Date_naiss = date.Date;
                et.Absence = Convert.ToInt32(abs.Text);
                

                await App.Database.SaveEtudiant(et);
                await Navigation.PopAsync();
            }
            catch (Exception ev)
            {
                Console.WriteLine(ev);
            }
        }
    }
}