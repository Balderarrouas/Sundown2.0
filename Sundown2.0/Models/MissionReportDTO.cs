using System;
using System.ComponentModel.DataAnnotations;

namespace Sundown2._0.Models
{
    public class MissionReportDTO
    {

        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public double Latitude { get; set; }
        [Required]
        public double Longitude { get; set; }
        [Required]
        public DateTime MissionDate { get; set; }
        [Required]
        public DateTime FinalisationDate { get; set; }

        





    }
}
