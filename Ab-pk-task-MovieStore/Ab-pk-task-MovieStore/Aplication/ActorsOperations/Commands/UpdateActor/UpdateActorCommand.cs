using Ab_pk_task_MovieStore.DBOperations;

namespace Ab_pk_task_MovieStore.Aplication.ActorsOperations.Commands.UpdateActor
{
    public class UpdateActorCommand
    {
        public int Id { get; set; }
        public UpdateActorModel Model { get; set; }
        private readonly IPatikaDbContext _dbContext;
        public UpdateActorCommand(IPatikaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            // Alınan bilgilerle aynı kayıtın database bulunma durumuna bakılır.
            var item = _dbContext.Actors.Where(x => x.Id == Id).FirstOrDefault();
            if (item is null)
                throw new InvalidOperationException("Actor Bulunamadı");

            if (_dbContext.Actors.Any(x => x.Surname == item.Surname && x.Name == item.Name && x.Id != Id))
                throw new InvalidOperationException("Aynı bilgiler bulunmakta");

            item.Name = Model.Name != default ? Model.Name : item.Name;
            item.Surname = Model.Surname != default ? Model.Surname : item.Surname;

            // database işlemleri yapılır.
            _dbContext.Actors.Update(item);
            _dbContext.SaveChanges();

        }
    }
    // class_ sınıfı düzenlemek için gerekli verilerin alındıgı sınıf.
    public class UpdateActorModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
