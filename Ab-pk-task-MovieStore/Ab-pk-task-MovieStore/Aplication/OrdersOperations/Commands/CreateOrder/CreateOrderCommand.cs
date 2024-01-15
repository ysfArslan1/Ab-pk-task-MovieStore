
using AutoMapper;
using Ab_pk_task_MovieStore.DBOperations;
using Ab_pk_task_MovieStore.Entities;

namespace Ab_pk_task_MovieStore.Aplication.OrdersOperations.Commands.CreateOrder
{
    public class CreateOrderCommand
    {
        public CreateOrderModel Model { get; set; }
        private readonly IPatikaDbContext _dbContext;
        private readonly IMapper _mapper;
        public CreateOrderCommand(IPatikaDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {

            var item = _mapper.Map<Order>(Model);
            // database işlemleri yapılır.
            _dbContext.Orders.Add(item);
            _dbContext.SaveChanges();

        }
    }
    // Order sınıfı üretmek için gerekli verilerin alındıgı sınıf.
    public class CreateOrderModel
    {
        public int CustemerId { get; set; }
        public int MovieId { get; set; }
        public int Prize { get; set; }
    }
}
