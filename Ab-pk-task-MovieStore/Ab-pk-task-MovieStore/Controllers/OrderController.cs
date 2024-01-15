using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

using AutoMapper;
using Ab_pk_task_MovieStore.Aplication.OrdersOperations.Queries.GetOrders;
using Ab_pk_task_MovieStore.DBOperations;
using Ab_pk_task_MovieStore.Aplication.OrdersOperations.Queries.GetOrderDetail;
using FluentValidation;
using Ab_pk_task_MovieStore.Aplication.OrdersOperations.Commands.UpdateOrder;
using Ab_pk_task_MovieStore.Aplication.OrdersOperations.Commands.DeleteOrder;
using Ab_pk_task_MovieStore.Aplication.OrdersOperations.Commands.CreateOrder;
using Microsoft.AspNetCore.Authorization;

namespace Ab_pk_task_MovieStore.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]s")]
    public class OrderController : ControllerBase
    {
        private readonly IPatikaDbContext _context;
        private readonly IMapper _mapper;

        public OrderController(IPatikaDbContext bankDbContext, IMapper mapper)
        {
            _context = bankDbContext;
            _mapper = mapper;
        }

        // GET: get GetOrders
        [HttpGet]
        public IActionResult GetOrders()
        {
            // Order verilerinin OrderViewModel alınması için kullanlan query sınıfı oluşturulur ve handle edilir
            GetOrdersQuery query = new GetOrdersQuery(_context, _mapper);
            var _list = query.Handle();
            return Ok(_list);
        }

        // GET: get Order from id
        [HttpGet("{id}")]
        public ActionResult<OrderDetailViewModel> GetOrderById([FromRoute] int id)
        {
            OrderDetailViewModel result;

            // GetOrderDetailQuery nesnesi oluşturulur
            GetOrderDetailQuery query = new GetOrderDetailQuery(_context, _mapper);
            query.Id = id;
            // Validation işlemi yapılır.
            GetOrderDetailQueryValidator validator = new GetOrderDetailQueryValidator();
            validator.ValidateAndThrow(query);
            result = query.Handle();

            return Ok(result);
        }

        // Post: create a Order
        [HttpPost]
        public IActionResult AddOrder([FromBody] CreateOrderModel newModel)
        {
            // CreateOrderCommand nesnesi oluşturulur
            CreateOrderCommand command = new CreateOrderCommand(_context, _mapper);
            command.Model = newModel;
            // validation yapılır.
            CreateOrderCommandValidator _validator = new CreateOrderCommandValidator();
            _validator.ValidateAndThrow(newModel);
            command.Handle();

            return Ok();
        }

        // PUT: update a Order
        [HttpPut("{id}")]
        public IActionResult UpdateOrder(int id, [FromBody] UpdateOrderModel updateOrder)
        {
            // CreateOrderCommand nesnesi oluşturulur
            UpdateOrderCommand command = new UpdateOrderCommand(_context);
            command.Id = id;
            command.Model = updateOrder;
            // validation yapılır.
            UpdateOrderCommandValidator validator = new UpdateOrderCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok();
        }

        // DELETE: delete a Order
        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            // CreateOrderCommand nesnesi oluşturulur
            DeleteOrderCommand command = new DeleteOrderCommand(_context);
            command.Id = id;
            // validation yapılır.
            DeleteOrderCommandValidator _validator = new DeleteOrderCommandValidator();
            _validator.ValidateAndThrow(command);
            command.Handle();

            return Ok();
        }

    }
}
