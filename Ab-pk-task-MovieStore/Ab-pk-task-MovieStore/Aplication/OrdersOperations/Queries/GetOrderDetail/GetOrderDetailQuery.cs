using Ab_pk_task_MovieStore.DBOperations;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Ab_pk_task_MovieStore.Aplication.OrdersOperations.Queries.GetOrderDetail
{
    public class GetOrderDetailQuery
    {
        private readonly IPatikaDbContext _dbContext;
        private readonly IMapper _mapper;
        public int Id { get; set; }
        public GetOrderDetailQuery(IPatikaDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public OrderDetailViewModel Handle()
        {
            var item = _dbContext.Orders.Where(x => x.Id == Id && x.isActive == true).Include(x => x.Movie).Include(x => x.Custemer).FirstOrDefault();
            if (item is null)
                throw new InvalidOperationException("Bulunamadı");

            OrderDetailViewModel itemDetail = _mapper.Map<OrderDetailViewModel>(item);

            return itemDetail;
        }
    }

    public class OrderDetailViewModel
    {
        public string Custemer { get; set; }
        public string Movie { get; set; }
        public string Prize { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}
