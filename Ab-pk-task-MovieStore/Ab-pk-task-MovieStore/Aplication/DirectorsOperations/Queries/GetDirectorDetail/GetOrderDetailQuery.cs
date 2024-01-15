using Ab_pk_task_MovieStore.DBOperations;
using AutoMapper;

namespace Ab_pk_task_MovieStore.Aplication.DirectorsOperations.Queries.GetDirectorDetail
{
    public class GetDirectorDetailQuery
    {
        private readonly IPatikaDbContext _dbContext;
        private readonly IMapper _mapper;
        public int Id { get; set; }
        public GetDirectorDetailQuery(IPatikaDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public DirectorDetailViewModel Handle()
        {
            var item = _dbContext.Directors.Where(x => x.Id == Id).FirstOrDefault();
            if (item is null)
                throw new InvalidOperationException("Bulunamadı");

            DirectorDetailViewModel itemDetail = _mapper.Map<DirectorDetailViewModel>(item);

            return itemDetail;
        }
    }

    public class DirectorDetailViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
