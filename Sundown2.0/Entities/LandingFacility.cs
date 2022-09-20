using System.ComponentModel.DataAnnotations;

namespace Sundown2._0.Entities
{

    public class LandingFacility
    {

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double DistanceToISS { get; set; }

    }
}
