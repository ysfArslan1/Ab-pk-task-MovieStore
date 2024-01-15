using Ab_pk_task_MovieStore.DBOperations;

namespace Ab_pk_task_MovieStore.Aplication.MovieActorsOperations.Commands.DeleteMovieActor
{
    public class DeleteMovieActorCommand
    {
        public int Id { get; set; }
        private readonly IPatikaDbContext _dbContext;
        public DeleteMovieActorCommand(IPatikaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            // id üzerinden database sorgusu yapılır
            var item = _dbContext.MovieActors.Where(x => x.Id == Id).FirstOrDefault();
            if (item is null)
                throw new InvalidOperationException("MovieActor Bulunamadı");
            // database işlemleri yapılır.
            _dbContext.MovieActors.Remove(item);
            _dbContext.SaveChanges();

        }
    }
}

