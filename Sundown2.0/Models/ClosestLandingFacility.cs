using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sundown2._0.Models
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
    }
}
