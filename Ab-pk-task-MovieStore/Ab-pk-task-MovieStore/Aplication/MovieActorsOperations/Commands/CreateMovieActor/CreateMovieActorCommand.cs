
using AutoMapper;
using Ab_pk_task_MovieStore.DBOperations;
using Ab_pk_task_MovieStore.Entities;

namespace Ab_pk_task_MovieStore.Aplication.MovieActorsOperations.Commands.CreateMovieActor
{
    public class CreateMovieActorCommand
    {
        public CreateMovieActorModel Model { get; set; }
        private readonly IPatikaDbContext _dbContext;
        private readonly IMapper _mapper;
        public CreateMovieActorCommand(IPatikaDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var item = _dbContext.MovieActors.Where(x => x.MovieId == Model.MovieId && x.ActorId == Model.ActorId).FirstOrDefault();
            if (item is not null)
                throw new InvalidOperationException("Zaten Mevcut");

            item = _mapper.Map<MovieActor>(Model);
            // database işlemleri yapılır.
            _dbContext.MovieActors.Add(item);
            _dbContext.SaveChanges();

        }
    }
    // MovieActor sınıfı üretmek için gerekli verilerin alındıgı sınıf.
    public class CreateMovieActorModel
    {
        public int MovieId { get; set; }
        public int ActorId { get; set; }
    }
}
