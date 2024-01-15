using Ab_pk_task_MovieStore.Entities;
using Ab_pk_task_MovieStore.UnitTests.TestsSetup;
using Ab_pk_task_MovieStore.Aplication.CustomersOperations.Commands.DeleteCustomer;
using Ab_pk_task_MovieStore.DBOperations;
using Ab_pk_task_MovieStore.Entities;
using AutoMapper;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ab_pk_task_MovieStore.UnitTests.Aplications.CustomerOperations.Commands.DeleteCustomer
{
    public class DeleteCustomerCommandTests:IClassFixture<CommonTextFicture>
    {

        private readonly PatikaDbContext _dbContext;
        private readonly IMapper _mapper;

        public DeleteCustomerCommandTests(CommonTextFicture textFicture)
        {
            _dbContext = textFicture.Context;
            _mapper = textFicture.Mapper;
        }
        [Fact]
        public void WhenExistingCustomerIdIsGiven_CustomerShouldBeDeleted()
        {
            // Arrange
            Customer Customer = new Customer()
            {
                Name = "ToDeleteCustomer",
                Surname = "ToDeleteCustomer",
                Email = "a64@gmail.com",
                Password = "12345",
            };

            _dbContext.Customers.Add(Customer);
            _dbContext.SaveChanges();

            DeleteCustomerCommand deleteCommand = new DeleteCustomerCommand(_dbContext);
            deleteCommand.Id = Customer.Id;

            // Act
            FluentActions.Invoking(() => deleteCommand.Handle()).Invoke();

            // Assert
            var deletedCustomer = _dbContext.Customers.FirstOrDefault(x => x.Id == Customer.Id);
            deletedCustomer.Should().BeNull();
        }
        [Fact]
        public void WhenNonExistingCustomerIdIsGiven_InvalidOperationException_ShouldBeThrown()
        {
            // Arrange
            int nonExistingCustomerId = -1; // Assuming -1 is not a valid Customer Id

            DeleteCustomerCommand deleteCommand = new DeleteCustomerCommand(_dbContext);
            deleteCommand.Id = nonExistingCustomerId;

            // Act & Assert
            FluentActions.Invoking(() => deleteCommand.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Customer Bulunamadı");
        }

     
    }
}
