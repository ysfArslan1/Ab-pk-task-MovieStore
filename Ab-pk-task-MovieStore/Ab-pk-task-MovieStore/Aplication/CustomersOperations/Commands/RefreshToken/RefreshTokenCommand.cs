using Ab_pk_task_MovieStore.DBOperations;
using Ab_pk_task_MovieStore.Entities;
using Ab_pk_task_MovieStore.TokenOperations;
using Ab_pk_task_MovieStore.TokenOperations.Modals;
using AutoMapper;
using Microsoft.Extensions.Configuration;

namespace Ab_pk_task_MovieStore.Aplication.CustomerOperations.Commands.RefreshToken
{
    public class RefreshTokenCommand
    {
        public string RefreshToken { get; set; }
        private readonly IPatikaDbContext _dbContext;
        private readonly IConfiguration _configuration;
        public RefreshTokenCommand(IPatikaDbContext dbContext,  IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        public Token Handle()
        {
            var user = _dbContext.Customers.Where(x => x.RefreshToken == RefreshToken && x.RefreshTokenExpirenDate>DateTime.Now).FirstOrDefault();
            if (user is null)
                throw new InvalidOperationException("Valid bir refresh token bulunamadı");

            TokenHandler tokenHandler = new TokenHandler(_configuration);
            Token token = tokenHandler.CreateAccessToken(user);

            user.RefreshToken = token.RefreshToken;
            user.RefreshTokenExpirenDate = token.Expiration.AddMinutes(5);
            _dbContext.SaveChanges();

            return token;

        }
    }
}
