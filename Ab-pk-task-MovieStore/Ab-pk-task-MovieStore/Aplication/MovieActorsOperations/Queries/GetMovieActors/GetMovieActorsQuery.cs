using AutoMapper;
using Ab_pk_task_MovieStore.DBOperations;
using Ab_pk_task_MovieStore.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ab_pk_task_MovieStore.Aplication.MovieActorsOperations.Queries.GetMovieActors;
public class GetMovieActorsQuery
{
    private readonly IPatikaDbContext _dbContext;
    private readonly IMapper _mapper;
    public GetMovieActorsQuery(IPatikaDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    public List<MovieActorViewModel> Handle()
    {

        var _list = _dbContext.MovieActors.OrderBy(x => x.Id).Include(x=>x.Movie).Include(x => x.Actor).ToList();

        List<MovieActorViewModel> result = _mapper.Map<List<MovieActorViewModel>>(_list);
        return result;
    }
}

public class MovieActorViewModel
{
    public int Id { get; set; }
    public string MovieTitle { get; set; }
    public string Actor { get; set; }
}


