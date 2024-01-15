using Ab_pk_task_MovieStore.DBOperations;

namespace Ab_pk_task_MovieStore.Aplication.CustomersOperations.Commands.DeleteCustomer
{
    public class DeleteCustomerCommand
    {
        public int Id { get; set; }
        private readonly IPatikaDbContext _dbContext;
        public DeleteCustomerCommand(IPatikaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            // id üzerinden database sorgusu yapılır
            var item = _dbContext.Customers.Where(x => x.Id == Id).FirstOrDefault();
            if (item is null)
                throw new InvalidOperationException("Customer Bulunamadı");
            // database işlemleri yapılır.
            _dbContext.Customers.Remove(item);
            _dbContext.SaveChanges();

        }
    }
}

