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
        /// Takes in a string (type) and swaps out every occurence of COUNTRY (country), QUANTITY and NUMBER (number)
        /// </summary>
        /// <param name="country">string that is replacing COUNTRY</param>
        /// <param name="type">The string that eventually have parts swapped out</param>
        /// <param name="number">string that is replacing NUMBER</param>
        /// <param name="quantity">int that is turned to a string, replacing CUANTITY</param>
        /// <returns>Returns a modified version of the string in statement "type"</returns>
        public static string CreateStatement(string country, string type, string number, int quantity)
        {
            string correctString = type.Replace("COUNTRY", country);
            string statement = correctString.Replace("NUMBER", number);
            correctString = statement.Replace("QUANTITY", quantity.ToString());
            return correctString;
        }

        /// <summary>
        /// Using an established SQL connection "conn" to excetue a SQL querry (statement)
        /// Returning a list of double Tuple if possible.
        /// </summary>
        /// <param name="statement">String containing an SQL-querry that works with the current database</param>
        /// <returns>A list of XY coordinates for Accommodations</returns>
        public static List<Tuple<double, double>> TopList(string statement, string connectionString)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;// "Data Source=DESKTOP-VRGDF71; Initial Catalog=Projekt_airbnb; Integrated Security=True";

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

        /// <summary>
        /// Connects to a SQL database and returns a string list of all Table names
        /// </summary>
        /// <param name="connectionString"> string used as an ConnectionString </param>
        /// <returns> a string list with table names </returns>
        public static List<string> TablenNames(string connectionString)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;// "Data Source=DESKTOP-VRGDF71; Initial Catalog=Projekt_airbnb; Integrated Security=True";

            List<string> listan = new List<string>();
            string temp;

            try
            {
                conn.Open();

                SqlCommand myQuery = new SqlCommand("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' order by TABLE_NAME" + ";", conn);
                SqlDataReader myReader = myQuery.ExecuteReader();

                while (myReader.Read())
                {
                    temp = (string)myReader["TABLE_NAME"];
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
