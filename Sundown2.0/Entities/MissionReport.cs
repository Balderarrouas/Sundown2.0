using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sundown2._0.Entities
{
    public class MissionReport
    {
        [Key]        
        public int MissionReportId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime MissionDate { get; set; }
        public DateTime FinalisationDate { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public int AstronautId { get; set; }
        public Astronaut Astronaut { get; set; }
        public List<MissionImage> MissionImages { get; set; }


        public MissionReport()
        {

        }


        
        
    }

    


}
