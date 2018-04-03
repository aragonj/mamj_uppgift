﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;//API som kopplar till SQL
using System.Windows.Forms.DataVisualization.Charting;//API som kopplar till windows forms
using GMap.NET;
using GMap.NET.MapProviders;
using System.Diagnostics;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;//APIer till Gmap


namespace MAMJ_uupgift
{
    //klass för windows form
    public partial class Form1 : Form
    {
        // Strings representing SQL querries, used in conjunction with <c>TopList<c>
        //uträkningar som sker i SQL, presenteras i "best ranking" via kategorierna cheapst, value, best
        //vart är knapparna kodade?
        // skapar 3 variabler, strängarna används senare
        string nyttomaximering = "select top 10 (overall_satisfaction/price) as nyttomaximering, price, latitude, longitude from COUNTRY where accommodates = NUMBER and overall_satisfaction != 0 ORDER BY nyttomaximering DESC";
        string best = "select top 10 overall_satisfaction, price, latitude, longitude from COUNTRY where accommodates = NUMBER and overall_satisfaction != 0 ORDER BY price ASC";
        string cheap = "select top 10 overall_satisfaction, price, latitude, longitude from COUNTRY where accommodates = NUMBER and overall_satisfaction != 0 ORDER BY overall_satisfaction ASC, price DESC";

        //skapar object
        SqlConnection conn = new SqlConnection();
        //skapar en country lista med namnet world 
        private List<Country> world = new List<Country>();
        private string ChoicePercountry;

        // String list of country names with tables in our database
        List<string> countries = new List<string>()
        {
            "Saint_Lucia",
            "Spanien",
            "Usa",
            "Portugal",
            "Australia",
            "Brazil",
            "Sri_Lanka",
            "England",
            "Frankrike",
            "Italien"
        };

        //inkallar vår Metod Form1()
        public Form1()
        {
            InitializeComponent();
            //connectionstring for local database, need to be changed for every user, conn är ett naman på ett object, 
            //ConnectionString är en variabel i objectet conn
            conn.ConnectionString = "Data Source=VAIO\\SQL2017;Initial Catalog=Projekt_airbnb;Integrated Security=True";
        }

        /// <summary>
        /// Creates a list of Accommodations from a table in a SQL-database with connection "conn"
        /// </summary>
        /// <param name="myCountry">Must be the name of a table on SQL-server "conn" with variables from AirBnB data</param>
        /// <returns>a list of accommodations</returns>
        private List<Accomodation> GetData(string myCountry)
        {
            List<Accomodation> accomodationsList = new List<Accomodation>();
            
            try
            {
                // conn har egenskaper som defineras tidigare, men körs först här. open är en metod som tillhör SQLconnectionkalssen
                conn.Open();

                SqlCommand myQuery = new SqlCommand("SELECT * FROM " + myCountry + ";", conn);
                SqlDataReader myReader = myQuery.ExecuteReader();

                //definerar variabler som kommer från början fyllas med värden ifrån alla country,
                //men sorteras ut under runtime via övrig kod
                int Room_id;
                int Host_id;
                string Room_type;
                string Borough;
                string Neighborhood;
                int Reviews;
                double Overall_Satisfaction;
                int Bedrooms;
                int Accommodates;
                double Price;
                double Latitude;
                double Longitude;
                string Last_modified; string letOS; // tillfälliga strängar som sedan konverteras till double
                string letBed;
                string letPrice;
                string letLat;
                string letLong;

                //wihle loop som kör igenom SQL datasetet
                while (myReader.Read())
                {
                    //definerar vad SQL datans datatyper skall bli i vår C# kod
                    //room_id har bara ett värde åt gången
                    Room_id = (int)myReader["Room_id"];
                    Host_id = (int)myReader["Host_id"];
                    Room_type = (string)myReader["Room_type"];
                    Borough = myReader["Borough"].ToString();
                    Neighborhood = myReader["Neighborhood"].ToString();
                    Reviews = (int)myReader["reviews"];
                    letOS = myReader["Overall_Satisfaction"].ToString();
                    Overall_Satisfaction = double.Parse(letOS);
                    letBed = myReader["Bedrooms"].ToString();
                    Bedrooms = int.Parse(letBed);
                    Accommodates = (int)myReader["Accommodates"];
                    letPrice = myReader["Price"].ToString();
                    Price = double.Parse(letPrice);
                    bool MinstayTest = int.TryParse(Convert.ToString(myReader["Minstay"]), out int Minstay);
                    if (MinstayTest == false)
                    {
                        Minstay = 0;
                    }
                    letLat = myReader["Latitude"].ToString();
                    Latitude = double.Parse(letLat);
                    letLong = myReader["Longitude"].ToString();
                    Longitude = double.Parse(letLong);
                    Last_modified = myReader["Last_modified"].ToString();
                    
                    Accomodation accomodations = new Accomodation(
                        //varje variabel nedan har nu värdet av en rad ifrån SQL databasen
                        Room_id,
                        Host_id,
                        Room_type,
                        Borough,
                        Neighborhood,
                        Reviews,
                        Overall_Satisfaction,
                        Accommodates,
                        Bedrooms,
                        (int)Price,
                        Minstay,
                        Latitude,
                        Longitude,
                        Last_modified);
                    accomodationsList.Add(accomodations);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                //stänger ner anslutningen till SQL servern
                conn.Close();
            }
            //metoden getdata, hämtar data ifrån SQL servern, getdata är klar
            return accomodationsList;
        }
        //getdata avslutas här

        /// <summary>
        /// Poppulates a country list with countries filled with accommodations based on a databas from
        /// <c>GetData</c> using a list of contrynames 
        /// </summary>
        /// <param name="countries">A string list with names that must be valid table names</param>
        /// en metod som heter Countrydata, argument= vilka värden som skickas med metoden
        /// list<string> countries inneh
        private void CountryData(List<string> countries)
        {
            foreach(string element in countries)
                //10 obeject i countries 
            {
                //hus innehåller alla accomodations från tabellen element 
                List<Accomodation> hus = GetData(element);
                Country temp = new Country(element, 0, 0, hus);

                //temp adderas i listan world, sk få 10 object i listan world
                world.Add(temp);
            }
            
        }
        /// <summary>
        /// Uses data from an SQL-server to plot a chart named "AveragePrice" with diffrent statistics
        /// based on a dropdown menue.
        /// </summary>
        private void ChartPerCountry()
        {
            //nament på charten.ifrån serien countries. ska irensa data, clear 
            //obejct som innehållar object som innehåller object. som clear är en metod 
            //vi tömmer data points och titlar på charten
            AveragePrice.Series["Countries"].Points.Clear();
            AveragePrice.Titles.Clear();

            
            if (ChoicePercountry == "AOS")
                //rad 240
            {
                foreach (Country x in world)
                    //x är ett country object typ spaninen i listan world
                {
                    AveragePrice.Series["Countries"].Points.AddXY(x.CountryNamn, x.AverageOverall_satisfaction);
                    //x är lokalt ej samma som i country 
                }
                AveragePrice.Series["Countries"].ChartType = SeriesChartType.RangeColumn;
                AveragePrice.Titles.Add("Average Overall Satisfaction Per Country");
            }

            else if (ChoicePercountry == "APPC")
            {
                foreach (Country x in world)
                {

                    AveragePrice.Series["Countries"].Points.AddXY(x.CountryNamn, x.AveragePrice);
                    //x.AveragePrice hämtas ifrån contry, som räknar ut AVG ifrån vädert price ifrån accomodation
                }
                AveragePrice.Series["Countries"].ChartType = SeriesChartType.RangeColumn;
                AveragePrice.Titles.Add("Average Price Per Country");
            }
            else if (ChoicePercountry == "AOLPC")
            {
                foreach (Country x in world)
                {

                    AveragePrice.Series["Countries"].Points.AddXY(x.CountryNamn, x.CountListings);
                }
                AveragePrice.Series["Countries"].ChartType = SeriesChartType.RangeColumn;
                AveragePrice.Titles.Add("Amount Listings Per Country");

            }
            else { }
        }
        
        // Initiate startvalues for this windows.form project
        private void Form1_Load(object sender, EventArgs e)
        {
            // Start values for GMaps
            karta.MapProvider = GMapProviders.GoogleMap;
            karta.DragButton = MouseButtons.Left;
            karta.Position = new GMap.NET.PointLatLng(59.3452809, 18.0212366);//Nackademin coordinates
            karta.MinZoom = 1;
            karta.MaxZoom = 100;
            karta.Zoom = 11;
            
            // Initiate  Values for Dropdown boxes
            CountryData(countries);
            AveragePrice.ChartAreas["ChartArea1"].AxisX.Interval = 1;
            comboBox1.Items.Add("Average Overall Satisfaction Per Country");
            comboBox1.Items.Add("Average Price Per Country");
            comboBox1.Items.Add("Amount Of Listing Per Country");
            foreach(string country in countries)
            {
                comboBox2.Items.Add(country);
                //dropdownen för maps som visar länder
            }
            for (int y = 1; y < 16; y++)
            {
                comboBox3.Items.Add(y.ToString());
            }
        }

        // Plot some charts, IF satas som väljs i dropdown listan vid "KPI Charts"
        //ny metod
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Average Overall Satisfaction Per Country")
            {
                ChoicePercountry="AOS";
                ChartPerCountry();
                AveragePrice.ChartAreas[0].AxisY.Maximum = 4.9;//val av intervall på graf
                AveragePrice.ChartAreas[0].AxisY.Minimum = 4.5;//val av intervall på graf

                // Gör att länderna får olika färger
                AveragePrice.Series["Countries"].Points[0].Color = Color.FromArgb( 52, 52, 119);
                AveragePrice.Series["Countries"].Points[1].Color = Color.FromArgb(47, 65, 114);
                AveragePrice.Series["Countries"].Points[2].Color = Color.FromArgb(40, 70, 110);
                AveragePrice.Series["Countries"].Points[3].Color = Color.FromArgb(38, 89, 106);
                AveragePrice.Series["Countries"].Points[4].Color = Color.FromArgb(39,117,84);
                AveragePrice.Series["Countries"].Points[5].Color = Color.FromArgb(51,138,46);
                AveragePrice.Series["Countries"].Points[6].Color = Color.FromArgb(101,153,52);
                AveragePrice.Series["Countries"].Points[7].Color = Color.FromArgb(122,159,53);
                AveragePrice.Series["Countries"].Points[8].Color = Color.FromArgb(144,164,55);
                AveragePrice.Series["Countries"].Points[9].Color = Color.FromArgb(166,169,56);

              

            }
            else if (comboBox1.Text == "Average Price Per Country")
            {
                ChoicePercountry= "APPC";
                ChartPerCountry();
                AveragePrice.ChartAreas[0].AxisY.Maximum = Double.NaN;//skapar vi en variabel NaN? vad är NaN 
                AveragePrice.ChartAreas[0].AxisY.Minimum = Double.NaN;
                AveragePrice.ChartAreas[0].RecalculateAxesScale();

                // Gör att länderna får olika färger
                AveragePrice.Series["Countries"].Points[0].Color = Color.FromArgb(52, 52, 119);
                AveragePrice.Series["Countries"].Points[1].Color = Color.FromArgb(47, 65, 114);
                AveragePrice.Series["Countries"].Points[2].Color = Color.FromArgb(40, 70, 110);
                AveragePrice.Series["Countries"].Points[3].Color = Color.FromArgb(38, 89, 106);
                AveragePrice.Series["Countries"].Points[4].Color = Color.FromArgb(39, 117, 84);
                AveragePrice.Series["Countries"].Points[5].Color = Color.FromArgb(51, 138, 46);
                AveragePrice.Series["Countries"].Points[6].Color = Color.FromArgb(101, 153, 52);
                AveragePrice.Series["Countries"].Points[7].Color = Color.FromArgb(122, 159, 53);
                AveragePrice.Series["Countries"].Points[8].Color = Color.FromArgb(144, 164, 55);
                AveragePrice.Series["Countries"].Points[9].Color = Color.FromArgb(166, 169, 56);
            }
            else if (comboBox1.Text == "Amount Of Listing Per Country")
            {
                ChoicePercountry = "AOLPC";
                ChartPerCountry();
                AveragePrice.ChartAreas[0].AxisY.Maximum = Double.NaN;
                AveragePrice.ChartAreas[0].AxisY.Minimum = Double.NaN;
                AveragePrice.ChartAreas[0].RecalculateAxesScale();

                // Gör att länderna får olika färger
                AveragePrice.Series["Countries"].Points[0].Color = Color.FromArgb(52, 52, 119);
                AveragePrice.Series["Countries"].Points[1].Color = Color.FromArgb(47, 65, 114);
                AveragePrice.Series["Countries"].Points[2].Color = Color.FromArgb(40, 70, 110);
                AveragePrice.Series["Countries"].Points[3].Color = Color.FromArgb(38, 89, 106);
                AveragePrice.Series["Countries"].Points[4].Color = Color.FromArgb(39, 117, 84);
                AveragePrice.Series["Countries"].Points[5].Color = Color.FromArgb(51, 138, 46);
                AveragePrice.Series["Countries"].Points[6].Color = Color.FromArgb(101, 153, 52);
                AveragePrice.Series["Countries"].Points[7].Color = Color.FromArgb(122, 159, 53);
                AveragePrice.Series["Countries"].Points[8].Color = Color.FromArgb(144, 164, 55);
                AveragePrice.Series["Countries"].Points[9].Color = Color.FromArgb(166, 169, 56);



            }
            else { }

        }

        // Plot coordinates from Accommodations using a GMaps API
        private void button1_Click(object sender, EventArgs e)
        {
            double xax = 0;
            double yax = 0;
            string statement = Program.CreateStatement(comboBox2.Text, nyttomaximering, comboBox3.Text);
            List<Tuple<double, double>> accs = Program.TopList(statement);
            GMapOverlay markers = new GMapOverlay("markers");
            foreach (Tuple<double, double> element in accs)
            {
                PointLatLng point = new PointLatLng(element.Item1, element.Item2);
                GMapMarker mark = new GMarkerGoogle(point, GMarkerGoogleType.blue_dot);
                markers.Markers.Add(mark);
                xax = xax + element.Item1;
                yax = yax + element.Item2;
            }
            karta.Overlays.Clear();
            karta.Overlays.Add(markers);
            karta.Position = new GMap.NET.PointLatLng((xax/10), (yax/10));

        }

        private void button2_Click(object sender, EventArgs e)
        {
            double xax = 0;
            double yax = 0;
            string statement = Program.CreateStatement(comboBox2.Text, best, comboBox3.Text);
            List<Tuple<double, double>> accs = Program.TopList(statement);
            GMapOverlay markers = new GMapOverlay("markers");
            foreach (Tuple<double, double> element in accs)
            {
                PointLatLng point = new PointLatLng(element.Item1, element.Item2);
                GMapMarker mark = new GMarkerGoogle(point, GMarkerGoogleType.blue_dot);
                markers.Markers.Add(mark);
                xax = xax + element.Item1;
                yax = yax + element.Item2;
            }
            karta.Overlays.Clear();
            karta.Overlays.Add(markers);
            karta.Position = new GMap.NET.PointLatLng((xax / 10), (yax / 10));
        }

        private void button3_Click(object sender, EventArgs e)
            //metod för cheap knappen
        {
            double xax = 0;
            double yax = 0;
            string statement = Program.CreateStatement(comboBox2.Text, cheap, comboBox3.Text);
            
            List<Tuple<double, double>> accs = Program.TopList(statement);
            GMapOverlay markers = new GMapOverlay("markers");
            foreach (Tuple<double, double> element in accs)
                //accs är en lista
            {
                PointLatLng point = new PointLatLng(element.Item1, element.Item2);
                GMapMarker mark = new GMarkerGoogle(point, GMarkerGoogleType.blue_dot);
                markers.Markers.Add(mark);
                xax = xax + element.Item1;
                yax = yax + element.Item2;
            }
            karta.Overlays.Clear();
            karta.Overlays.Add(markers);
            karta.Position = new GMap.NET.PointLatLng((xax / 10), (yax / 10));
        }
        //knappar som får klickfunktioner; vilken är vilekn? 
        //de 3 i högra hörnet och den "översta-chartknappen" till vänster? stämmer det
        private void numberLabel_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            AveragePrice.Visible = false;
        }

        private void hemsida_Click(object sender, EventArgs e)
        {
            MAPPanel.Visible = true;
            KPIPanel.Visible = false;
        }

        private void LinkIn_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://marcusson.biz/youngtravel/youngtravel.html");
        }

        private void FaceBook_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/");
        }

        private void Twitter_Click(object sender, EventArgs e)
        {

            System.Diagnostics.Process.Start("https://twitter.com/?lang=sv");
            
        }

        private void KPICharts_Click(object sender, EventArgs e)
        {
            MAPPanel.Visible = false;
            KPIPanel.Visible = true;
        }
    }
}
