using Ab_pk_task_MovieStore.DBOperations;

namespace Ab_pk_task_MovieStore.Aplication.MoviesOperations.Commands.DeleteMovie
{
    public class DeleteMovieCommand
    {
        public int Id { get; set; }
        private readonly IPatikaDbContext _dbContext;
        public DeleteMovieCommand(IPatikaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            // id üzerinden database sorgusu yapılır
            var item = _dbContext.Movies.Where(x => x.Id == Id).FirstOrDefault();
            if (item is null)
                throw new InvalidOperationException("Movie Bulunamadı");
            // database işlemleri yapılır.
            _dbContext.Movies.Remove(item);
            _dbContext.SaveChanges();

        }
    }
}

