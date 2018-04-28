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
    public partial class Menu : MasterDetailPage
    {
        public Menu()
        {
            InitializeComponent();
            Master = new Menu();
            Detail = new Gestion_des_EtudiantPage();
            Title = "dd";

        }

        private void Gestion_etudiant_clicked(object sender, EventArgs e)
        {
            Detail = new Gestion_des_EtudiantPage();
            IsPresented = false;
        }
        private void Gestion_filiere_clicked(object sender, EventArgs e)
        {
            Detail = new Gestion_des_Filiere_Page();
            IsPresented = false;
        }


        private void Stats_clicked(object sender, EventArgs e)
        {
            Detail = new Statistiques_Page();
            IsPresented = false;
        }


    }
}