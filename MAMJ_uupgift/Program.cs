using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics;

namespace MAMJ_uupgift
{
    static class Program
    {
        
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            
        }
        /// <summary>
        /// <param name="country">string that is replacing COUNTRY</param>
        /// <param name="type">The string that eventually have parts swapped out</param>
        /// <param name="number">string that is replacing NUMBER</param>
        public static string CreateStatement(string country, string type, string number)
        {
            string correctString = type.Replace("COUNTRY", country);
            string statement = correctString.Replace("NUMBER", number);
            return statement;
        }

        /// </summary>
        /// <param name="statement">String containing an SQL-querry that works with the current database</param>
        /// <returns>A list of XY coordinates for Accommodations</returns>
        public static List<Tuple<double, double>> TopList(string statement)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=JEROME\\SERVER2017; Initial Catalog=Projekt_airbnb; Integrated Security=True";

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
