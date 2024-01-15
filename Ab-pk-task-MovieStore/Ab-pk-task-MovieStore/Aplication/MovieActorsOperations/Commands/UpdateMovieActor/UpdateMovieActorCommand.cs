using Ab_pk_task_MovieStore.DBOperations;

namespace Ab_pk_task_MovieStore.Aplication.MovieActorsOperations.Commands.UpdateMovieActor
{
    public class UpdateMovieActorCommand
    {
        public int Id { get; set; }
        public UpdateMovieActorModel Model { get; set; }
        private readonly IPatikaDbContext _dbContext;
        public UpdateMovieActorCommand(IPatikaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            // Alınan bilgilerle aynı kayıtın database bulunma durumuna bakılır.
            var item = _dbContext.MovieActors.Where(x => x.Id == Id).FirstOrDefault();
            if (item is null)
                throw new InvalidOperationException("MovieActor Bulunamadı");

            if (_dbContext.MovieActors.Any(x => x.MovieId == item.MovieId && x.ActorId == item.ActorId && x.Id != Id))
                throw new InvalidOperationException("Aynı bilgiler bulunmakta");

            item.MovieId = Model.MovieId != default ? Model.MovieId : item.MovieId;
            item.ActorId = Model.ActorId != default ? Model.ActorId : item.ActorId;

            // database işlemleri yapılır.
            _dbContext.MovieActors.Update(item);
            _dbContext.SaveChanges();

        }
    }
    // class_ sınıfı düzenlemek için gerekli verilerin alındıgı sınıf.
    public class UpdateMovieActorModel
    {
        public int MovieId { get; set; }
        public int ActorId { get; set; }
    }
}
