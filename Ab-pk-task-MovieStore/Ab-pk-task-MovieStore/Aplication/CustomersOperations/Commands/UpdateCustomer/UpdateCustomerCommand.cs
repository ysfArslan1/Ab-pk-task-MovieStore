using Ab_pk_task_MovieStore.DBOperations;

namespace Ab_pk_task_MovieStore.Aplication.CustomersOperations.Commands.UpdateCustomer
{
    public class UpdateCustomerCommand
    {
        public int Id { get; set; }
        public UpdateCustomerModel Model { get; set; }
        private readonly IPatikaDbContext _dbContext;
        public UpdateCustomerCommand(IPatikaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            // Alınan bilgilerle aynı kayıtın database bulunma durumuna bakılır.
            var item = _dbContext.Customers.Where(x => x.Id == Id).FirstOrDefault();
            if (item is null)
                throw new InvalidOperationException("Customer Bulunamadı");

            if(_dbContext.Customers.Any(x=> x.Name == item.Name && x.Surname == item.Surname && x.Id != Id))
                throw new InvalidOperationException("Aynı bilgiler bulunmakta");

            if (_dbContext.Customers.Any(x => x.Email == item.Email  && x.Id != Id))
                throw new InvalidOperationException("Aynı Email bulunmakta");

            item.Name = Model.Name != default ? Model.Name : item.Name;
            item.Surname = Model.Surname != default ? Model.Surname : item.Surname;
            item.Email = Model.Email != default ? Model.Email : item.Email;
            item.Password = Model.Password != default ? Model.Password : item.Password;

            // database işlemleri yapılır.
            _dbContext.Customers.Update(item);
            _dbContext.SaveChanges();

        }
    }
    // class_ sınıfı düzenlemek için gerekli verilerin alındıgı sınıf.
    public class UpdateCustomerModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
