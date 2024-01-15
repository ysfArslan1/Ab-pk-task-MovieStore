using Ab_pk_task_MovieStore.DBOperations;
using Ab_pk_task_MovieStore.Entities;

namespace Ab_pk_task_MovieStore.Aplication.MoviesOperations.Commands.UpdateMovie
{
    public class UpdateMovieCommand
    {
        public int Id { get; set; }
        public UpdateMovieModel Model { get; set; }
        private readonly IPatikaDbContext _dbContext;
        public UpdateMovieCommand(IPatikaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            // Alınan bilgilerle aynı kayıtın database bulunma durumuna bakılır.
            var item = _dbContext.Movies.Where(x => x.Id == Id).FirstOrDefault();
            if (item is null)
                throw new InvalidOperationException("Movie Bulunamadı");

            if(_dbContext.Movies.Any(x=> x.Title == item.Title && x.Id !=Id))
                throw new InvalidOperationException("Aynı title bulunmakta");

            item.Title = Model.Title != default ? Model.Title : item.Title;
            item.ReleaseDate = Model.ReleaseDate != default ? Model.ReleaseDate : item.ReleaseDate;
            item.GenreId = Model.GenreId != default ? Model.GenreId : item.GenreId;
            item.DirectorId = Model.DirectorId != default ? Model.DirectorId : item.DirectorId;
            item.Prize = Model.Prize != default ? Model.Prize : item.Prize;

            // database işlemleri yapılır.
            _dbContext.Movies.Update(item);
            _dbContext.SaveChanges();

        }
    }
    // class_ sınıfı düzenlemek için gerekli verilerin alındıgı sınıf.
    public class UpdateMovieModel
    {
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int GenreId { get; set; }
        public int DirectorId { get; set; }
        public int Prize { get; set; }
    }
}
