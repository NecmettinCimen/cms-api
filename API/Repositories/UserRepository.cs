using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using API.Dtos;
using cms_api.Helper;
using cms_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace cms_api.Repositories
{
    public interface IUserRepository{
        Task<string> Authenticate(LoginDto model);
    }
    public class UserRepository(IBaseRepository<User> userRepository) : IUserRepository
    {
        public async Task<string> Authenticate(LoginDto model)
        {
            var user = await userRepository.GetAll().FirstOrDefaultAsync(f=>f.Email == model.Email && f.Password == model.Password);
            if(user==null)
                throw new Exception("Email or password is incorrect");

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(JwtExtension.Key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] 
                {
                    new Claim(ClaimTypes.Email, user.Email.ToString()),
                    new Claim(ClaimTypes.Name, user.Name.ToString()),
                    new Claim(ClaimTypes.UserData, user.Id.ToString()),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}