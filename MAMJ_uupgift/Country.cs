using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAMJ_uupgift
{
    class Country
    {
        //List of variables
        private string countryNamn;
        private int countryInvånare;
        private int countryBnpPerCapita;



        // constructor
        public Country(string CountryNamn, int CountryInvånare, int CountryBnpPerCapita, List<Accomodation> accommodates)
        {
            countryNamn = CountryNamn;
            countryInvånare = CountryInvånare;
            countryBnpPerCapita = CountryBnpPerCapita;
            Accommodates = accommodates;
            AverageOverall_satisfaction = accommodates.Average(a => a.Overall_satisfaction);


        }
        // getter setters
        public string CountryNamn
        {
            get { return countryNamn; }
            set { countryNamn = value; }
        }
        public int CountryInvånare
        {
            get { return countryInvånare; }
            set { countryInvånare = value; }
        }
        public int CityBnpPerCapita
        {
            get { return countryBnpPerCapita; }
            set { countryBnpPerCapita = value; }
        }
        public List<Accomodation> Accommodates { get; } = new List<Accomodation>();

        public double AverageOverall_satisfaction { get; set; }

    }
}
