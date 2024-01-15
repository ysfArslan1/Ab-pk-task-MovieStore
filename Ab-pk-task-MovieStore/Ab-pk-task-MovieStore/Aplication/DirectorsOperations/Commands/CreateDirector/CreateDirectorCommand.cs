
using AutoMapper;
using Ab_pk_task_MovieStore.DBOperations;
using Ab_pk_task_MovieStore.Entities;

namespace Ab_pk_task_MovieStore.Aplication.DirectorsOperations.Commands.CreateDirector
{
    public class CreateDirectorCommand
    {
        public CreateDirectorModel Model { get; set; }
        private readonly IPatikaDbContext _dbContext;
        private readonly IMapper _mapper;
        public CreateDirectorCommand(IPatikaDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var item = _dbContext.Directors.Where(x => x.Name == Model.Name && x.Surname == Model.Surname).FirstOrDefault();
            if (item is not null)
                throw new InvalidOperationException("Zaten Mevcut");

            item = _mapper.Map<Director>(Model);
            // database işlemleri yapılır.
            _dbContext.Directors.Add(item);
            _dbContext.SaveChanges();

        }
    }
    // Director sınıfı üretmek için gerekli verilerin alındıgı sınıf.
    public class CreateDirectorModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
