using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.Entities
{
    public class Addresses
    {
        public int Id { get; set; }
        public int IdProperty { get; set; }

        public string Street {  get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public int Floor   { get; set; }
        public string Decorated { get; set; }
        public string Observations { get; set; }
        public double Latitude { get; set; }
        public double Length {  get; set; }
        
        public Addresses() {}
        public Addresses(int id, int idProperty, string street, string country, string city, int floor, string decorated, string observations, double latitude, double length)
        {
            Id = id;
            IdProperty = idProperty;
            Street = street;
            Country = country;
            City = city;
            Floor = floor;
            Decorated = decorated;
            Observations = observations;
            Latitude = latitude;
            Length = length;
        }
    }
}
