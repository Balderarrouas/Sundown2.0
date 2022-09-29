using System;
using System.ComponentModel.DataAnnotations;

namespace Sundown2._0.Entities
{

    public class LandingFacility
    {

        [Key]
        public Guid Id { get; } = Guid.NewGuid();
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double DistanceToISS { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }


    }
}
