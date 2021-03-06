﻿using System;
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
        List<Accomodation> sat = new List<Accomodation>();
        



        /// <summary>
        /// Constructor for the Country class
        /// </summary>
        /// <param name="CountryNamn">Name of the country</param>
        /// <param name="CountryInvånare">Number of inhabitants</param>
        /// <param name="CountryBnpPerCapita">Made up numbers</param>
        /// <param name="accommodates">Accommondation object, misspelled</param>
        /// 
        //skapar en klass country som innehåller värden: -- och lista accomodation
        public Country(string CountryNamn, int CountryInvånare, int CountryBnpPerCapita, List<Accomodation> accommodates)
        {
            countryNamn = CountryNamn;
            countryInvånare = CountryInvånare;
            countryBnpPerCapita = CountryBnpPerCapita;
            Accommodates = accommodates;
            AverageOverall_satisfaction = (from x in accommodates where x.Overall_satisfaction > 0 select x.Overall_satisfaction).Average();
            //är detta en uträkning
            AveragePrice = accommodates.Average(b => b.Price);
            CountListings = accommodates.Count;


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
        public double AveragePrice { get; set; }
        public int CountListings { get; set; }
    }
}
