using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Ab_pk_task_MovieStore.Aplication.CustomersOperations.Queries.GetCustomers;
using Ab_pk_task_MovieStore.DBOperations;
using Ab_pk_task_MovieStore.Aplication.CustomersOperations.Queries.GetCustomerDetail;
using FluentValidation;
using Ab_pk_task_MovieStore.Aplication.CustomersOperations.Commands.UpdateCustomer;

namespace Ab_pk_task_MovieStore.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class CustomerController : ControllerBase
    {
        private readonly IPatikaDbContext _context;
        private readonly IMapper _mapper;

        public CustomerController(IPatikaDbContext bankDbContext, IMapper mapper)
        {
            _context = bankDbContext;
            _mapper = mapper;
        }

        // GET: get GetCustomers
        [HttpGet]
        public IActionResult GetCustomers()
        {
            // Customer verilerinin CustomerViewModel alınması için kullanlan query sınıfı oluşturulur ve handle edilir
            GetCustomersQuery query = new GetCustomersQuery(_context, _mapper);
            var _list = query.Handle();
            return Ok(_list);
        }

        // GET: get Customer from id
        [HttpGet("{id}")]
        public ActionResult<CustomerDetailViewModel> GetCustomerById([FromRoute] int id)
        {
            CustomerDetailViewModel result;

            // GetCustomerDetailQuery nesnesi oluşturulur
            GetCustomerDetailQuery query = new GetCustomerDetailQuery(_context, _mapper);
            query.Id = id;
            // Validation işlemi yapılır.
            GetCustomerDetailQueryValidator validator = new GetCustomerDetailQueryValidator();
            validator.ValidateAndThrow(query);
            result = query.Handle();

            return Ok(result);
        }

        //// Post: create a Customer
        //[HttpPost]
        //public IActionResult AddCustomer([FromBody] CreateCustomerModel newModel)
        //{
        //    // CreateCustomerCommand nesnesi oluşturulur
        //    CreateCustomerCommand command = new CreateCustomerCommand(_context, _mapper);
        //    command.Model = newModel;
        //    // validation yapılır.
        //    CreateCustomerCommandValidator _validator=new CreateCustomerCommandValidator();
        //    _validator.ValidateAndThrow(newModel);
        //    command.Handle();

        //    return Ok();
        //}

        // PUT: update a Customer
        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(int id, [FromBody] UpdateCustomerModel updateCustomer)
        {
            // CreateCustomerCommand nesnesi oluşturulur
            UpdateCustomerCommand command = new UpdateCustomerCommand(_context);
            command.Id = id;
            command.Model = updateCustomer;
            // validation yapılır.
            UpdateCustomerCommandValidator validator = new UpdateCustomerCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok();
        }

        //// DELETE: delete a Customer
        //[HttpDelete("{id}")]
        //public IActionResult DeleteCustomer(int id)
        //{
        //    // CreateCustomerCommand nesnesi oluşturulur
        //    DeleteCustomerCommand command = new DeleteCustomerCommand(_context);
        //    command.Id = id;
        //    // validation yapılır.
        //    DeleteCustomerCommandValidator _validator = new DeleteCustomerCommandValidator();
        //    _validator.ValidateAndThrow(command);
        //    command.Handle();

        //    return Ok();
        //}

    }
}
