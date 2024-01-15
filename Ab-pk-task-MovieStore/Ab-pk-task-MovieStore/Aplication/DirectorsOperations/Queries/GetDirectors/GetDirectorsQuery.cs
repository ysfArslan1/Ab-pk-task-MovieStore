using AutoMapper;
using Ab_pk_task_MovieStore.DBOperations;

namespace Ab_pk_task_MovieStore.Aplication.DirectorsOperations.Queries.GetDirectors;
public class GetDirectorsQuery
{
    private readonly IPatikaDbContext _dbContext;
    private readonly IMapper _mapper;
    public GetDirectorsQuery(IPatikaDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    public List<DirectorViewModel> Handle()
    {

        var _list = _dbContext.Directors.OrderBy(x => x.Id).ToList();

        List<DirectorViewModel> result = _mapper.Map<List<DirectorViewModel>>(_list);
        return result;
    }
}

public class DirectorViewModel
{
    public string Name { get; set; }
    public string Surname { get; set; }
}

