using FluentValidation;
using System;
using System.ComponentModel.DataAnnotations;

namespace Sundown2._0.Models
{
    public class MissionReportDTO
    {

        
        public string Name { get; set; }        
        public string Description { get; set; }        
        public double Latitude { get; set; }        
        public double Longitude { get; set; }       
        public DateTime MissionDate { get; set; }        
        public DateTime FinalisationDate { get; set; }

        

    }

    

}
