using System;
using System.ComponentModel.DataAnnotations;

namespace Sundown2._0.Entities
{
    public class MissionImage

    {
        [Key]
        public Guid MissionImageId { get; } = Guid.NewGuid();
        public string CameraName { get; set; }
        public string RoverName { get; set; }
        public string RoverStatus { get; set; }
        public string Image { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public Guid MissionReportId { get; set; }
        
    }


}
