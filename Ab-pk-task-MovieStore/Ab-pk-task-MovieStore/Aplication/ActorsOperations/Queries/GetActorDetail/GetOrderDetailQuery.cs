using Ab_pk_task_MovieStore.DBOperations;
using AutoMapper;

namespace Ab_pk_task_MovieStore.Aplication.ActorsOperations.Queries.GetActorDetail
{
    public class GetActorDetailQuery
    {
        private readonly IPatikaDbContext _dbContext;
        private readonly IMapper _mapper;
        public int Id { get; set; }
        public GetActorDetailQuery(IPatikaDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public ActorDetailViewModel Handle()
        {
            var item = _dbContext.Actors.Where(x => x.Id == Id).FirstOrDefault();
            if (item is null)
                throw new InvalidOperationException("Bulunamadı");

            ActorDetailViewModel itemDetail = _mapper.Map<ActorDetailViewModel>(item);

            return itemDetail;
        }
    }

    public class ActorDetailViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
