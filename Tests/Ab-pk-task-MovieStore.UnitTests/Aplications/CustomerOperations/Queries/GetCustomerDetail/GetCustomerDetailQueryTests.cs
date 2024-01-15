using Ab_pk_task_MovieStore.Entities;
using Ab_pk_task_MovieStore.UnitTests.TestsSetup;
using Ab_pk_task_MovieStore.Aplication.CustomersOperations.Commands.DeleteCustomer;
using Ab_pk_task_MovieStore.Aplication.CustomersOperations.Commands.UpdateCustomer;
using Ab_pk_task_MovieStore.Aplication.CustomersOperations.Queries.GetCustomerDetail;
using Ab_pk_task_MovieStore.DBOperations;
using Ab_pk_task_MovieStore.Entities;
using AutoMapper;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Ab_pk_task_MovieStore.UnitTests.Aplications.CustomerOperations.Queries.GetCustomerDetail
{
    public class GetCustomerDetailQueryTests: IClassFixture<CommonTextFicture>
    {
        private readonly PatikaDbContext _dbcontext;
        private readonly IMapper _mapper;
        public GetCustomerDetailQueryTests(CommonTextFicture textFicture)
        {
            _dbcontext = textFicture.Context;
            _mapper = textFicture.Mapper;
        }
        

        [Fact]
        public void WhenNonExistingCustomerIdIsGiven_InvalidOperationException_ShouldBeThrown()
        {
            // Arrange
            int nonExistingCustomerId = -1; // Assuming -1 is not a valid Customer Id

            GetCustomerDetailQuery query = new GetCustomerDetailQuery(_dbcontext,_mapper);
            query.Id = nonExistingCustomerId;

            // Act & Assert
            FluentActions.Invoking(() => query.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Bulunamadı");
        }

        [Fact]
        public void WhenExistingCustomerIdIsGiven_CustomerShouldBeReturn()
        {
            // Arrange
            Customer Customer = new Customer()
            {
                Name = "name",
                Surname = "surname",
                Email = "a@gmail.com",
                Password = "12345",
            };

            _dbcontext.Customers.Add(Customer);
            _dbcontext.SaveChanges();

            GetCustomerDetailQuery query = new GetCustomerDetailQuery(_dbcontext,_mapper);
            query.Id = Customer.Id;

            // Act
            FluentActions.Invoking(() => query.Handle()).Invoke();

            // Assert
            var result = _dbcontext.Customers.FirstOrDefault(x => x.Id == Customer.Id);
            result.Should().NotBeNull();
            result.Name.Should().Be(Customer.Name);
            result.Surname.Should().Be(Customer.Surname);
        }
    }
}
