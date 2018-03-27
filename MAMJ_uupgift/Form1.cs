using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Windows.Forms.DataVisualization.Charting;

namespace MAMJ_uupgift
{
    public partial class Form1 : Form
    {
        SqlConnection conn = new SqlConnection();
        private Country valCountrySaintLucia;
        private Country valCountrySpanien;
        private Country valCountryUsa;
        private Country valCountryPortugal;
        private Country valCountryAustralia;
        private Country valCountryBrazil;
        private Country valCountrySriLanka;
        private Country valCountryEngland;
        private Country valCountryFrankrike;
        private Country valCountryItalien;


        public Form1()
           
        {
            InitializeComponent();
            conn.ConnectionString = "Data Source=DESKTOP-82O043O\\KURS6;Initial Catalog=Projekt_airbnb;Integrated Security=True";
        }

        /// <summary> <c>GetData</c>
        /// is a method returning a list of Accomodations from an SQL-table with existing connection "conn" </summary>
        /// <param name="myCountry"> Must be a name from an existing table in the SQL database "conn"
        /// with tables matching the values in the class Accomodation</param>
        /// <seealso cref="Accomodation">
        /// An established class based on the values from the AirBnB-database. </seealso>
        /// <returns> A list containing all rows from the SQL-table "myCountry" </returns>
        private List<Accomodation> GetData(string myCountry)
        {



            List<Accomodation> accomodationsList = new List<Accomodation>();


            try
            {
                conn.Open();

                SqlCommand myQuery = new SqlCommand("SELECT * FROM " + myCountry + ";", conn);
                SqlDataReader myReader = myQuery.ExecuteReader();

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

                // string letMS;
                string letLat;
                string letLong;

                while (myReader.Read())
                {
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
                conn.Close();
            }

            return accomodationsList;

        }

        /// <summary>
        /// Uses <c>GetData</c> multiple time to set the Accomodation list for varius Country-objects.
        /// </summary>
        private void CountryData()
        {
            
            List<Accomodation> saintLuciaList = GetData("Saint_Lucia");
            Country SaintLucia1 = new Country("Saint_Lucia", 0, 0, saintLuciaList);
            List<Accomodation> spanienList = GetData("Spanien");
            Country Spanien1 = new Country("Spanien", 0, 0, spanienList);
            List<Accomodation> usaList = GetData("Usa");
            Country Usa1 = new Country("Usa", 0, 0, usaList);
            List<Accomodation> portugalList = GetData("Portugal");
            Country Portugal1 = new Country("Portugal", 0, 0, portugalList);
            List<Accomodation> australiaList = GetData("Australia");
            Country Australia1 = new Country("Australia", 0, 0, australiaList);
            List<Accomodation> brazilList = GetData("Brazil");
            Country Brazil1 = new Country("Brazil", 0, 0, brazilList);
            List<Accomodation> sriLankaList = GetData("Sri_Lanka");
            Country SriLanka1 = new Country("Sri_Lanka", 0, 0, sriLankaList);
            List<Accomodation> englandList = GetData("England");
            Country England1 = new Country("England", 0, 0, englandList);
            List<Accomodation> frankrikeList = GetData("Frankrike");
            Country Frankrike1 = new Country("Frankrike", 0, 0, frankrikeList);
            List<Accomodation> italienList = GetData("Italien");
            Country Italien1 = new Country("Italien", 0, 0, italienList);


            valCountrySaintLucia = SaintLucia1;
            valCountrySpanien = Spanien1;
            valCountryUsa = Usa1;
            valCountryPortugal = Portugal1;
            valCountryBrazil = Brazil1;
            valCountrySriLanka = SriLanka1;
            valCountryEngland = England1;
            valCountryFrankrike = Frankrike1;
            valCountryItalien = Italien1;
            valCountryAustralia = Australia1;
    }
        private void plotchartSaintLucia()
        {
            List<Accomodation> scatterList = valCountrySaintLucia.Accommodates;

            var spridning = from f in scatterList
                            where f.Room_type == "Entire home/apt"
                            select new { f.Price };
            foreach (var b in spridning)
            {
                chart1.Series["Series1"].Points.AddY(b.Price);
            }
            chart1.Series["Series1"].ChartType = SeriesChartType.Column;
        }
        private void plotchartSpanien()
        {
            List<Accomodation> scatterList = valCountrySpanien.Accommodates;

            var spridning = from f in scatterList
                            where f.Room_type == "Entire home/apt"
                            select new { f.Price };
            foreach (var b in spridning)
            {
                chart2.Series["Series1"].Points.AddY(b.Price);
            }
            chart2.Series["Series1"].ChartType = SeriesChartType.Column;
        }
        private void plotchartUsa()
        {
            List<Accomodation> scatterList = valCountryUsa.Accommodates;

            var spridning = from f in scatterList
                            where f.Room_type == "Entire home/apt"
                            select new { f.Price };
            foreach (var b in spridning)
            {
                chart3.Series["Series1"].Points.AddY(b.Price);
            }
            chart3.Series["Series1"].ChartType = SeriesChartType.Column;
        }
        private void plotchartPortugal()
        {
            List<Accomodation> scatterList = valCountryPortugal.Accommodates;

            var spridning = from f in scatterList
                            where f.Room_type == "Entire home/apt"
                            select new { f.Price };
            foreach (var b in spridning)
            {
                chart4.Series["Series1"].Points.AddY(b.Price);
            }
            chart4.Series["Series1"].ChartType = SeriesChartType.Column;
        }
        private void plotchartBrazil()
        {
            List<Accomodation> scatterList = valCountryBrazil.Accommodates;

            var spridning = from f in scatterList
                            where f.Room_type == "Entire home/apt"
                            select new { f.Price };
            foreach (var b in spridning)
            {
                chart5.Series["Series1"].Points.AddY(b.Price);
            }
            chart5.Series["Series1"].ChartType = SeriesChartType.Column;
        }
        private void plotchartSriLanka()
        {
            List<Accomodation> scatterList = valCountrySriLanka.Accommodates;

            var spridning = from f in scatterList
                            where f.Room_type == "Entire home/apt"
                            select new { f.Price };
            foreach (var b in spridning)
            {
                chart6.Series["Series1"].Points.AddY(b.Price);
            }
            chart6.Series["Series1"].ChartType = SeriesChartType.Column;
        }
        private void plotchartEngland()
        {
            List<Accomodation> scatterList = valCountryEngland.Accommodates;

            var spridning = from f in scatterList
                            where f.Room_type == "Entire home/apt"
                            select new { f.Price };
            foreach (var b in spridning)
            {
                chart7.Series["Series1"].Points.AddY(b.Price);
            }
            chart7.Series["Series1"].ChartType = SeriesChartType.Column;
        }
        private void plotchartFrankrike()
        {
            List<Accomodation> scatterList = valCountryFrankrike.Accommodates;

            var spridning = from f in scatterList
                            where f.Room_type == "Entire home/apt"
                            select new { f.Price };
            foreach (var b in spridning)
            {
                chart8.Series["Series1"].Points.AddY(b.Price);
            }
            chart8.Series["Series1"].ChartType = SeriesChartType.Column;
        }
        private void plotchartItalien()
        {
            List<Accomodation> scatterList = valCountryItalien.Accommodates;

            var spridning = from f in scatterList
                            where f.Room_type == "Entire home/apt"
                            select new { f.Price };
            foreach (var b in spridning)
            {
                chart9.Series["Series1"].Points.AddY(b.Price);
            }
            chart9.Series["Series1"].ChartType = SeriesChartType.Column;
        }
        private void plotchartAustralien()
        {
            List<Accomodation> scatterList = valCountryAustralia.Accommodates;

            var spridning = from f in scatterList
                            where f.Room_type == "Entire home/apt"
                            select new { f.Price };
            foreach (var b in spridning)
            {
                chart10.Series["Series1"].Points.AddY(b.Price);
            }
            chart10.Series["Series1"].ChartType = SeriesChartType.Column;
        }

        /// <summary>
        /// Load windows form with charts based on AirBnB data
        /// </summary>
        /// <param name="sender"> I dont know C# that well, probobly possible starting arguments</param>
        /// <param name="e">Could be something</param>
        private void Form1_Load(object sender, EventArgs e)
        {
            CountryData();
            plotchartSaintLucia();
            plotchartSpanien();
            plotchartUsa();
            plotchartPortugal();
            plotchartItalien();
            plotchartSriLanka();
            plotchartAustralien();
            plotchartEngland();
            plotchartFrankrike();
            plotchartBrazil();
        }

        private void chart3_Click(object sender, EventArgs e)
        {

        }

        private void chart4_Click(object sender, EventArgs e)
        {

        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
