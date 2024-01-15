using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

using AutoMapper;
using Ab_pk_task_MovieStore.Aplication.ActorsOperations.Queries.GetActors;
using Ab_pk_task_MovieStore.DBOperations;
using Ab_pk_task_MovieStore.Aplication.ActorsOperations.Queries.GetActorDetail;
using FluentValidation;
using Ab_pk_task_MovieStore.Aplication.ActorsOperations.Commands.UpdateActor;

namespace Ab_pk_task_MovieStore.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class ActorController : ControllerBase
    {
        private readonly IPatikaDbContext _context;
        private readonly IMapper _mapper;

        public ActorController(IPatikaDbContext bankDbContext, IMapper mapper)
        {
            _context = bankDbContext;
            _mapper = mapper;
        }

        // GET: get GetActors
        [HttpGet]
        public IActionResult GetActors()
        {
            // Actor verilerinin ActorViewModel alınması için kullanlan query sınıfı oluşturulur ve handle edilir
            GetActorsQuery query = new GetActorsQuery(_context, _mapper);
            var _list = query.Handle();
            return Ok(_list);
        }

        // GET: get Actor from id
        [HttpGet("{id}")]
        public ActionResult<ActorDetailViewModel> GetActorById([FromRoute] int id)
        {
            ActorDetailViewModel result;

            // GetActorDetailQuery nesnesi oluşturulur
            GetActorDetailQuery query = new GetActorDetailQuery(_context, _mapper);
            query.Id = id;
            // Validation işlemi yapılır.
            GetActorDetailQueryValidator validator = new GetActorDetailQueryValidator();
            validator.ValidateAndThrow(query);
            result = query.Handle();

            return Ok(result);
        }

        //// Post: create a Actor
        //[HttpPost]
        //public IActionResult AddActor([FromBody] CreateActorModel newModel)
        //{
        //    // CreateActorCommand nesnesi oluşturulur
        //    CreateActorCommand command = new CreateActorCommand(_context, _mapper);
        //    command.Model = newModel;
        //    // validation yapılır.
        //    CreateActorCommandValidator _validator=new CreateActorCommandValidator();
        //    _validator.ValidateAndThrow(newModel);
        //    command.Handle();

        //    return Ok();
        //}

        // PUT: update a Actor
        [HttpPut("{id}")]
        public IActionResult UpdateActor(int id, [FromBody] UpdateActorModel updateActor)
        {
            // CreateActorCommand nesnesi oluşturulur
            UpdateActorCommand command = new UpdateActorCommand(_context);
            command.Id = id;
            command.Model = updateActor;
            // validation yapılır.
            UpdateActorCommandValidator validator = new UpdateActorCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok();
        }

        //// DELETE: delete a Actor
        //[HttpDelete("{id}")]
        //public IActionResult DeleteActor(int id)
        //{
        //    // CreateActorCommand nesnesi oluşturulur
        //    DeleteActorCommand command = new DeleteActorCommand(_context);
        //    command.Id = id;
        //    // validation yapılır.
        //    DeleteActorCommandValidator _validator = new DeleteActorCommandValidator();
        //    _validator.ValidateAndThrow(command);
        //    command.Handle();

        //    return Ok();
        //}

    }
}
