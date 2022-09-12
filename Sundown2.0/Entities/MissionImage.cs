using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sundown2._0.Entities
{
    public class MissionImage

    {
        [Key]
        public int MissionImageId { get; set; }
        public string CameraName { get; set; }
        public string RoverName { get; set; }
        public int MyProperty { get; set; }
        public bool RoverStatus { get; set; }
        public string Img { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
        public int MissionReportId { get; set; }
    }
}
