using AutoMapper;
using Ab_pk_task_MovieStore.DBOperations;

namespace Ab_pk_task_MovieStore.Aplication.CustomersOperations.Queries.GetCustomers;
public class GetCustomersQuery
{
    private readonly IPatikaDbContext _dbContext;
    private readonly IMapper _mapper;
    public GetCustomersQuery(IPatikaDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    public List<CustomerViewModel> Handle()
    {

        var _list = _dbContext.Customers.OrderBy(x => x.Id).ToList();

        List<CustomerViewModel> result = _mapper.Map<List<CustomerViewModel>>(_list);
        return result;
    }
}

public class CustomerViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
}

