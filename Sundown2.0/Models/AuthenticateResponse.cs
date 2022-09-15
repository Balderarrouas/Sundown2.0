using Sundown2._0.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sundown2._0.Models
{
    public class AuthenticateResponse
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CodeName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
        public string Avatar { get; set; }
        public string JwtToken { get; set; }

        



        public AuthenticateResponse(Astronaut astronaut, string jwtToken)
        {
            Id = astronaut.AstronautId;
            FirstName = astronaut.FirstName;
            LastName = astronaut.LastName;
            CodeName = astronaut.CodeName;
            Username = astronaut.Username;
            Email = astronaut.Email;
            Avatar = astronaut.Avatar;
            JwtToken = jwtToken;            
        }


    }
}
