using FluentValidation;
using Sundown2._0.Data;
using Sundown2._0.Models;


namespace Sundown2._0.Validators
{
    public class UserDTOValidator : AbstractValidator<UserDTO>
    {

        private readonly ApplicationDbContext _context;

        public UserDTOValidator(ApplicationDbContext context)
        {
            _context = context;
        }

        
        public UserDTOValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.CodeName).NotEmpty();
            RuleFor(x => x.Username).NotEmpty(); 
            RuleFor(x => x.Username);             
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.Avatar).NotNull();
        }

        
            

    }


    
}
