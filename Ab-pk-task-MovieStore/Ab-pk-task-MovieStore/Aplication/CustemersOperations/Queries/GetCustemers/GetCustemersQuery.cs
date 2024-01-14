using AutoMapper;
using Ab_pk_task_MovieStore.DBOperations;

namespace Ab_pk_task_MovieStore.Aplication.CustemersOperations.Queries.GetCustemers;
public class GetCustemersQuery
{
    private readonly IPatikaDbContext _dbContext;
    private readonly IMapper _mapper;
    public GetCustemersQuery(IPatikaDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    public List<CustemerViewModel> Handle()
    {

        var _list = _dbContext.Custemers.OrderBy(x => x.Id).ToList();

        List<CustemerViewModel> result = _mapper.Map<List<CustemerViewModel>>(_list);
        return result;
    }
}

public class CustemerViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
}

