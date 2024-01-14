using AutoMapper;
using Ab_pk_task_MovieStore.DBOperations;

namespace Ab_pk_task_MovieStore.Aplication.GenresOperations.Queries.GetGenres;
public class GetGenresQuery
{
    private readonly IPatikaDbContext _dbContext;
    private readonly IMapper _mapper;
    public GetGenresQuery(IPatikaDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    public List<GenreViewModel> Handle()
    {

        var _list = _dbContext.Genres.OrderBy(x => x.Id).ToList();

        List<GenreViewModel> result = _mapper.Map<List<GenreViewModel>>(_list);
        return result;
    }
}

public class GenreViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
}

