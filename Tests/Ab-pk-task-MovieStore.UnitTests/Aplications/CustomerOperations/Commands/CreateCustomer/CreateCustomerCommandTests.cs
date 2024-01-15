using Ab_pk_task_MovieStore.Entities;
using Ab_pk_task_MovieStore.UnitTests.TestsSetup;
using Ab_pk_task_MovieStore.Aplication.CustomersOperations.Commands.CreateCustomer;
using Ab_pk_task_MovieStore.DBOperations;
using Ab_pk_task_MovieStore.Entities;
using AutoMapper;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ab_pk_task_MovieStore.UnitTests.Aplications.CustomerOperations.Commands.CreateCustomer
{
    public class CreateCustomerCommandTests:IClassFixture<CommonTextFicture>
    {
        private readonly PatikaDbContext _dbcontext;
        private readonly IMapper _mapper;
        public CreateCustomerCommandTests(CommonTextFicture textFicture)
        {
            _dbcontext = textFicture.Context;
            _mapper = textFicture.Mapper;
        }
        [Fact]
        public void WhenAlreadyExistCustomerNameIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            //arrange(Hazırla)
            Customer Customer = new Customer()
            {
                Name = "name",
                Surname = "surname",
                Email = "a92@gmail.com",
                Password = "12345",

            };
            _dbcontext.Customers.Add(Customer);
            _dbcontext.SaveChanges();

            CreateCustomerCommand command = new CreateCustomerCommand(_dbcontext, _mapper);
            command.Model = new CreateCustomerModel() { Name = Customer.Name,Surname=Customer.Surname};

            //act & assert (Çalıştır & Dogrula)
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Zaten Mevcut");
        }

        [Fact]
        public void WhenValidInputsIsGiven_Customer_ShouldBeCreated()
        {
            //arrange(Hazırla)
            
            CreateCustomerCommand command = new CreateCustomerCommand(_dbcontext, _mapper);
            command.Model = new CreateCustomerModel()
            {
                Name = "name1twa2",
                Surname = "surname12",
                Email = "a92jgs@gmail.com",
                Password = "12345",

            };
            // act
            FluentActions.Invoking(()=>command.Handle()).Invoke();

            // assert 
            var Customer = _dbcontext.Customers.FirstOrDefault(x=>x.Name == command.Model.Name);
            Customer.Should().NotBeNull();
            Customer.Name.Should().Be(command.Model.Name);
            Customer.Surname.Should().Be(command.Model.Surname);
        }
    }
}
