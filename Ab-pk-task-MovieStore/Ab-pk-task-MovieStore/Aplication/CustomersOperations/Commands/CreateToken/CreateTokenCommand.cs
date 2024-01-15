using Ab_pk_task_MovieStore.DBOperations;
using Ab_pk_task_MovieStore.TokenOperations;
using Ab_pk_task_MovieStore.TokenOperations.Modals;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using TokenHandler = Ab_pk_task_MovieStore.TokenOperations.TokenHandler;

namespace Ab_pk_task_MovieStore.Aplication.CustomerOperations.Commands.CreateToken
{
    public class CreateTokenCommand
    {
        public CreateTokenModel Model { get; set; }
        private readonly IPatikaDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        public CreateTokenCommand(IPatikaDbContext dbContext, IMapper mapper, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _configuration = configuration;
        }

        public Token Handle()
        {
            var user = _dbContext.Customers.Where(x => x.Email == Model.Email && x.Password == Model.Password).FirstOrDefault();
            if (user is null)
                throw new InvalidOperationException("Kullanıcı Adı ve Şifre Hatalı");

            TokenHandler tokenHandler = new TokenHandler(_configuration);
            Token token = tokenHandler.CreateAccessToken(user);

            user.RefreshToken = token.RefreshToken;
            user.RefreshTokenExpirenDate = token.Expiration.AddMinutes(5);
            _dbContext.SaveChanges();

            return token;
        }
    }
    // Token sınıfı üretmek için gerekli verilerin alındıgı sınıf.
    public class CreateTokenModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
