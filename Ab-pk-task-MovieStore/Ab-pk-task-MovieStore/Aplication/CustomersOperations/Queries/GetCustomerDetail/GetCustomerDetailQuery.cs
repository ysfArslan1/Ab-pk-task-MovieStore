using Ab_pk_task_MovieStore.DBOperations;
using AutoMapper;

namespace Ab_pk_task_MovieStore.Aplication.CustomersOperations.Queries.GetCustomerDetail
{
    public class GetCustomerDetailQuery
    {
        private readonly IPatikaDbContext _dbContext;
        private readonly IMapper _mapper;
        public int Id { get; set; }
        public GetCustomerDetailQuery(IPatikaDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public CustomerDetailViewModel Handle()
        {
            var item = _dbContext.Customers.Where(x => x.Id == Id).FirstOrDefault();
            if (item is null)
                throw new InvalidOperationException("Bulunamadı");

            CustomerDetailViewModel itemDetail = _mapper.Map<CustomerDetailViewModel>(item);

            return itemDetail;
        }
    }

    public class CustomerDetailViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
    }
}
