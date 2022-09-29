using Microsoft.AspNetCore.Http;

namespace Sundown2._0.Models
{
    public class UserDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CodeName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public IFormFile Avatar { get; set; }
    }
}
