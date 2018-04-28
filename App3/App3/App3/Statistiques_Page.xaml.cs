using Microcharts;
using Microcharts.Forms;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Entry = Microcharts.Entry;


namespace App3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Statistiques_Page : ContentPage
    {
        private IEnumerable<Etudiant> ts { get; set; }
        private IEnumerable<Etudiant> tsconseil { get; set; }
        private IEnumerable<Etudiant> tsabs { get; set; }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            List<Filiere> filieres = await App.Database.GetFilieresAsync();
            List<Etudiant> etudiant = await App.Database.GetEtudiantsAsync();

            var listOfEntries = new List<Entry>();
            Byte r = 0, g = 0, b = 0;
            Random rnd = new Random();

            for (int i = 0; i < filieres.Count; i++)
            {
                ts = new Gestion_Etudiant(App.Database.database.GetConnection().DatabasePath).GetEtudiantfiliereconditionAsync(filieres[i].Filierename);

                r = Convert.ToByte(rnd.Next(1, 255));
                g = Convert.ToByte(rnd.Next(1, 255));
                b = Convert.ToByte(rnd.Next(1, 255));
                Color myColor = Color.FromRgb(r, g, b);

                string hex = string.Format("{0:X2}{1:X2}{2:X2}", r, g, b);

                //string hex = myColor.R.ToString("X2") + myColor.G.ToString("X2") + myColor.B.ToString("X2");
                listOfEntries.Add(new Entry(ts.Count())
                {
                    Label = filieres[i].Filierename.ToString(),
                    ValueLabel = ts.Count().ToString(),
                    Color = SKColor.Parse(hex)
                 });

        }




            Entry[] arrayOfEntries = listOfEntries.ToArray();
            /*
             * 
             * 
             * 
             * 
             */

            var listOfEntriesconseil = new List<Entry>();
            Byte rr = 0, gg = 0, bb = 0;
            Random rndd = new Random();

            for (int i = 0; i < filieres.Count; i++)
            {
                tsconseil = new Gestion_Etudiant(App.Database.database.GetConnection().DatabasePath).GetEtudiantfiliereconditionConseilAsync(filieres[i].Filierename);

                rr = Convert.ToByte(rndd.Next(1, 255));
                gg = Convert.ToByte(rndd.Next(1, 255));
                bb = Convert.ToByte(rndd.Next(1, 255));
                Color myColorr = Color.FromRgb(rr, gg, bb);

                string hexa = string.Format("{0:X2}{1:X2}{2:X2}", rr, gg, bb);

                //string hex = myColor.R.ToString("X2") + myColor.G.ToString("X2") + myColor.B.ToString("X2");
                listOfEntriesconseil.Add(new Entry(tsconseil.Count())
                {
                    Label = filieres[i].Filierename.ToString(),
                    ValueLabel = tsconseil.Count().ToString(),
                    Color = SKColor.Parse(hexa)
                });

            }




            Entry[] arrayOfEntriesconseil = listOfEntriesconseil.ToArray();

            //var entries = new[]{

            //    new Entry(200)
            //    {
            //        Label = "January",
            //        ValueLabel = "200",
            //        Color = SKColor.Parse("#266489")
            //    },
            //    new Entry(400)
            //    {
            //        Label = "February",
            //        ValueLabel = "400",
            //        Color = SKColor.Parse("#68B9C0")
            //    },
            //    new Entry(-100)
            //    {
            //        Label = "March",
            //        ValueLabel = "-100",
            //        Color = SKColor.Parse("#90D585")
            //    }
            //};
            var listOfEntriesAbs = new List<Entry>();
            Byte rrr = 0, ggg = 0, bbb = 0;
            Random rnddd = new Random();

            for (int i = 0; i < etudiant.Count; i++)
            {
                tsabs = await App.Database.GetEtudiantsAsync();

                rrr = Convert.ToByte(rnddd.Next(1, 255));
                ggg = Convert.ToByte(rnddd.Next(1, 255));
                bbb = Convert.ToByte(rnddd.Next(1, 255));
                Color myColorrr = Color.FromRgb(rrr, ggg, bbb);

                string hexaa = string.Format("{0:X2}{1:X2}{2:X2}", rrr, ggg, bbb);

                //string hex = myColor.R.ToString("X2") + myColor.G.ToString("X2") + myColor.B.ToString("X2");
                listOfEntriesAbs.Add(new Entry(tsabs.ElementAt(i).Absence)
                {
                    Label = tsabs.ElementAt(i).Nom,
                    ValueLabel = tsabs.ElementAt(i).Absence.ToString(),
                    Color = SKColor.Parse(hexaa)
                });

            }




            Entry[] arrayOfEntriesAbs = listOfEntriesAbs.ToArray();



            /*
             * 
             * 
             * 
             * 
             */






            //var chart = new BarChart() { Entries = entries };

            this.chartView1.Chart = new DonutChart() { Entries = arrayOfEntries };


            //this.chartView2.Chart = new PointChart() { Entries = arrayOfEntries };
            this.chartView2.Chart = new LineChart() { Entries = arrayOfEntriesconseil };
            this.chartView3.Chart = new LineChart() { Entries = arrayOfEntriesAbs };
            //this.chartView5.Chart = new RadarChart() { Entries = arrayOfEntries };
            
        }

        public Statistiques_Page ()
		{
			InitializeComponent ();
            this.Icon = "analytics.png";
        }
	}
}