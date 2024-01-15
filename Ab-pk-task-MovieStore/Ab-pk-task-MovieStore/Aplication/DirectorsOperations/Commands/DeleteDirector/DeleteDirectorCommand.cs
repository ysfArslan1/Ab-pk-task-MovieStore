using Ab_pk_task_MovieStore.DBOperations;

namespace Ab_pk_task_MovieStore.Aplication.DirectorsOperations.Commands.DeleteDirector
{
    public class DeleteDirectorCommand
    {
        public int Id { get; set; }
        private readonly IPatikaDbContext _dbContext;
        public DeleteDirectorCommand(IPatikaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            // id üzerinden database sorgusu yapılır
            var item = _dbContext.Directors.Where(x => x.Id == Id).FirstOrDefault();
            if (item is null)
                throw new InvalidOperationException("Director Bulunamadı");
            // database işlemleri yapılır.
            _dbContext.Directors.Remove(item);
            _dbContext.SaveChanges();

        }
    }
}

