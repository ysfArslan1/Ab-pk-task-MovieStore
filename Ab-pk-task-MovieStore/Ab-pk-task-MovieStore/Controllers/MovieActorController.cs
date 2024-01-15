using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Ab_pk_task_MovieStore.Aplication.MoviesOperations.Queries.GetMovies;
using Ab_pk_task_MovieStore.DBOperations;
using Ab_pk_task_MovieStore.Aplication.MovieActorsOperations.Queries.GetMovieActors;
using Ab_pk_task_MovieStore.Aplication.MoviesOperations.Queries.GetMovieDetail;
using FluentValidation;
using Ab_pk_task_MovieStore.Aplication.MoviesOperations.Commands.UpdateMovie;
using Ab_pk_task_MovieStore.Aplication.MovieActorsOperations.Queries.GetMovieActorDetail;
using Ab_pk_task_MovieStore.Aplication.MovieActorsOperations.Commands.UpdateMovieActor;

namespace Ab_pk_task_MovieStore.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class MovieActorController : ControllerBase
    {
        private readonly IPatikaDbContext _context;
        private readonly IMapper _mapper;

        public MovieActorController(IPatikaDbContext bankDbContext, IMapper mapper)
        {
            _context = bankDbContext;
            _mapper = mapper;
        }

        // GET: get GetMovies
        [HttpGet]
        public IActionResult GetMovieActors()
        {
            // Movie verilerinin MovieViewModel alınması için kullanlan query sınıfı oluşturulur ve handle edilir
            GetMovieActorsQuery query = new GetMovieActorsQuery(_context, _mapper);
            var _list = query.Handle();
            return Ok(_list);
        }

        // GET: get Movie from id
        [HttpGet("{id}")]
        public ActionResult<MovieActorDetailViewModel> GetMovieById([FromRoute] int id)
        {
            MovieActorDetailViewModel result;

            // GetMovieDetailQuery nesnesi oluşturulur
            GetMovieActorDetailQuery query = new GetMovieActorDetailQuery(_context, _mapper);
            query.Id = id;
            // Validation işlemi yapılır.
            GetMovieActorDetailQueryValidator validator = new GetMovieActorDetailQueryValidator();
            validator.ValidateAndThrow(query);
            result = query.Handle();

            return Ok(result);
        }

        //// Post: create a Movie
        //[HttpPost]
        //public IActionResult AddMovie([FromBody] CreateMovieModel newModel)
        //{
        //    // CreateMovieCommand nesnesi oluşturulur
        //    CreateMovieCommand command = new CreateMovieCommand(_context, _mapper);
        //    command.Model = newModel;
        //    // validation yapılır.
        //    CreateMovieCommandValidator _validator=new CreateMovieCommandValidator();
        //    _validator.ValidateAndThrow(newModel);
        //    command.Handle();

        //    return Ok();
        //}

        // PUT: update a Movie
        [HttpPut("{id}")]
        public IActionResult UpdateMovie(int id, [FromBody] UpdateMovieActorModel updateMovie)
        {
            // CreateMovieCommand nesnesi oluşturulur
            UpdateMovieActorCommand command = new UpdateMovieActorCommand(_context);
            command.Id = id;
            command.Model = updateMovie;
            // validation yapılır.
            UpdateMovieActorCommandValidator validator = new UpdateMovieActorCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok();
        }

        //// DELETE: delete a Movie
        //[HttpDelete("{id}")]
        //public IActionResult DeleteMovie(int id)
        //{
        //    // CreateMovieCommand nesnesi oluşturulur
        //    DeleteMovieCommand command = new DeleteMovieCommand(_context);
        //    command.Id = id;
        //    // validation yapılır.
        //    DeleteMovieCommandValidator _validator = new DeleteMovieCommandValidator();
        //    _validator.ValidateAndThrow(command);
        //    command.Handle();

        //    return Ok();
        //}

    }
}
