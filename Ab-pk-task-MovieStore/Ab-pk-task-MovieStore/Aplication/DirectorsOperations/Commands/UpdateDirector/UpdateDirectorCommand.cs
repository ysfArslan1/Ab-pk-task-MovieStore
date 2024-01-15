using Ab_pk_task_MovieStore.DBOperations;

namespace Ab_pk_task_MovieStore.Aplication.DirectorsOperations.Commands.UpdateDirector
{
    public class UpdateDirectorCommand
    {
        public int Id { get; set; }
        public UpdateDirectorModel Model { get; set; }
        private readonly IPatikaDbContext _dbContext;
        public UpdateDirectorCommand(IPatikaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            // Alınan bilgilerle aynı kayıtın database bulunma durumuna bakılır.
            var item = _dbContext.Directors.Where(x => x.Id == Id).FirstOrDefault();
            if (item is null)
                throw new InvalidOperationException("Director Bulunamadı");

            if(_dbContext.Directors.Any(x=> x.Surname == item.Surname && x.Name == item.Name && x.Id != Id))
                throw new InvalidOperationException("Aynı bilgiler bulunmakta");

            item.Name = Model.Name != default ? Model.Name : item.Name;
            item.Surname = Model.Surname != default ? Model.Surname : item.Surname;

            // database işlemleri yapılır.
            _dbContext.Directors.Update(item);
            _dbContext.SaveChanges();

        }
    }
    // class_ sınıfı düzenlemek için gerekli verilerin alındıgı sınıf.
    public class UpdateDirectorModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
