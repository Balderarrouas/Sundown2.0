using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace Sundown2._0.Models
{
    public class MissionImageDTO
    {

        
        public string CameraName { get; set; }        
        public string RoverName { get; set; }              
        public string RoverStatus { get; set; }        
        public IFormFile Img { get; set; }        
        public Guid MissionReportId { get; set; }


    }
}
