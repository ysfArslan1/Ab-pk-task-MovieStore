using Ab_pk_task_MovieStore.DBOperations;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Ab_pk_task_MovieStore.Aplication.MovieActorsOperations.Queries.GetMovieActorDetail
{
    public class GetMovieActorDetailQuery
    {
        private readonly IPatikaDbContext _dbContext;
        private readonly IMapper _mapper;
        public int Id { get; set; }
        public GetMovieActorDetailQuery(IPatikaDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public MovieActorDetailViewModel Handle()
        {
            var item = _dbContext.MovieActors.Where(x => x.Id == Id).Include(x => x.Movie).Include(x => x.Actor).FirstOrDefault();
            if (item is null)
                throw new InvalidOperationException("Bulunamadı");

            MovieActorDetailViewModel itemDetail = _mapper.Map<MovieActorDetailViewModel>(item);

            return itemDetail;
        }
    }

    public class MovieActorDetailViewModel
    {
        public int Id { get; set; }
        public string MovieTitle { get; set; }
        public string Actor { get; set; }
    }
}
