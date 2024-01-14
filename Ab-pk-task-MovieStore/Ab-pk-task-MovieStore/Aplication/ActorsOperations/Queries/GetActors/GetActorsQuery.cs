using AutoMapper;
using Ab_pk_task_MovieStore.DBOperations;

namespace Ab_pk_task_MovieStore.Aplication.ActorsOperations.Queries.GetActors;
public class GetActorsQuery
{
    private readonly IPatikaDbContext _dbContext;
    private readonly IMapper _mapper;
    public GetActorsQuery(IPatikaDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    public List<ActorViewModel> Handle()
    {

        var _list = _dbContext.Actors.OrderBy(x => x.Id).ToList();

        List<ActorViewModel> result = _mapper.Map<List<ActorViewModel>>(_list);
        return result;
    }
}

public class ActorViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
}

