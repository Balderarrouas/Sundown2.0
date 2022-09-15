//using Sundown2._0.Entities;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Threading.Tasks;

//namespace Sundown2._0.Models
//{
//    public class MissionResponseModel
//    {

//        [Key]
//        public int Id { get; set; }
//        public string Name { get; set; }
//        public string Description { get; set; }
//        public double Latitude { get; set; }
//        public double Longitude { get; set; }
//        public DateTime MissionDate { get; set; }
//        public DateTime FinalisationDate { get; set; }
//        public DateTime CreatedAt { get; set; }
//        public DateTime UpdatedAt { get; set; }
//        public DateTime DeletedAt { get; set; }
//        public int AstronautId { get; set; }
//        //public Astronaut Astronaut { get; set; }
//        // public List<MissionImage> MissionImages { get; set; }

//        public MissionResponseModel(MissionReport missionReport)
//        {
//            Id = missionReport.MissionReportId;
//            Name = missionReport.Name;
//            Description = missionReport.Description;
//            Latitude = missionReport.Latitude;
//            Longitude = missionReport.Longitude;
//            MissionDate = missionReport.MissionDate;
//            FinalisationDate = missionReport.FinalisationDate;
//            CreatedAt = missionReport.CreatedAt;
//            UpdatedAt = missionReport.UpdatedAt;
//            DeletedAt = missionReport.DeletedAt;
//            AstronautId = missionReport.AstronautId;
//            //Astronaut = missionReport.Astronaut;
//            //MissionImages = missionReport.MissionImages;



//        }

//    }
//}
