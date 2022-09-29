using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sundown2._0.Entities
{
    public class Astronaut
    {
        [Key]
        public Guid AstronautId { get; } = Guid.NewGuid();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CodeName { get; set; }        
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Avatar { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public List<MissionReport> MissionReports { get; set; }



    }
}
