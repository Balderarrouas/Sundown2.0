using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sundown2._0.Models
{
    public class MissionImageDTO
    {

        [Required]
        public string CameraName { get; set; }
        [Required]
        public string RoverName { get; set; }
        [Required]
        public int RoverId { get; set; }
        [Required]
        public string RoverStatus { get; set; }
        [Required]
        public IFormFile Img { get; set; }
        [Required]
        public int MissionReportId { get; set; }


    }
}
