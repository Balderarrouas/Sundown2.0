using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Sundown2._0.Models
{
    public class MissionReportRequestModel
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
