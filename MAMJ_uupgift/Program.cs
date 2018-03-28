using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

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

        //string nyttomaximering = "select top 100 (overall_satisfaction/price) as nyttomaximering from Spanien where accommodates = 1 and overall_satisfaction != 0 order by nyttomaximering desc";
        public static List<double> TopList(string statement)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=DESKTOP-VRGDF71; Initial Catalog=Projekt_airbnb; Integrated Security=True";

            double temp;
            List<double> listan = new List<double>();
            try
            {
                conn.Open();

                SqlCommand myQuery = new SqlCommand(statement + ";", conn);
                SqlDataReader myReader = myQuery.ExecuteReader();

                while (myReader.Read())
                {
                    temp = (double)myReader["nyttomaximering"];
                    listan.Add(temp);
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
            return listan;
        }
    }
}
