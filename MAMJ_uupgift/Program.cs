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
        /// The main entry point for the application. här startas all kod! 
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            
        }
        /// <summary>
        /// Takes in a string (type) and swaps out every occurence of COUNTRY (country and NUMBER (number)
        /// tar ut varje händelse ifrån COUNTRY 
        /// </summary>
        /// <param name="country">string that is replacing COUNTRY</param>
        /// <param name="type">The string that eventually have parts swapped out</param>
        /// <param name="number">string that is replacing NUMBER</param>
        /// <returns>Returns a modified version of the string in statement "type"</returns>
        public static string CreateStatement(string country, string type, string number)
        {
            string correctString = type.Replace("COUNTRY", country);
            string statement = correctString.Replace("NUMBER", number);
            return statement;
        }

        /// <summary>
        /// Using an established SQL connection "conn" to excetue a SQL querry (statement)
        /// Returning a list of double Tuple if possible.
        /// </summary>
        /// <param name="statement">String containing an SQL-querry that works with the current database</param>
        /// <returns>A list of XY coordinates for Accommodations</returns>
        public static List<Tuple<double, double>> TopList(string statement)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=JEROME\\SERVER2017; Initial Catalog=Projekt_airbnb; Integrated Security=True";

            //definerar 2 nya variabler som används till 
            double temp1;
            double temp2;
            List<Tuple<double, double>> listan = new List<Tuple<double, double>>();
            try
            {
                //öpnar variablen conn, som leder till from.cs
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
    }//gtretertery
}
