using Ab_pk_task_MovieStore.DBOperations;

namespace Ab_pk_task_MovieStore.Aplication.ActorsOperations.Commands.DeleteActor
{
    public class DeleteActorCommand
    {
        public int Id { get; set; }
        private readonly IPatikaDbContext _dbContext;
        public DeleteActorCommand(IPatikaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            // id üzerinden database sorgusu yapılır
            var item = _dbContext.Actors.Where(x => x.Id == Id).FirstOrDefault();
            if (item is null)
                throw new InvalidOperationException("Actor Bulunamadı");
            // database işlemleri yapılır.
            _dbContext.Actors.Remove(item);
            _dbContext.SaveChanges();

        }
    }
}

