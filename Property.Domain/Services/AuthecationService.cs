
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Property.Domain.Models;
using Property.Domain.Models.UserDtos;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Property.Domain.Services
{
    public class AuthecationService
    {
        private readonly IConfiguration _configuration;
        private readonly IUserServices _userServices;
        private readonly ILogger<AuthecationService> _logger;

        public AuthecationService(
            IUserServices userServices,
            IConfiguration configuration,
            ILogger<AuthecationService> logger
            ) 
        {
            _configuration=configuration?? throw new ArgumentNullException(nameof(configuration));
            _userServices = userServices?? throw new ArgumentNullException(nameof(userServices));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task <string?> Authenticate(UserCredentialsForLoginDto user)
        {
            
             var userInfo = await _userServices.GetUserFromEmailPassword(user);
           
            if (userInfo == null)
            {
                return null;
            }
            _logger.LogInformation(userInfo.ToString());

            string token =CreateToken(userInfo);

            return token;           
        }

        private string CreateToken(UserInfoForToken user)
        {
            var secutrityKey =
                 new SymmetricSecurityKey(
                 Encoding.ASCII.GetBytes(_configuration["Authentication:SecretForKey"]));

            var sigingCredentials = new SigningCredentials(
                secutrityKey, SecurityAlgorithms.HmacSha256);
            var claimsForToken = new List<Claim>();
            claimsForToken.Add(new Claim("id", user.Id!.ToString()));
            claimsForToken.Add(new Claim("name", user!.Name));
            claimsForToken.Add(new Claim("email", user!.Email));


            var jwtSecurityToken = new JwtSecurityToken(
                _configuration["Authentication:Issuer"],
                _configuration["Authentication:Audience"],
                claimsForToken,
                DateTime.UtcNow,
                DateTime.UtcNow.AddHours(1),
                sigingCredentials);

            var tokenToReturn = new JwtSecurityTokenHandler()
                .WriteToken(jwtSecurityToken);
            return tokenToReturn;
        }

    }
}
