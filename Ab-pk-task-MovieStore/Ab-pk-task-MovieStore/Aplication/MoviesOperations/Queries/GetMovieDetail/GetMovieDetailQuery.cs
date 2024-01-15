using Ab_pk_task_MovieStore.DBOperations;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Ab_pk_task_MovieStore.Aplication.MoviesOperations.Queries.GetMovieDetail
{
    public class GetMovieDetailQuery
    {
        private readonly IPatikaDbContext _dbContext;
        private readonly IMapper _mapper;
        public int Id { get; set; }
        public GetMovieDetailQuery(IPatikaDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public MovieDetailViewModel Handle()
        {
            var item = _dbContext.Movies.Where(x => x.Id == Id).Include(x => x.Genre).Include(x => x.Director).Include(x => x.Actors).FirstOrDefault();
            if (item is null)
                throw new InvalidOperationException("Bulunamadı");

            MovieDetailViewModel itemDetail = _mapper.Map<MovieDetailViewModel>(item);

            return itemDetail;
        }
    }

    public class MovieDetailViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public List<int> Actors { get; set; }
    }
}
