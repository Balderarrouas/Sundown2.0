using Sundown2._0.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sundown2._0.Entities
{
    public class Astronaut
    {
        [Key]
        public int AstronautId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CodeName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Avatar { get; set; }
        public List<MissionReport> MissionReports { get; set; }



    }
}
