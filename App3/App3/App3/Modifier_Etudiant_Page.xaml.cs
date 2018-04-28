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
    public partial class Modifier_Etudiant_Page : ContentPage
    {
        

        public Modifier_Etudiant_Page()
        {
            InitializeComponent();
        }

        
        
        
        void Plus_Clicked(object sender, EventArgs e)
        {
            int a = 0;
            a  = Convert.ToInt32(abs.Text);
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
        async void Modifier_Button_Clicked(object sender, EventArgs e)
        {

            try
            {
                Filiere ff = new Filiere();

                ff = await App.Database.GetFiliereAsync(picker.SelectedItem.ToString());
                Etudiant ee = new Etudiant()
                {
                    Id = Convert.ToInt32(id.Text),
                    Absence = Convert.ToInt32(abs.Text),
                    Cne = Convert.ToInt32(cne.Text),
                    Date_naiss = date.Date,
                    IdFiliere = ff.Id,
                    Nom = nom.Text,
                    Prenom=prenom.Text
                };
                //ee=  await App.Database.GetEtudiantAsync(Convert.ToInt32(cne.Text));
                //ee.Absence = Convert.ToInt32(abs.Text);
                //ee.Cne = Convert.ToInt32(cne.Text);
                //ee.Nom = nom.Text;
                //ee.Prenom = prenom.Text;
                //ee.Date_naiss = date.Date;
                
                //ll.Text = ee.Absence.ToString();
                
                //ee.IdFiliere = ff.Id;
                await App.Database.database.UpdateAsync(ee);

                await Navigation.PopAsync();
            }catch(Exception exx)
            {
                Console.WriteLine(exx);
                await this.DisplayAlert("Alert", "filiere est obligatoir", "ok");

            }
            


        }

        async void Supprimer_Button_Clicked(object sender, EventArgs e)
        {


            Etudiant ee = await App.Database.GetEtudiantAsync(Convert.ToInt32(cne.Text));


            await App.Database.database.DeleteAsync(ee);

            await Navigation.PopAsync();


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
    }
}