
using AutoMapper;
using Ab_pk_task_MovieStore.DBOperations;
using Ab_pk_task_MovieStore.Entities;

namespace Ab_pk_task_MovieStore.Aplication.ActorsOperations.Commands.CreateActor
{
    public class CreateActorCommand
    {
        public CreateActorModel Model { get; set; }
        private readonly IPatikaDbContext _dbContext;
        private readonly IMapper _mapper;
        public CreateActorCommand(IPatikaDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var item = _dbContext.Actors.Where(x => x.Name == Model.Name && x.Surname == Model.Surname).FirstOrDefault();
            if (item is not null)
                throw new InvalidOperationException("Zaten Mevcut");

            item = _mapper.Map<Actor>(Model);
            // database işlemleri yapılır.
            _dbContext.Actors.Add(item);
            _dbContext.SaveChanges();

        }
    }
    // Actor sınıfı üretmek için gerekli verilerin alındıgı sınıf.
    public class CreateActorModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
