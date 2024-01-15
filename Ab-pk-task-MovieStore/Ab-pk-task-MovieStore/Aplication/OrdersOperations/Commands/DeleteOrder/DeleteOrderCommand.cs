using Ab_pk_task_MovieStore.DBOperations;

namespace Ab_pk_task_MovieStore.Aplication.OrdersOperations.Commands.DeleteOrder
{
    public class DeleteOrderCommand
    {
        public int Id { get; set; }
        private readonly IPatikaDbContext _dbContext;
        public DeleteOrderCommand(IPatikaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            // id üzerinden database sorgusu yapılır
            var item = _dbContext.Orders.Where(x => x.Id == Id && x.isActive==true).FirstOrDefault();
            if (item is null)
                throw new InvalidOperationException("Order Bulunamadı");
            item.isActive = false;

            // database işlemleri yapılır.
            _dbContext.Orders.Update(item);
            _dbContext.SaveChanges();

        }
    }
}

