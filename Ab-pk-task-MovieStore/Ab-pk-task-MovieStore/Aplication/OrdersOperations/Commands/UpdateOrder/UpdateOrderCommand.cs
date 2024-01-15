using Ab_pk_task_MovieStore.DBOperations;

namespace Ab_pk_task_MovieStore.Aplication.OrdersOperations.Commands.UpdateOrder
{
    public class UpdateOrderCommand
    {
        public int Id { get; set; }
        public UpdateOrderModel Model { get; set; }
        private readonly IPatikaDbContext _dbContext;
        public UpdateOrderCommand(IPatikaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            // Alınan bilgilerle aynı kayıtın database bulunma durumuna bakılır.
            var item = _dbContext.Orders.Where(x => x.Id == Id && x.isActive == true).FirstOrDefault();
            if (item is null)
                throw new InvalidOperationException("Order Bulunamadı");


            item.MovieId = Model.MovieId != default ? Model.MovieId : item.MovieId;

            // database işlemleri yapılır.
            _dbContext.Orders.Update(item);
            _dbContext.SaveChanges();

        }
    }
    // class_ sınıfı düzenlemek için gerekli verilerin alındıgı sınıf.
    public class UpdateOrderModel
    {
        public int MovieId { get; set; }
    }
}
