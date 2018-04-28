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
    public partial class Modifier_Filiere_Page : ContentPage
    {
        public Modifier_Filiere_Page()
        {
            InitializeComponent();
        }


        async void Modifier_Button_Clicked(object sender, EventArgs e)
        {

            Filiere f = (Filiere)BindingContext;
            Filiere ee = await App.Database.GetFiliereAsync(f.Id);
            ee.Filierename = filierenom.Text;


            await App.Database.database.UpdateAsync(ee);

            await Navigation.PopAsync();


        }

        async void Supprimer_Button_Clicked(object sender, EventArgs e)
        {

            Filiere ff = (Filiere)BindingContext;
            Filiere ee = await App.Database.GetFiliereAsync(ff.Id);


            await App.Database.database.DeleteAsync(ee);

            await Navigation.PopAsync();


        }
    }
}