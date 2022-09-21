using System;

namespace Sundown2._0.Entities
{
    public class MissionImage

    {
        
        public int MissionImageId { get; set; }
        public string CameraName { get; set; }
        public string RoverName { get; set; }
        public int RoverId { get; set; }
        public string RoverStatus { get; set; }
        public string Image { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public int MissionReportId { get; set; }
        
    }


}
