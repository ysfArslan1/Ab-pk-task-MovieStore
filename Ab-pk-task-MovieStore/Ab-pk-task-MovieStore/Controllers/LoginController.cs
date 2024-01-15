using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

using AutoMapper;
using Ab_pk_task_MovieStore.Aplication.ActorsOperations.Queries.GetActors;
using Ab_pk_task_MovieStore.DBOperations;
using Ab_pk_task_MovieStore.Aplication.ActorsOperations.Queries.GetActorDetail;
using FluentValidation;
using Ab_pk_task_MovieStore.Aplication.ActorsOperations.Commands.UpdateActor;
using Ab_pk_task_MovieStore.Aplication.ActorsOperations.Commands.DeleteActor;
using Ab_pk_task_MovieStore.Aplication.ActorsOperations.Commands.CreateActor;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using Ab_pk_task_MovieStore.TokenOperations.Modals;
using Ab_pk_task_MovieStore.Aplication.CustomerOperations.Commands.CreateToken;
using Ab_pk_task_MovieStore.Aplication.CustomerOperations.Commands.RefreshToken;

namespace Ab_pk_task_MovieStore.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class LoginController : ControllerBase
    {
        private readonly IPatikaDbContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public LoginController(IPatikaDbContext bankDbContext, IMapper mapper, IConfiguration configuration)
        {
            _context = bankDbContext;
            _mapper = mapper;
            _configuration = configuration;
        }

        [HttpPost("connect/token")]
        public ActionResult<Token> CreateToken([FromBody] CreateTokenModel login)
        {
            // CreateAuthorCommand nesnesi oluşturulur
            CreateTokenCommand command = new CreateTokenCommand(_context, _mapper, _configuration);
            command.Model = login;
            var token = command.Handle();

            return token;
        }
        [HttpGet("refreshToken")]
        public ActionResult<Token> RefreshToken([FromQuery] string token)
        {
            // CreateAuthorCommand nesnesi oluşturulur
            RefreshTokenCommand command = new RefreshTokenCommand(_context, _configuration);
            command.RefreshToken = token;
            var resultToken = command.Handle();

            return resultToken;
        }

    }
}
