
using AutoMapper;
using Ab_pk_task_MovieStore.DBOperations;
using Ab_pk_task_MovieStore.Entities;

namespace Ab_pk_task_MovieStore.Aplication.MoviesOperations.Commands.CreateMovie
{
    public class CreateMovieCommand
    {
        public CreateMovieModel Model { get; set; }
        private readonly IPatikaDbContext _dbContext;
        private readonly IMapper _mapper;
        public CreateMovieCommand(IPatikaDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var item = _dbContext.Movies.Where(x => x.Title == Model.Title && x.DirectorId == Model.DirectorId).FirstOrDefault();
            if (item is not null)
                throw new InvalidOperationException("Zaten Mevcut");

            item = _mapper.Map<Movie>(Model);
            // database işlemleri yapılır.
            _dbContext.Movies.Add(item);
            _dbContext.SaveChanges();

        }
    }
    // Movie sınıfı üretmek için gerekli verilerin alındıgı sınıf.
    public class CreateMovieModel
    {
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int GenreId { get; set; }
        public int DirectorId { get; set; }
        public int Prize { get; set; }
    }
}
