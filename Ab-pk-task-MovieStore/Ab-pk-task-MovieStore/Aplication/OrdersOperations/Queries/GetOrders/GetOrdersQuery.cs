using AutoMapper;
using Ab_pk_task_MovieStore.DBOperations;
using Microsoft.EntityFrameworkCore;

namespace Ab_pk_task_MovieStore.Aplication.OrdersOperations.Queries.GetOrders;
public class GetOrdersQuery
{
    private readonly IPatikaDbContext _dbContext;
    private readonly IMapper _mapper;
    public GetOrdersQuery(IPatikaDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    public List<OrderViewModel> Handle()
    {

        var _list = _dbContext.Orders.Where(x => x.isActive == true).OrderBy(x => x.Id).Include(x=>x.Movie).Include(x=>x.Custemer).ToList();

        List<OrderViewModel> result = _mapper.Map<List<OrderViewModel>>(_list);
        return result;
    }
}

public class OrderViewModel
{
    public string Custemer { get; set; }
    public string Movie { get; set; }
    public string Prize { get; set; }
    public DateTime PurchaseDate { get; set; }
}

