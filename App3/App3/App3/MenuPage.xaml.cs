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
    public partial class MenuPage : MasterDetailPage
    {
        private static Admin adminn;
        public MenuPage()
        {
            InitializeComponent();
            

            adminn = new Admin();
            TabbedPage tp = new TabbedPage()
            {
                Children =
                {
                     new Gestion_des_EtudiantPage(),
                     new Gestion_des_Filiere_Page(),
                     new Statistiques_Page(),
                     new ProfilePage(adminn)
                }
            };
            tp.CurrentPage = tp.Children[0];
            tp.BarBackgroundColor = Color.FromHex("#08adcf");
            Detail = tp;
        }

        public MenuPage(Admin admin)
        {
            adminn = new Admin();
            adminn = admin;
            InitializeComponent();
            TabbedPage tp = new TabbedPage()
            {
                Children =
                {
                     new Gestion_des_EtudiantPage(),
                     new Gestion_des_Filiere_Page(),
                     new Statistiques_Page(),
                     new ProfilePage(adminn)
                }
            };
            tp.CurrentPage = tp.Children[0];
            tp.BarBackgroundColor = Color.FromHex("#08adcf");
            Detail = tp;
        }

        protected override bool OnBackButtonPressed()
        {
            
            Navigation.PushAsync(new MenuPage());
            return base.OnBackButtonPressed();

        }

        private async void Logout_clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Login());
           
        }
        
        private async void Conseil_clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ConseilDPage());

        }
        private void Profil_clicked(object sender, EventArgs e)
        {
            TabbedPage tp = new TabbedPage()
            {
                Children =
                {
                     new Gestion_des_EtudiantPage(),
                     new Gestion_des_Filiere_Page(),
                     new Statistiques_Page(),
                     new ProfilePage(adminn)
                }
            };
            tp.CurrentPage = tp.Children[3];
            tp.BarBackgroundColor = Color.FromHex("#08adcf");
            Detail = tp;

            IsPresented = false;
        }
        private void Gestion_etudiant_clicked(object sender, EventArgs e)
        {
            TabbedPage tp = new TabbedPage()
            {
                Children =
                {
                     new Gestion_des_EtudiantPage(),
                     new Gestion_des_Filiere_Page(),
                     new Statistiques_Page(),
                     new ProfilePage(adminn)
                }
            };
            tp.CurrentPage = tp.Children[0];
            tp.BarBackgroundColor = Color.FromHex("#08adcf");
            Detail = tp;

            IsPresented = false;
        }
        private void Gestion_filiere_clicked(object sender, EventArgs e)
        {
            TabbedPage tp = new TabbedPage()
            {
                Children =
                {
                     new Gestion_des_EtudiantPage(),
                     new Gestion_des_Filiere_Page(),
                     new Statistiques_Page(),
                     new ProfilePage(adminn)
                }
            };
            tp.CurrentPage = tp.Children[1];
            tp.BarBackgroundColor = Color.FromHex("#08adcf");
            Detail = tp;
            IsPresented = false;
        }


        private void Stats_clicked(object sender, EventArgs e)
        {
            
            
            TabbedPage tp = new TabbedPage()
            {
                Children =
                {
                     new Gestion_des_EtudiantPage(),
                     new Gestion_des_Filiere_Page(),
                     new Statistiques_Page(),
                     new ProfilePage(adminn)
                }
            };
            tp.CurrentPage = tp.Children[2];
            tp.BarBackgroundColor = Color.FromHex("#08adcf");
            Detail = tp;
            IsPresented = false;
        }
    }
}