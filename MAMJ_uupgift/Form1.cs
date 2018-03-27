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
        private List<Country> world = new List<Country>();


        public Form1()

        {
            InitializeComponent();
            conn.ConnectionString = "Data Source=JEROME\\SERVER2017; Initial Catalog=Projekt_airbnb; Integrated Security=True";
        }
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

            world.Add(SaintLucia1);
            world.Add(Spanien1);
            world.Add(Usa1);
            world.Add(Portugal1);
            world.Add(Brazil1);
            world.Add(SriLanka1);
            world.Add(England1);
            world.Add(Frankrike1);
            world.Add(Italien1);
            world.Add(Australia1);




        }
        private void AverageOverallSatisfaction()
        {
            foreach (Country x in world)
            {

                chart1.Series["Series1"].Points.AddXY(x.CountryNamn, x.AverageOverall_satisfaction);
            }
            chart1.Series["Series1"].ChartType = SeriesChartType.RangeColumn;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CountryData();
            AverageOverallSatisfaction();


        }


    }
}
