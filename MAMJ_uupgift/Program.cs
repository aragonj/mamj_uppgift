using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics;

namespace MAMJ_uupgift
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            
        }
        /// <summary>
        /// Takes in SQL-querry string and insert correct country name and number and return it as a string
        /// </summary>
        /// <param name="country">table name in an SQL database</param>
        /// <param name="type">An SQL-querry that needs name of table and sorting number inserted</param>
        /// <param name="number">number of accommondations to be sorted by</param>
        /// <returns>A string that is an SQL querry</returns>
        public static string CreateStatement(string country, string type, string number)
        {
            string correctString = type.Replace("COUNTRY", country);
            string statement = correctString.Replace("NUMBER", number);
            return statement;
        }

        /// <summary>
        /// Fetch coordinates from the designated SQL-database.
        /// </summary>
        /// <param name="statement">String containing an SQL-querry that works with the current database</param>
        /// <returns>A list of XY coordinates for Accommodations</returns>
        public static List<Tuple<double, double>> TopList(string statement)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=DESKTOP-VRGDF71; Initial Catalog=Projekt_airbnb; Integrated Security=True";

            double temp1;
            double temp2;
            List<Tuple<double, double>> listan = new List<Tuple<double, double>>();
            try
            {
                conn.Open();

                SqlCommand myQuery = new SqlCommand(statement + ";", conn);
                SqlDataReader myReader = myQuery.ExecuteReader();

                while (myReader.Read())
                {
                    temp1 = (double)myReader["latitude"];
                    temp2 = (double)myReader["longitude"];
                    Tuple<double, double> temp = new Tuple<double, double>(temp1, temp2);
                    listan.Add(temp);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                conn.Close();
            }
            return listan;
        }
    }
}
