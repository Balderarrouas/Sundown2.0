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

namespace Sundown2._0.Services
{


    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        
    }




    public class UserService : IUserService
    {

        private ApplicationDbContext _context;
        private readonly AppSettings _appSettings;

        public UserService(ApplicationDbContext applicationDbContext,
            IOptions<AppSettings> appSettings)
        {
            _context = applicationDbContext;
            _appSettings = appSettings.Value;
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

            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token
            var token = GenerateJwtToken(user);

            return new AuthenticateResponse(user, token);
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
