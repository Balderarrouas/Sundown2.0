using Microsoft.Extensions.Options;
using Sundown2._0.Data;
using Sundown2._0.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Sundown2._0.Entities;
using Sundown2._0.ExceptionHandling.Exceptions;
using FluentValidation;
using AutoMapper;
using FluentValidation.Results;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Sundown2._0.Services
{


    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        Astronaut Create(UserDTO model);
        Task<List<Astronaut>> GetAll();
        Astronaut GetById(int id);
        Astronaut Update(UserDTO model, int id);
        Astronaut Delete(int id);

    }




    public class UserService : IUserService
    {

        private readonly ApplicationDbContext _context;
        private readonly AppSettings _appSettings;
        private readonly IMapper _mapper;
        private readonly IValidator<UserDTO> _validator;

        public UserService(ApplicationDbContext applicationDbContext,
            IOptions<AppSettings> appSettings, IMapper mapper, IValidator<UserDTO> validator)
        {
            _context = applicationDbContext;
            _appSettings = appSettings.Value;
            _mapper = mapper;
            _validator = validator;
        }

        


        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            foreach (var userItem in _context.Astronauts)

            {
                if (userItem.Username == model.Username)
                {
                    var veryfiedPassword = VerifyPassword(userItem.Password, model.Password);
                    if (veryfiedPassword == true)
                    {
                        model.Password = userItem.Password;
                    }
                }
            }
            var user = _context.Astronauts.SingleOrDefault(x => x.Username == model.Username && x.Password == model.Password);

            
            if (user == null)
            {
                throw new CustomNotFoundException("Username or password is incorrect");
             
            }
                

            // authentication successful so generate jwt token
            var token = GenerateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }


        public Astronaut Create(UserDTO model)
        {
            ValidationResult result = _validator.Validate(model);

            if (!result.IsValid)
            {
                throw new CustomValidationException("User did not fulfill the neccesary validation requirements");
            }

            var user = _mapper.Map<Astronaut>(model);

            

            var filePath = Path.Combine(_appSettings.MediaFolder, model.Avatar.FileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                model.Avatar.CopyTo(stream);
            }

            user.Avatar = filePath;
            user.CreatedAt = DateTime.UtcNow;
            user.UpdatedAt = DateTime.UtcNow;
            user.Password = HashPassword(model.Password);

            _context.Astronauts.Add(user);
            _context.SaveChanges();

            return user;
        }

        public async Task<List<Astronaut>> GetAll()
        {
            return _context.Astronauts.ToList();
        }

        public Astronaut GetById(int id)
        {
            var user = _context.Astronauts.SingleOrDefault(x => x.AstronautId == id);

            if (user == null)
            {
                throw new CustomNotFoundException($"Astronaut with {id} could not be found");
            }

            return user;
        }

        public Astronaut Update(UserDTO model, int id)
        {
            ValidationResult result = _validator.Validate(model);

            if (!result.IsValid)
            {
                throw new CustomValidationException("Request body did not fulfill the neccesary validation requirements");
            }

            var filePath = Path.Combine(_appSettings.MediaFolder, model.Avatar.FileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                model.Avatar.CopyTo(stream);
            }

            var userToUpdate = _context.Astronauts.SingleOrDefault(x => x.AstronautId == id);

            if (userToUpdate == null)
            {
                throw new CustomNotFoundException($"Astronaut with {id} could not be found");
            }

            userToUpdate.FirstName = model.FirstName;
            userToUpdate.LastName = model.LastName;
            userToUpdate.CodeName = model.CodeName;
            userToUpdate.Username = model.Username;
            userToUpdate.Email = model.Email;
            userToUpdate.Password = HashPassword(model.Password);
            userToUpdate.Avatar = filePath;

            _context.Astronauts.Update(userToUpdate);
            _context.SaveChanges();

            return userToUpdate;

        }


        public Astronaut Delete(int id)
        {
            var userToDelete = _context.Astronauts.Find(id);

            if (userToDelete == null)
            {
                throw new CustomNotFoundException($"Astronaut with {id} could not be found");
            }

            userToDelete.DeletedAt = DateTime.UtcNow;
            _context.SaveChanges();

            return userToDelete;
        }




        // Helper methods

        private string GenerateJwtToken(Astronaut astronaut)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.UserData, astronaut.AstronautId.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }


        public string HashPassword(string password, byte[] salt = null, bool needsOnlyHash = false)
        {
            if (salt == null || salt.Length != 16)
            {
                // generate a 128-bit salt using a secure PRNG
                salt = new byte[128 / 8];
                using (var rng = RandomNumberGenerator.Create())
                {
                    rng.GetBytes(salt);
                }
            }

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            if (needsOnlyHash) return hashed;
            // password will be concatenated with salt using ':'
            return $"{hashed}:{Convert.ToBase64String(salt)}";
        }

        


        private bool VerifyPassword(string hashedPasswordWithSalt, string passwordToCheck)
        {
            // retrieve both salt and password from 'hashedPasswordWithSalt'
            var passwordAndHash = hashedPasswordWithSalt.Split(':');
            if (passwordAndHash == null || passwordAndHash.Length != 2)
                return false;
            var salt = Convert.FromBase64String(passwordAndHash[1]);
            if (salt == null)
                return false;
            // hash the given password
            var hashOfpasswordToCheck = HashPassword(passwordToCheck, salt, true);
            // compare both hashes
            if (String.Compare(passwordAndHash[0], hashOfpasswordToCheck) == 0)
            {
                return true;
            }
            return false;
        }












        //public void Register(RegisterRequest model)
        //{
        //    // Check if username is taken
        //    if (_context.Users.Any(x => x.Username == model.Username))
        //        throw new ApplicationException("Username'" + model.Username + "'is already taken");

        //    // map model to a new user object
        //    var user = _mapper.Map<User>(model);

        //    // hash password
        //    // var somethingElse =  Encoding.ASCII.GetBytes(_appSettings.Secret);

        //    user.Password = HashPassword(model.Password);

        //    // save user
        //    _context.Users.Add(user);
        //    _context.SaveChanges();
        //}



    }
}
