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
    public partial class Gestion_des_EtudiantPage : ContentPage
    {
        private IEnumerable<Etudiant> te { get; set; }
        public Gestion_des_EtudiantPage()
        {
            InitializeComponent();
            this.Icon = "group.png";
            
            var toolbarItem = new ToolbarItem
            {
                Icon = "plus.png"
            };
            toolbarItem.Clicked += async (sender, e) =>
            {
                await Navigation.PushAsync(new Add_Etudiant_Page()
                {
                    BindingContext = new Etudiant()
                });
            };
            ToolbarItems.Add(toolbarItem);
        }
        protected async override void OnAppearing()
        {
            try
            {
                base.OnAppearing();

                List<Filiere> p = await App.Database.GetFilieresAsync();
                picker.ItemsSource = p;
                EtudiantListView.ItemsSource = await App.Database.GetEtudiantsAsync();
            }catch(Exception e)
            {
                Console.WriteLine(e);
                await Navigation.PushAsync(new MenuPage());
               
            }
            
            

        }
        
        public void OnFiliereChosen()
        {
            int ii = picker.SelectedIndex;
            String m = picker.Items[ii].ToString();
            te = new Gestion_Etudiant(App.Database.database.GetConnection().DatabasePath).GetEtudiantfiliereconditionAsync(m);
            EtudiantListView.ItemsSource = te;
        }
        //EtudiantListView.ItemsSource = await App.Database.GetEtudiantfiliereconditionAsync(m);
        //l.Text = Convert.ToString(await App.Database.GetIdd());
        public async void Etudiant_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new Modifier_Etudiant_Page() { BindingContext = e.SelectedItem as Etudiant });
            }
        }
    }
            

    

   
}
