using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace App3
{
	public partial class App : Application
	{
        static Gestion_Etudiant database;
        public App ()
		{
            InitializeComponent();
            //var walkthrought=new WalkthroughCarouselPage().Add
            MainPage = new NavigationPage(new Login());
            //MainPage = new NavigationPage(new MenuPage());
            //MainPage=new NavigationPage(new MenuPage());
        }

        public static Gestion_Etudiant Database
        {
            get
            {
                if (database == null)
                {
                    database = new Gestion_Etudiant(DependencyService.Get<ILocalFileHelper>().GetLocalFilePath("Gestion_Etudiant.db3"));
                }
                return database;
            }
        }


        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
