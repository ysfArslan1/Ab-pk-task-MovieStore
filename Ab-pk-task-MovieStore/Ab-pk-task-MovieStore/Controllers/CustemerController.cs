using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Ab_pk_task_MovieStore.Aplication.CustemersOperations.Queries.GetCustemers;
using Ab_pk_task_MovieStore.DBOperations;

namespace Ab_pk_task_MovieStore.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class CustemerController : ControllerBase
    {
        private readonly IPatikaDbContext _context;
        private readonly IMapper _mapper;

        public CustemerController(IPatikaDbContext bankDbContext, IMapper mapper)
        {
            _context = bankDbContext;
            _mapper = mapper;
        }

        // GET: get GetCustemers
        [HttpGet]
        public IActionResult GetCustemers()
        {
            // Custemer verilerinin CustemerViewModel alınması için kullanlan query sınıfı oluşturulur ve handle edilir
            GetCustemersQuery query = new GetCustemersQuery(_context, _mapper);
            var _list = query.Handle();
            return Ok(_list);
        }

        //// GET: get Custemer from id
        //[HttpGet("{id}")]
        //public ActionResult<CustemerDetailViewModel> GetCustemerById([FromRoute] int id)
        //{
        //    CustemerDetailViewModel result;
           
        //    // GetCustemerDetailQuery nesnesi oluşturulur
        //    GetCustemerDetailQuery query = new GetCustemerDetailQuery(_context, _mapper);
        //    query.Id = id;
        //    // Validation işlemi yapılır.
        //    GetCustemerDetailQueryValidator validator = new GetCustemerDetailQueryValidator();
        //    validator.ValidateAndThrow(query);
        //    result = query.Handle();
            
        //    return Ok(result);
        //}

        //// Post: create a Custemer
        //[HttpPost]
        //public IActionResult AddCustemer([FromBody] CreateCustemerModel newModel)
        //{
        //    // CreateCustemerCommand nesnesi oluşturulur
        //    CreateCustemerCommand command = new CreateCustemerCommand(_context, _mapper);
        //    command.Model = newModel;
        //    // validation yapılır.
        //    CreateCustemerCommandValidator _validator=new CreateCustemerCommandValidator();
        //    _validator.ValidateAndThrow(newModel);
        //    command.Handle();

        //    return Ok();
        //}

        //// PUT: update a Custemer
        //[HttpPut("{id}")]
        //public IActionResult UpdateCustemer(int id, [FromBody] UpdateCustemerModel updateCustemer)
        //{
        //    // CreateCustemerCommand nesnesi oluşturulur
        //    UpdateCustemerCommand command = new UpdateCustemerCommand(_context);
        //    command.Id = id;
        //    command.Model = updateCustemer;
        //    // validation yapılır.
        //    UpdateCustemerCommandValidator validator  = new UpdateCustemerCommandValidator();
        //    validator.ValidateAndThrow(command);
        //    command.Handle();
           
        //    return Ok();
        //}

        //// DELETE: delete a Custemer
        //[HttpDelete("{id}")]
        //public IActionResult DeleteCustemer(int id)
        //{
        //    // CreateCustemerCommand nesnesi oluşturulur
        //    DeleteCustemerCommand command = new DeleteCustemerCommand(_context);
        //    command.Id = id;
        //    // validation yapılır.
        //    DeleteCustemerCommandValidator _validator = new DeleteCustemerCommandValidator();
        //    _validator.ValidateAndThrow(command);
        //    command.Handle();
           
        //    return Ok();
        //}

    }
}
