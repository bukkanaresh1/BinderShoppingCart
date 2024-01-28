using BinderShoppingCart.Data.Transformation.Objects;
using BinderShoppingCart.Repository.Models;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;

namespace BinderShoppingCart.OAuth._2._0
{
    public class JwtAuthenticationManager
    {
        private readonly IConfiguration _config;
        public JwtAuthenticationManager(IConfiguration config)
        {
            _config = config;
        }

        public const int JWT_TOKEN_VALIDITY_MINS = 30;
       // public const string JWT_SECURITY_KEY = "Binder_Shopping_Cart_123_Binder_Shopping_Cart_123";
        public JwtAuthResponse Authenticate(string emailAddress, string password)
        {
            User userDetails = null;
            using (var _context = new BinderShoppingCartContext())
            {
               userDetails = _context.Users.Where(x => x.EmailAddress == emailAddress && 
               x.Password == password).Include("UserRole").FirstOrDefault();

            }

            if (userDetails == null)
            {
                return null;
            }

            var tokenExpiryTimeStamp = DateTime.Now.AddMinutes(JWT_TOKEN_VALIDITY_MINS);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(_config.GetValue<string>(
                "JWTSecurityKey"));
            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.Name, emailAddress),
                    new Claim(ClaimTypes.Role, userDetails.UserRole.RoleName)
                }),
                Expires = tokenExpiryTimeStamp,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            var token = jwtSecurityTokenHandler.WriteToken(securityToken);

            return new JwtAuthResponse
            {
                token = token,
                user_name = emailAddress,
                expires_in = (int)tokenExpiryTimeStamp.Subtract(DateTime.Now).TotalSeconds
            };
        }
    }
}
