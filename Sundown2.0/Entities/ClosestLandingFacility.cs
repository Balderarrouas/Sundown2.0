using System;
using System.ComponentModel.DataAnnotations;

namespace Sundown2._0.Entities
{
    public class ClosestLandingFacility
    {
        [Key]
        public int Id { get; set; }
        public string CountryName { get; set; }
        public double CurrentDistanceInMeters { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }




        public ClosestLandingFacility(string countryName, double currentDistanceInMeters)
        {
            CountryName = countryName;
            CurrentDistanceInMeters = currentDistanceInMeters;
        }

        public ClosestLandingFacility(string countryName, double currentDistanceInMeters, double latitude, double longitude)
        {
            CountryName = countryName;
            CurrentDistanceInMeters = currentDistanceInMeters;
            Latitude = latitude;
            Longitude = longitude;
        }
    }

    

}
