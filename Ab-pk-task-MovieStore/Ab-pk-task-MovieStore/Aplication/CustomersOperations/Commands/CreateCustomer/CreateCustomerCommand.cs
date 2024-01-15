
using AutoMapper;
using Ab_pk_task_MovieStore.DBOperations;
using Ab_pk_task_MovieStore.Entities;

namespace Ab_pk_task_MovieStore.Aplication.CustomersOperations.Commands.CreateCustomer
{
    public class CreateCustomerCommand
    {
        public CreateCustomerModel Model { get; set; }
        private readonly IPatikaDbContext _dbContext;
        private readonly IMapper _mapper;
        public CreateCustomerCommand(IPatikaDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var item = _dbContext.Customers.Where(x => x.Name == Model.Name ).FirstOrDefault();
            if (item is not null)
                throw new InvalidOperationException("Zaten Mevcut");

            item = _mapper.Map<Customer>(Model);
            // database işlemleri yapılır.
            _dbContext.Customers.Add(item);
            _dbContext.SaveChanges();

        }
    }
    // Customer sınıfı üretmek için gerekli verilerin alındıgı sınıf.
    public class CreateCustomerModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
