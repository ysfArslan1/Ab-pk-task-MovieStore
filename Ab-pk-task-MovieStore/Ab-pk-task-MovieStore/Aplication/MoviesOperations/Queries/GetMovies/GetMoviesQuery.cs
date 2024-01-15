using AutoMapper;
using Ab_pk_task_MovieStore.DBOperations;
using Ab_pk_task_MovieStore.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ab_pk_task_MovieStore.Aplication.MoviesOperations.Queries.GetMovies;
public class GetMoviesQuery
{
    private readonly IPatikaDbContext _dbContext;
    private readonly IMapper _mapper;
    public GetMoviesQuery(IPatikaDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    public List<MovieViewModel> Handle()
    {

        var _list = _dbContext.Movies.OrderBy(x => x.Id).Include(x=>x.Genre).Include(x => x.Director).Include(x=>x.Actors).ToList();

        List<MovieViewModel> result = _mapper.Map<List<MovieViewModel>>(_list);
        return result;
    }
}

public class MovieViewModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public DateTime ReleaseDate { get; set; }
    public string Genre { get; set; }
    public string Director { get; set; }
    public List<int> ActorIds { get; set; }
}


