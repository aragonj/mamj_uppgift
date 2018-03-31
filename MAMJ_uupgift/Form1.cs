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
using GMap.NET;
using GMap.NET.MapProviders;
using System.Diagnostics;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

namespace MAMJ_uupgift
{
    public partial class Form1 : Form
    {
        // Strings representing SQL querries, used in conjunction with <c>TopList<c>
        string nyttomaximering = "select top QUANTITY (overall_satisfaction/price) as nyttomaximering, price, latitude, longitude from COUNTRY where accommodates = NUMBER and overall_satisfaction != 0 and price != 0 ORDER BY nyttomaximering DESC";
        string best = "select top QUANTITY overall_satisfaction, price, latitude, longitude from COUNTRY where accommodates = NUMBER and overall_satisfaction != 0 ORDER BY price ASC";
        string cheap = "select top QUANTITY overall_satisfaction, price, latitude, longitude from COUNTRY where accommodates = NUMBER and overall_satisfaction != 0 ORDER BY overall_satisfaction ASC, price DESC";

        // When methods connect to a SQL database, this is the string used as a ConnectionString
        static string connectionString = "Data Source=desktop-vrgdf71;Initial Catalog=Projekt_airbnb;Integrated Security=True";
        // Number of Accommondations to be plotted on the map
        int quantity = 15;

        SqlConnection conn = new SqlConnection();
        private List<Country> world = new List<Country>();
        private string ChoicePercountry;

        // String list of country names with tables in our database
        List<string> countries = Program.TablenNames(connectionString);

        public Form1()
        {
            InitializeComponent();
            //connectionstring for local database, need to be changed for every user
            conn.ConnectionString = connectionString; //"Data Source=desktop-vrgdf71;Initial Catalog=Projekt_airbnb;Integrated Security=True";
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

        /// <summary>
        /// Poppulates a country list with countries filled with accommodations based on a databas from
        /// <c>GetData</c> using a list of contrynames 
        /// </summary>
        /// <param name="countries">A string list with names that must be valid table names</param>
        private void CountryData(List<string> countries)
        {
            foreach(string element in countries)
            {
                List<Accomodation> hus = GetData(element);
                Country temp = new Country(element, 0, 0, hus);
                world.Add(temp);
            }
            
        }
        /// <summary>
        /// Uses data from an SQL-server to plot a chart named "AveragePrice" with diffrent statistics
        /// based on a dropdown menue.
        /// </summary>
        private void ChartPerCountry()
        {
            AveragePrice.Series["Countries"].Points.Clear();
            AveragePrice.Titles.Clear();


            if (ChoicePercountry == "AOS")
            {
                foreach (Country x in world)
                {
                    AveragePrice.Series["Countries"].Points.AddXY(x.CountryNamn, x.AverageOverall_satisfaction);
                }
                AveragePrice.Series["Countries"].ChartType = SeriesChartType.RangeColumn;
                AveragePrice.Titles.Add("Average Overall Satisfaction Per Country");
            }

            else if (ChoicePercountry == "APPC")
            {
                foreach (Country x in world)
                {

                    AveragePrice.Series["Countries"].Points.AddXY(x.CountryNamn, x.AveragePrice);
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
            karta.MaxZoom = 25;
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
            }
            for (int y = 1; y < 16; y++)
            {
                comboBox3.Items.Add(y.ToString());
            }
        }

        // Plot some charts
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Average Overall Satisfaction Per Country")
            {
                ChoicePercountry="AOS";
                ChartPerCountry();
                AveragePrice.ChartAreas[0].AxisY.Maximum = 4.9;
                AveragePrice.ChartAreas[0].AxisY.Minimum = 4.5;

                // Gör att länderna får olika färger
                AveragePrice.Series["Countries"].Points[0].Color = Color.FromArgb(245, 169, 188);
                AveragePrice.Series["Countries"].Points[1].Color = Color.FromArgb(245, 169, 208);
                AveragePrice.Series["Countries"].Points[2].Color = Color.FromArgb(245, 169, 225);
                AveragePrice.Series["Countries"].Points[3].Color = Color.FromArgb(245, 169, 242);
                AveragePrice.Series["Countries"].Points[4].Color = Color.FromArgb(226, 169, 243);
                AveragePrice.Series["Countries"].Points[5].Color = Color.FromArgb(208, 169, 245);
                AveragePrice.Series["Countries"].Points[6].Color = Color.FromArgb(169, 169, 245);
                AveragePrice.Series["Countries"].Points[7].Color = Color.FromArgb(169, 169, 245);
                AveragePrice.Series["Countries"].Points[8].Color = Color.FromArgb(169, 188, 245);
                AveragePrice.Series["Countries"].Points[9].Color = Color.FromArgb(169, 208, 245);



            }
            else if (comboBox1.Text == "Average Price Per Country")
            {
                ChoicePercountry= "APPC";
                ChartPerCountry();
                AveragePrice.ChartAreas[0].AxisY.Maximum = Double.NaN;
                AveragePrice.ChartAreas[0].AxisY.Minimum = Double.NaN;
                AveragePrice.ChartAreas[0].RecalculateAxesScale();

                // Gör att länderna får olika färger
                AveragePrice.Series["Countries"].Points[0].Color = Color.FromArgb(245, 169, 188);
                AveragePrice.Series["Countries"].Points[1].Color = Color.FromArgb(245, 169, 208);
                AveragePrice.Series["Countries"].Points[2].Color = Color.FromArgb(245, 169, 225);
                AveragePrice.Series["Countries"].Points[3].Color = Color.FromArgb(245, 169, 242);
                AveragePrice.Series["Countries"].Points[4].Color = Color.FromArgb(226, 169, 243);
                AveragePrice.Series["Countries"].Points[5].Color = Color.FromArgb(208, 169, 245);
                AveragePrice.Series["Countries"].Points[6].Color = Color.FromArgb(169, 169, 245);
                AveragePrice.Series["Countries"].Points[7].Color = Color.FromArgb(169, 169, 245);
                AveragePrice.Series["Countries"].Points[8].Color = Color.FromArgb(169, 188, 245);
                AveragePrice.Series["Countries"].Points[9].Color = Color.FromArgb(169, 208, 245);
            }
            else if (comboBox1.Text == "Amount Of Listing Per Country")
            {
                ChoicePercountry = "AOLPC";
                ChartPerCountry();
                AveragePrice.ChartAreas[0].AxisY.Maximum = Double.NaN;
                AveragePrice.ChartAreas[0].AxisY.Minimum = Double.NaN;
                AveragePrice.ChartAreas[0].RecalculateAxesScale();

                // Gör att länderna får olika färger
                AveragePrice.Series["Countries"].Points[0].Color = Color.FromArgb(245, 169, 188);
                AveragePrice.Series["Countries"].Points[1].Color = Color.FromArgb(245, 169, 208);
                AveragePrice.Series["Countries"].Points[2].Color = Color.FromArgb(245, 169, 225);
                AveragePrice.Series["Countries"].Points[3].Color = Color.FromArgb(245, 169, 242);
                AveragePrice.Series["Countries"].Points[4].Color = Color.FromArgb(226, 169, 243);
                AveragePrice.Series["Countries"].Points[5].Color = Color.FromArgb(208, 169, 245);
                AveragePrice.Series["Countries"].Points[6].Color = Color.FromArgb(169, 169, 245);
                AveragePrice.Series["Countries"].Points[7].Color = Color.FromArgb(169, 169, 245);
                AveragePrice.Series["Countries"].Points[8].Color = Color.FromArgb(169, 188, 245);
                AveragePrice.Series["Countries"].Points[9].Color = Color.FromArgb(169, 208, 245);



            }
            else { }

        }

        // Plot coordinates from Accommodations using a GMaps API
        private void button1_Click(object sender, EventArgs e)
        {
            double xax = 0;
            double yax = 0;
            double numbers = 0.000001; // Noone likes dividing by Zero
            string statement = Program.CreateStatement(comboBox2.Text, nyttomaximering, comboBox3.Text, quantity);
            List<Tuple<double, double>> accs = Program.TopList(statement, connectionString);
            GMapOverlay markers = new GMapOverlay("markers");
            foreach (Tuple<double, double> element in accs)
            {
                PointLatLng point = new PointLatLng(element.Item1, element.Item2);
                GMapMarker mark = new GMarkerGoogle(point, GMarkerGoogleType.blue_dot);
                markers.Markers.Add(mark);
                xax = xax + element.Item1;
                yax = yax + element.Item2;
                numbers = numbers + 1;
            }
            karta.Overlays.Clear();
            karta.Overlays.Add(markers);
            karta.Position = new GMap.NET.PointLatLng((xax / numbers), (yax / numbers));

        }

        private void button2_Click(object sender, EventArgs e)
        {
            double xax = 0;
            double yax = 0;
            double numbers = 0.000001; // Noone likes dividing by Zero
            string statement = Program.CreateStatement(comboBox2.Text, best, comboBox3.Text, quantity);
            List<Tuple<double, double>> accs = Program.TopList(statement, connectionString);
            GMapOverlay markers = new GMapOverlay("markers");
            foreach (Tuple<double, double> element in accs)
            {
                PointLatLng point = new PointLatLng(element.Item1, element.Item2);
                GMapMarker mark = new GMarkerGoogle(point, GMarkerGoogleType.blue_dot);
                markers.Markers.Add(mark);
                xax = xax + element.Item1;
                yax = yax + element.Item2;
                numbers = numbers + 1;
            }
            karta.Overlays.Clear();
            karta.Overlays.Add(markers);
            karta.Position = new GMap.NET.PointLatLng((xax / numbers), (yax / numbers));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            double xax = 0;
            double yax = 0;
            double numbers = 0.000001; // Noone likes dividing by Zero
            string statement = Program.CreateStatement(comboBox2.Text, cheap, comboBox3.Text, quantity);
            List<Tuple<double, double>> accs = Program.TopList(statement, connectionString);
            GMapOverlay markers = new GMapOverlay("markers");
            foreach (Tuple<double, double> element in accs)
            {
                PointLatLng point = new PointLatLng(element.Item1, element.Item2);
                GMapMarker mark = new GMarkerGoogle(point, GMarkerGoogleType.blue_dot);
                markers.Markers.Add(mark);
                xax = xax + element.Item1;
                yax = yax + element.Item2;
                numbers = numbers + 1;
            }
            karta.Overlays.Clear();
            karta.Overlays.Add(markers);
            karta.Position = new GMap.NET.PointLatLng((xax / numbers), (yax / numbers));
        }

        private void numberLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
