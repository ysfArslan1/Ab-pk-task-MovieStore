using Ab_pk_task_MovieStore.Entities;
using Ab_pk_task_MovieStore.UnitTests.TestsSetup;
using Ab_pk_task_MovieStore.Aplication.CustomersOperations.Commands.UpdateCustomer;
using Ab_pk_task_MovieStore.DBOperations;
using Ab_pk_task_MovieStore.Entities;
using AutoMapper;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ab_pk_task_MovieStore.UnitTests.Aplications.CustomerOperations.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandTests: IClassFixture<CommonTextFicture>
    {

        private readonly PatikaDbContext _dbContext;
        private readonly IMapper _mapper;

        public UpdateCustomerCommandTests(CommonTextFicture textFicture)
        {
            _dbContext = textFicture.Context;
            _mapper = textFicture.Mapper;
        }
        [Fact]
        public void WhenValidInputsAreGiven_CustomerShouldBeUpdated()
        {
            // Arrange
            Customer existingCustomer = new Customer()
            {
                Name = "name12",
                Surname = "surname12",
                Email = "a1khr2@gmail.com",
                Password = "12345",
            };

            _dbContext.Customers.Add(existingCustomer);
            _dbContext.SaveChanges();

            UpdateCustomerCommand updateCommand = new UpdateCustomerCommand(_dbContext);
            var existingCustomers = _dbContext.Customers.ToList();

            updateCommand.Id = existingCustomer.Id;
            updateCommand.Model = new UpdateCustomerModel()
            {
                Name = "name1345621346",
                Surname = "surname132"
            };

            // Act
            FluentActions.Invoking(() => updateCommand.Handle()).Invoke();

            // Assert
            var updatedCustomer = _dbContext.Customers.Find(existingCustomer.Id);
            updatedCustomer.Should().NotBeNull();
            updatedCustomer.Name.Should().Be(updateCommand.Model.Name);
            updatedCustomer.Surname.Should().Be(updateCommand.Model.Surname);
        }

        [Fact]
        public void WhenNonExistingCustomerIdIsGiven_InvalidOperationException_ShouldBeThrown()
        {
            // Arrange
            int nonExistingCustomerId = -1; // Assuming -1 is not a valid Customer Id

            UpdateCustomerCommand updateCommand = new UpdateCustomerCommand(_dbContext);
            updateCommand.Id = nonExistingCustomerId;
            updateCommand.Model = new UpdateCustomerModel()
            {
                Name = "name",
                Surname = "surname",
                Email = "a@gmail.com",
                Password = "12345",
            };

            // Act & Assert
            FluentActions.Invoking(() => updateCommand.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Customer Bulunamadı");
        }
    }
}
