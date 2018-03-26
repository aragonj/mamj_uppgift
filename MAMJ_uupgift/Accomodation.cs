using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAMJ_uupgift
{
    class Accomodation
    {
            //List of variables
            private int room_id;
            private int host_id;
            private string room_type;
            private string borough;
            private string neighborhood;
            private int reviews;
            private double overall_satisfaction;
            private int accomodates;
            private int bedrooms;
            private int price;
            private int minstay;
            private double latitude;
            private double longitude;
            private string last_modified;

            // constructor
            public Accomodation(int Room_id, int Host_id, string Room_type, string Borough, string Neighborhood, int Reviews, double Overall_satisfaction, int Accomodates, int Bedrooms, int Price, int Minstay, double Latitude, double Longitude, string Last_modified)
            {
                room_id = Room_id;
                host_id = Host_id;
                room_type = Room_type;
                borough = Borough;
                neighborhood = Neighborhood;
                reviews = Reviews;
                overall_satisfaction = Overall_satisfaction;
                accomodates = Accomodates;
                bedrooms = Bedrooms;
                price = Price;
                minstay = Minstay;
                latitude = Latitude;
                longitude = Longitude;
                last_modified = Last_modified;
            }
            // getter setters
            public int Room_id
            {
                get { return room_id; }
                set { room_id = value; }
            }
            public int Host_id
            {
                get { return host_id; }
                set { host_id = value; }
            }
            public string Room_type
            {
                get { return room_type; }
                set { room_type = value; }
            }
            public string Borough
            {
                get { return borough; }
                set { borough = value; }
            }
            public string Neighborhood
            {
                get { return neighborhood; }
                set { neighborhood = value; }
            }
            public int Reviews
            {
                get { return reviews; }
                set { reviews = value; }
            }
            public double Overall_satisfaction
            {
                get { return overall_satisfaction; }
                set { overall_satisfaction = value; }
            }
            public int Accomodates
            {
                get { return accomodates; }
                set { accomodates = value; }
            }
            public int Bedrooms
            {
                get { return bedrooms; }
                set { bedrooms = value; }
            }
            public int Price
            {
                get { return price; }
                set { price = value; }
            }
            public int Minstay
            {
                get { return minstay; }
                set { minstay = value; }
            }
            public double Latitude
            {
                get { return latitude; }
                set { latitude = value; }
            }
            public double Longitude
            {
                get { return longitude; }
                set { longitude = value; }
            }
            public string Last_modified
            {
                get { return last_modified; }
                set { last_modified = value; }
            }
    }
}
