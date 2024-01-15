using Ab_pk_task_MovieStore.Entities;
using Ab_pk_task_MovieStore.TokenOperations.Modals;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Ab_pk_task_MovieStore.TokenOperations
{
    public class TokenHandler
    {
        public IConfiguration Configuration;
        public TokenHandler(IConfiguration configuration) 
        {
            Configuration = configuration;
        }

        public Token CreateAccessToken(Customer customer)
        {
            Token tokenModal = new Token();
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Token:SecurityKey"]));
            SigningCredentials credentials = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);

            tokenModal.Expiration = DateTime.Now.AddMinutes(15);

            JwtSecurityToken securityToken = new JwtSecurityToken(
                issuer: Configuration["Token:Issuer"],
                audience: Configuration["Token:Audience"],
                expires: tokenModal.Expiration,
                notBefore:DateTime.Now,
                signingCredentials:credentials
                );

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            tokenModal.AccessToken = handler.WriteToken(securityToken);
            tokenModal.RefreshToken = CreateRefreshToken();

            return tokenModal;
        }

        public string CreateRefreshToken()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
