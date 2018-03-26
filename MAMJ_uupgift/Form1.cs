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
        private void CountryData()
        {
            
            List<Accomodation> saintLuciaList = GetData("Saint_Lucia");
            Country SaintLucia1 = new Country("Saint_Lucia", 0, 0, saintLuciaList);
            List<Accomodation> spanienList = GetData("Spanien");
            Country Spanien1 = new Country("Spanien", 0, 0, spanienList);

            valCountrySaintLucia = SaintLucia1;
            valCountrySpanien = Spanien1;


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

        private void Form1_Load(object sender, EventArgs e)
        {
            CountryData();
            plotchartSaintLucia();
            plotchartSpanien()

        }
    }
}
