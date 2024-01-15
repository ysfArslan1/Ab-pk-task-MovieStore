using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Ab_pk_task_MovieStore.Aplication.DirectorsOperations.Queries.GetDirectors;
using Ab_pk_task_MovieStore.DBOperations;
using Ab_pk_task_MovieStore.Aplication.DirectorsOperations.Queries.GetDirectorDetail;
using FluentValidation;
using Ab_pk_task_MovieStore.Aplication.DirectorsOperations.Commands.UpdateDirector;

namespace Ab_pk_task_MovieStore.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class DirectorController : ControllerBase
    {
        private readonly IPatikaDbContext _context;
        private readonly IMapper _mapper;

        public DirectorController(IPatikaDbContext bankDbContext, IMapper mapper)
        {
            _context = bankDbContext;
            _mapper = mapper;
        }

        // GET: get GetDirectors
        [HttpGet]
        public IActionResult GetDirectors()
        {
            // Director verilerinin DirectorViewModel alınması için kullanlan query sınıfı oluşturulur ve handle edilir
            GetDirectorsQuery query = new GetDirectorsQuery(_context, _mapper);
            var _list = query.Handle();
            return Ok(_list);
        }

        // GET: get Director from id
        [HttpGet("{id}")]
        public ActionResult<DirectorDetailViewModel> GetDirectorById([FromRoute] int id)
        {
            DirectorDetailViewModel result;

            // GetDirectorDetailQuery nesnesi oluşturulur
            GetDirectorDetailQuery query = new GetDirectorDetailQuery(_context, _mapper);
            query.Id = id;
            // Validation işlemi yapılır.
            GetDirectorDetailQueryValidator validator = new GetDirectorDetailQueryValidator();
            validator.ValidateAndThrow(query);
            result = query.Handle();

            return Ok(result);
        }

        //// Post: create a Director
        //[HttpPost]
        //public IActionResult AddDirector([FromBody] CreateDirectorModel newModel)
        //{
        //    // CreateDirectorCommand nesnesi oluşturulur
        //    CreateDirectorCommand command = new CreateDirectorCommand(_context, _mapper);
        //    command.Model = newModel;
        //    // validation yapılır.
        //    CreateDirectorCommandValidator _validator=new CreateDirectorCommandValidator();
        //    _validator.ValidateAndThrow(newModel);
        //    command.Handle();

        //    return Ok();
        //}

        // PUT: update a Director
        [HttpPut("{id}")]
        public IActionResult UpdateDirector(int id, [FromBody] UpdateDirectorModel updateDirector)
        {
            // CreateDirectorCommand nesnesi oluşturulur
            UpdateDirectorCommand command = new UpdateDirectorCommand(_context);
            command.Id = id;
            command.Model = updateDirector;
            // validation yapılır.
            UpdateDirectorCommandValidator validator = new UpdateDirectorCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok();
        }

        //// DELETE: delete a Director
        //[HttpDelete("{id}")]
        //public IActionResult DeleteDirector(int id)
        //{
        //    // CreateDirectorCommand nesnesi oluşturulur
        //    DeleteDirectorCommand command = new DeleteDirectorCommand(_context);
        //    command.Id = id;
        //    // validation yapılır.
        //    DeleteDirectorCommandValidator _validator = new DeleteDirectorCommandValidator();
        //    _validator.ValidateAndThrow(command);
        //    command.Handle();

        //    return Ok();
        //}

    }
}
